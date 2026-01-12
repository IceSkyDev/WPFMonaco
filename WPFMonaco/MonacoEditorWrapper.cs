using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFMonaco
{
    public class MonacoEditorWrapper : IDisposable
    {
        private readonly string monacoPath = @"Monaco\index.html";

        private readonly IWebView2 webView2;
        private TaskCompletionSource editorLoaded = new TaskCompletionSource();
        private readonly MonacoHostedObject editorHostedObject = new MonacoHostedObject();

        public Action<string>? OnTextChanged;
        public Action<EditorReadyEventArgs> OnEditorReady;
        public Action<ContentChangedEventArgs> OnContentChanged;
        public Action<CursorPositionChangedEventArgs> OnCursorPositionChanged;
        public Action<SelectionChangedEventArgs> OnSelectionChanged;
        public Action OnEditorFocused;
        public Action OnEditorBlurred;
        public Action OnEditorWidgetFocused;
        public Action OnEditorWidgetBlurred;
        public Action<MouseEventArgs> OnMouseDown;
        public Action<MouseEventArgs> OnMouseUp;
        public Action<KeyboardEventArgs> OnKeyDown;
        public Action<KeyboardEventArgs> OnKeyUp;
        public Action<PasteEventArgs> OnPaste;
        public Action<ScrollChangedEventArgs> OnScrollChanged;
        public Action<LanguageChangedEventArgs> OnLanguageChanged;
        public Action<Dictionary<string, object>> OnConfigurationChanged;

        public Task EditorLoadedTask => editorLoaded.Task;

        public MonacoEditorWrapper(IWebView2 webView2)
        {
            this.webView2 = webView2;
            editorHostedObject.EditorReady += (s, e) => OnEditorReady?.Invoke(e);
            editorHostedObject.ContentChanged += (s, e) => OnContentChanged?.Invoke(e);
            editorHostedObject.CursorPositionChanged += (s, e) => OnCursorPositionChanged?.Invoke(e);
            editorHostedObject.SelectionChanged += (s, e) => OnSelectionChanged?.Invoke(e);
            editorHostedObject.EditorFocused += (s, e) => OnEditorFocused?.Invoke();
            editorHostedObject.EditorBlurred += (s, e) => OnEditorBlurred?.Invoke();
            editorHostedObject.MouseDown += (s, e) => OnMouseDown?.Invoke(e);
            editorHostedObject.MouseUp += (s, e) => OnMouseUp?.Invoke(e);
            editorHostedObject.KeyDown += (s, e) => OnKeyDown?.Invoke(e);
            editorHostedObject.KeyUp += (s, e) => OnKeyUp?.Invoke(e);
            editorHostedObject.Paste += (s, e) => OnPaste?.Invoke(e);
            editorHostedObject.ScrollChanged += (s, e) => OnScrollChanged?.Invoke(e);
            editorHostedObject.LanguageChanged += (s, e) => OnLanguageChanged?.Invoke(e);
            editorHostedObject.ConfigurationChanged += (s, e) => OnConfigurationChanged?.Invoke(e);
        }

        public async Task Initialize()
        {
            // set UDF for web view 2
            CoreWebView2Environment env = await CoreWebView2Environment.CreateAsync(userDataFolder: Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "WebView2"));
            await webView2.EnsureCoreWebView2Async(env);

            webView2.CoreWebView2.ContextMenuRequested += (o, e) => e.Handled = true;
            webView2.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView2.CoreWebView2.Settings.IsStatusBarEnabled = false;
            webView2.CoreWebView2.Settings.AreDevToolsEnabled = false;

            webView2.CoreWebView2.NavigationCompleted += CoreWebView2_NavigationCompleted;
            webView2.Source = new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, monacoPath));
            webView2.CoreWebView2.AddHostObjectToScript("monacoHost", editorHostedObject);
            //await InjectInitializationScript();
            await InjectEvent();
        }

        public async Task OpenDevToolsWindow()
        {
            await EditorLoadedTask;
            webView2.CoreWebView2.OpenDevToolsWindow();
        }

        private void CoreWebView2_NavigationCompleted(object? sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            webView2.CoreWebView2.NavigationCompleted -= CoreWebView2_NavigationCompleted;
            editorLoaded.SetResult();
        }

        public async Task SetText(string text)
        {
            if (text is not null)
            {
                await ExecuteScriptAsync($"editor.setValue(`{text}`);");
            }
        }

        public async Task<string> GetText()
        {
            return await ExecuteScriptAsync("editor.getValue()");
        }

        public async Task SetTheme(MonacoTheme theme)
        {
            switch (theme)
            {
                case MonacoTheme.Dark:
                    await ExecuteScriptAsync("monaco.editor.setTheme('vs-dark');");
                    break;
                case MonacoTheme.HCLight:
                    await ExecuteScriptAsync("monaco.editor.setTheme('hc-light');");
                    break;
                case MonacoTheme.HCDark:
                    await ExecuteScriptAsync("monaco.editor.setTheme('hc-black');");
                    break;
                default:
                    await ExecuteScriptAsync("monaco.editor.setTheme('vs');");
                    break;
            }
        }

        public async Task SetLanguage(string lang)
        {
            await ExecuteScriptAsync($"monaco.editor.setModelLanguage(editor.getModel(),'{lang.ToLower()}');");
        }

        public async Task SetReadonly(bool isReadOnly)
        {
            //await webView2.ExecuteScriptAsync($"editor.updateOptions({{readOnly: {isReadOnly.ToString().ToLower()}, readOnlyMessage: {{value:null}}}});");
            await UpdateOptions(new Dictionary<string, object> { ["readOnly"] = isReadOnly, ["readOnlyMessage"] = new Dictionary<string, object> { ["value"] = null } });
        }


        public async Task<string> ExecuteScriptAsync(string script)
        {
            await EditorLoadedTask;
            var result = await webView2.ExecuteScriptAsync(script);
            return result.TrimStart('"').TrimEnd('"');
        }
        public async Task<T?> ExecuteScriptAsync<T>(string script)
        {
            await EditorLoadedTask;
            var result = await webView2.ExecuteScriptAsync(script);
            return JsonSerializer.Deserialize<T>(result.TrimStart('"').TrimEnd('"'));
        }

        public Task<Position> GetPosion() => ExecuteScriptAsync<Position>($"editor.getPosition();");
        public Task SetPosion(Position position) => ExecuteScriptAsync<Position>($"editor.setPosition({JsonSerializer.Serialize(position)});editor.revealPositionInCenterIfOutsideViewport({JsonSerializer.Serialize(position)})");
        public Task<string> GetSelection() => ExecuteScriptAsync($"editor.getModel().getValueInRange(editor.getSelection());");
        public Task SetSelection(Selection selection) => ExecuteScriptAsync($"editor.setSelection({JsonSerializer.Serialize(selection)});");
        public Task SelectAll() => ExecuteTrigger("script", "editor.action.selectAll");
        public Task GoToLine(int line) => ExecuteScriptAsync($"editor.revealLineInCenter({line})");
        public Task GoToPosition(Position position) => ExecuteScriptAsync($"editor.revealPositionNearTop({JsonSerializer.Serialize(position)})");
        public Task GoToRange(Range range) => ExecuteScriptAsync($"editor.revealRangeNearTop({JsonSerializer.Serialize(range)})");
        public Task Insert(string value, Range range) => ExecuteScriptAsync($"editor.getModel().pushEditOperations(" +
                        $"[], " +
                        $"[{{text: {JsonSerializer.Serialize(value)}, range: {JsonSerializer.Serialize(range)}}}], " +
                        $"() => null);");

        public Task<List<string>> GetLanguages() => ExecuteScriptAsync<List<string>>("monaco.languages.getLanguages().filter(lang=>lang.extensions).map(lang => lang.id);");
        public Task<string> GetRowOptions() => ExecuteScriptAsync("editor.getRawOptions()");
        public Task<string> GetDefaultOptions() => ExecuteScriptAsync("monaco.editor.EditorOptions");
        public Task UpdateOptions(string option) => ExecuteScriptAsync($"editor.updateOptions({JsonSerializer.Serialize(option)});");
        public Task UpdateOptions(Dictionary<string, object> options) => ExecuteScriptAsync($"editor.updateOptions({OptionHelper.DictionaryToJson(options)});");
        public Task FormatText() => ExecuteScriptAsync($"editor.trigger('editor', 'editor.action.formatDocument', {{}});");
        public Task ExecuteEditCommand(string command, Dictionary<string, object> param) => ExecuteScriptAsync($"editor.executeEdits('{command}',{OptionHelper.DictionaryToJson(param)})");
        public Task ExecuteTrigger(string source, string func, object args = null) => ExecuteScriptAsync($"editor.trigger('{source}','{func}'{(args == null ? "" : "," + args)})");

        public Task<string> TestScript(string script) => ExecuteScriptAsync(script);

        private async Task InjectEvent()
        {
            var script = @"
editor.onDidChangeModelContent((e) => {
    try {
        const eventData = {
            changes: e.changes,
            isFlush: e.isFlush,
            eol: e.eol,
            versionId: e.versionId,
            isRedoing: e.isRedoing,
            IsUndoing: e.IsUndoing
        };
        chrome.webview.hostObjects.monacoHost.OnContentChanged(JSON.stringify(eventData));
    } catch (err) {
        console.error('ContentChanged error:', err);
    }
});

editor.onDidChangeCursorPosition((e) => {
    try {
        const eventData = {
            position: {
                lineNumber: e.position.lineNumber,
                column: e.position.column
            },
            reason: e.reason,
            source: e.source
        };
        chrome.webview.hostObjects.monacoHost.OnCursorPositionChanged(JSON.stringify(eventData));
    } catch (err) {
        console.error('CursorPositionChanged error:', err);
    }
});

editor.onDidChangeCursorSelection((e) => {
    try {
        const eventData = {
            selection: {
                startLineNumber: e.selection.startLineNumber,
                startColumn: e.selection.startColumn,
                endLineNumber: e.selection.endLineNumber,
                endColumn: e.selection.endColumn
            },
            reason: e.reason,
            source: e.source
        };
        chrome.webview.hostObjects.monacoHost.OnSelectionChanged(JSON.stringify(eventData));
    } catch (err) {
        console.error('SelectionChanged error:', err);
    }
});

editor.onDidFocusEditorText(() => {
    chrome.webview.hostObjects.monacoHost.OnEditorFocused();
});

editor.onDidBlurEditorText(() => {
    chrome.webview.hostObjects.monacoHost.OnEditorBlurred();
});

editor.onMouseDown((e) => {
    try {
        const eventData = {
            target: e.target?.type,
            event: {
                posx: e.event.posx,
                posy: e.event.posy,
                clientX: e.event.clientX,
                clientY: e.event.clientY,
                buttons: e.event.buttons,
                leftButton: e.event.leftButton,
                middleButton: e.event.middleButton,
                rightButton: e.event.rightButton
            }
        };
        chrome.webview.hostObjects.monacoHost.OnMouseDown(JSON.stringify(eventData));
    } catch (err) {
        console.error('MouseDown error:', err);
    }
});

editor.onMouseUp((e) => {
    try {
        const eventData = {
            target: e.target?.type,
            event: {
                posx: e.event.posx,
                posy: e.event.posy,
                clientX: e.event.clientX,
                clientY: e.event.clientY,
                buttons: e.event.buttons,
                leftButton: e.event.leftButton,
                middleButton: e.event.middleButton,
                rightButton: e.event.rightButton
            }
        };
        chrome.webview.hostObjects.monacoHost.OnMouseUp(JSON.stringify(eventData));
    } catch (err) {
        console.error('MouseUp error:', err);
    }
});

editor.onKeyDown((e) => {
    try {
        const eventData = {
            key: e.key,
            code: e.code,
            keyCode: e.keyCode,
            ctrlKey: e.ctrlKey,
            shiftKey: e.shiftKey,
            altKey: e.altKey,
            metaKey: e.metaKey
        };
        chrome.webview.hostObjects.monacoHost.OnKeyDown(JSON.stringify(eventData));
    } catch (err) {
        console.error('KeyDown error:', err);
    }
});

editor.onKeyUp((e) => {
    try {
        const eventData = {
            key: e.key,
            code: e.code,
            keyCode: e.keyCode,
            ctrlKey: e.ctrlKey,
            shiftKey: e.shiftKey,
            altKey: e.altKey,
            metaKey: e.metaKey
        };
        chrome.webview.hostObjects.monacoHost.OnKeyUp(JSON.stringify(eventData));
    } catch (err) {
        console.error('KeyUp error:', err);
    }
});

editor.onDidPaste((e) => {
    try {
        const eventData = {
            range: e.range ? {
                startLineNumber: e.range.startLineNumber,
                startColumn: e.range.startColumn,
                endLineNumber: e.range.endLineNumber,
                endColumn: e.range.endColumn
            } : null
        };
        chrome.webview.hostObjects.monacoHost.OnPaste(JSON.stringify(eventData));
    } catch (err) {
        console.error('Paste error:', err);
    }
});

editor.onDidScrollChange((e) => {
    try {
        const eventData = {
            scrollTop: e.scrollTop,
            scrollLeft: e.scrollLeft,
            scrollWidth: e.scrollWidth,
            scrollHeight: e.scrollHeight
        };
        chrome.webview.hostObjects.monacoHost.OnScrollChanged(JSON.stringify(eventData));
    } catch (err) {
        console.error('ScrollChanged error:', err);
    }
});

editor.onDidChangeModelLanguage((e) => {
    try {
        const eventData = {
            oldLanguage: e.oldLanguage,
            newLanguage: e.newLanguage
        };
        chrome.webview.hostObjects.monacoHost.OnLanguageChanged(JSON.stringify(eventData));
    } catch (err) {
        console.error('LanguageChanged error:', err);
    }
});

editor.onDidChangeConfiguration((e) => {
    chrome.webview.hostObjects.monacoHost.OnConfigurationChanged(JSON.stringify(editor.getRawOptions()));
});
";

            await ExecuteScriptAsync(script);
        }

        public void Dispose()
        {
            webView2.Dispose();
        }
    }

    public enum MonacoTheme
    {
        Light,
        Dark,
        HCLight,
        HCDark,
    }
}