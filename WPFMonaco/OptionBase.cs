using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Dynamic;

namespace WPFMonaco
{
    public abstract class OptionBase
    {
        private readonly object defaultOption;
        private static readonly JsonSerializerSettings compareSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver { NamingStrategy = new CamelCaseNamingStrategy() },
            Formatting = Formatting.None,
            NullValueHandling = NullValueHandling.Include,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };
        protected OptionBase(object defaultConfig)
        {
            defaultOption = defaultConfig;
        }

        private bool IsValueChanged(string propertyName)
        {
            var currentProp = GetType().GetProperty(propertyName);
            if (currentProp == null) return false;
            var currentValue = currentProp.GetValue(this);

            var defaultProp = defaultOption.GetType().GetProperty(propertyName);
            if (defaultProp == null) return false;
            var defaultValue = defaultProp.GetValue(defaultOption);

            var currentJson = JsonConvert.SerializeObject(currentValue, compareSettings);
            var defaultJson = JsonConvert.SerializeObject(defaultValue, compareSettings);

            return currentJson != defaultJson;
        }

        public string SerializeToJson()
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new OptionContractResolver(this),
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            return JsonConvert.SerializeObject(this, settings);
        }

        private class OptionContractResolver : DefaultContractResolver
        {
            private readonly OptionBase option;

            public OptionContractResolver(OptionBase config)
            {
                this.option = config;
            }

            protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
            {
                var property = base.CreateProperty(member, memberSerialization);

                property.ShouldSerialize = _ => option.IsValueChanged(member.Name);

                return property;
            }
        }
    }
    public static class OptionHelper
    {
        public static dynamic FromDictionary(Dictionary<string, object> dictionary)
        {
            if (dictionary == null)
                return null;

            dynamic expando = new ExpandoObject();
            var expandoDict = (IDictionary<string, object>)expando;

            foreach (var kvp in dictionary)
            {
                if (kvp.Value is Dictionary<string, object> nestedDict)
                {
                    expandoDict[kvp.Key] = FromDictionary(nestedDict);
                }
                else if (kvp.Value is IEnumerable collection && !(kvp.Value is string))
                {
                    var list = new List<object>();
                    foreach (var item in collection)
                    {
                        if (item is Dictionary<string, object> itemDict)
                        {
                            list.Add(FromDictionary(itemDict));
                        }
                        else
                        {
                            list.Add(item);
                        }
                    }
                    expandoDict[kvp.Key] = list.ToArray();
                }
                else
                {
                    expandoDict[kvp.Key] = kvp.Value;
                }
            }

            return expando;
        }

        public static string DictionaryToJson(Dictionary<string, object> dictionary, bool indented = true)
        {
            dynamic dynamicObj = FromDictionary(dictionary);
            var formatting = indented ? Formatting.Indented : Formatting.None;
            return JsonConvert.SerializeObject(dynamicObj, formatting);
        }
    }
}
