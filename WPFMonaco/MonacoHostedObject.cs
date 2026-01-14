// ----------------------------------------------------------------
// Copyright ©2026 IceSky All Rights Reserved.
// Author: IceSky
// IceSky App Doc: https://iceskydev.github.io/AppDoc/
// ----------------------------------------------------------------
using Newtonsoft.Json;
using System.Runtime.InteropServices;

namespace WPFMonaco
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class MonacoHostedObject
    {
        #region EventHandler
        public event EventHandler<EditorReadyEventArgs> EditorReady;

        public event EventHandler<ContentChangedEventArgs> ContentChanged;
        public event EventHandler<CursorPositionChangedEventArgs> CursorPositionChanged;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        public event EventHandler EditorFocused;
        public event EventHandler EditorBlurred;
        public event EventHandler EditorWidgetFocused;
        public event EventHandler EditorWidgetBlurred;

        public event EventHandler<MouseEventArgs> MouseDown;
        public event EventHandler<MouseEventArgs> MouseUp;

        public event EventHandler<KeyboardEventArgs> KeyDown;
        public event EventHandler<KeyboardEventArgs> KeyUp;
        public event EventHandler<PasteEventArgs> Paste;

        public event EventHandler<LanguageChangedEventArgs> LanguageChanged;

        public event EventHandler<ScrollChangedEventArgs> ScrollChanged;
        public event EventHandler<Dictionary<string, object>> ConfigurationChanged;
        #endregion

        public void OnContentChanged(string text)
        {
            var args = JsonConvert.DeserializeObject<ContentChangedEventArgs>(text);
            ContentChanged?.Invoke(this, args);
        }
        public void OnCursorPositionChanged(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<CursorPositionChangedEventArgs>(jsonData);
            CursorPositionChanged?.Invoke(this, args);
        }
        public void OnSelectionChanged(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<SelectionChangedEventArgs>(jsonData);
            SelectionChanged?.Invoke(this, args);
        }
        public void OnEditorFocused()
        {
            EditorFocused?.Invoke(this, EventArgs.Empty);
        }

        public void OnEditorBlurred()
        {
            EditorBlurred?.Invoke(this, EventArgs.Empty);
        }

        public void OnEditorWidgetFocused()
        {
            EditorWidgetFocused?.Invoke(this, EventArgs.Empty);
        }

        public void OnEditorWidgetBlurred()
        {
            EditorWidgetBlurred?.Invoke(this, EventArgs.Empty);
        }
        public void OnMouseDown(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<MouseEventArgs>(jsonData);
            MouseDown?.Invoke(this, args);
        }
        public void OnMouseUp(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<MouseEventArgs>(jsonData);
            MouseUp?.Invoke(this, args);
        }
        public void OnKeyDown(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<KeyboardEventArgs>(jsonData);
            KeyDown?.Invoke(this, args);
        }
        public void OnKeyUp(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<KeyboardEventArgs>(jsonData);
            KeyUp?.Invoke(this, args);
        }
        public void OnPaste(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<PasteEventArgs>(jsonData);
            Paste?.Invoke(this, args);
        }
        public void OnLanguageChanged(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<LanguageChangedEventArgs>(jsonData);
            LanguageChanged?.Invoke(this, args);
        }
        public void OnScrollChanged(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<ScrollChangedEventArgs>(jsonData);
            ScrollChanged?.Invoke(this, args);
        }
        public void OnConfigurationChanged(string jsonData)
        {
            var args = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            ConfigurationChanged?.Invoke(this, args);
        }
    }
}
