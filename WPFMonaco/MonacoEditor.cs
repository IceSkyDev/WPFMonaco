// ----------------------------------------------------------------
// Copyright ©2026 IceSky All Rights Reserved.
// Author: IceSky
// IceSky App Doc: https://iceskydev.github.io/AppDoc/
// ----------------------------------------------------------------
using Microsoft.Web.WebView2.Wpf;
using System.Windows.Controls;
using System.Windows;

namespace WPFMonaco
{
    public class MonacoEditor : ContentControl, IDisposable
    {
        private readonly MonacoEditorWrapper editorWrapper;
        private bool innerChange;

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register(nameof(Text), typeof(string), typeof(MonacoEditor),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    async (o, args) =>
                {
                    var editor = (o as MonacoEditor)!;
                    var oldValue = args.OldValue as string ?? string.Empty;
                    var newValue = args.NewValue as string ?? string.Empty;

                    if (!editor.innerChange && !oldValue.Equals(newValue))
                        await editor.editorWrapper.SetText(newValue);
                }));

        public MonacoTheme Theme
        {
            get => (MonacoTheme)GetValue(ThemeProperty);
            set => SetValue(ThemeProperty, value);
        }

        public static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(MonacoTheme), typeof(MonacoEditor),
                new FrameworkPropertyMetadata(async (o, args) =>
                {
                    var editor = (o as MonacoEditor)!;
                    await editor.editorWrapper.SetTheme((MonacoTheme)args.NewValue);
                }));

        public static readonly DependencyProperty OpenDevToolsProperty =
            DependencyProperty.Register("OpenDevTools", typeof(bool), typeof(MonacoEditor),
                new FrameworkPropertyMetadata(async (o, args) =>
               {
                   var editor = (o as MonacoEditor)!;

                   if ((bool)args.NewValue)
                   {
                       await editor.editorWrapper.OpenDevToolsWindow();
                   }
               }));

        public bool ReadOnly
        {
            get { return (bool)GetValue(ReadOnlyProperty); }
            set { SetValue(ReadOnlyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ReadOnly.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(MonacoEditor), new PropertyMetadata(false, async (o, e) =>
            {
                var editor = (o as MonacoEditor)!;
                await editor.editorWrapper.SetReadonly((bool)e.NewValue);
            }));

        public string ModelLanguage
        {
            get { return (string)GetValue(ModelLanguageProperty); }
            set { SetValue(ModelLanguageProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Language.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelLanguageProperty =
            DependencyProperty.Register("ModelLanguage", typeof(string), typeof(MonacoEditor), new PropertyMetadata("", async (o, e) =>
            {
                var editor = (o as MonacoEditor)!;
                if (e.NewValue != null)
                    await editor.editorWrapper.SetLanguage(e.NewValue.ToString());
            }));

        public bool MinimapEnabled
        {
            get => (bool)GetValue(MinimapEnabledProperty);
            set => SetValue(MinimapEnabledProperty, value);
        }
        public static readonly DependencyProperty MinimapEnabledProperty =
            DependencyProperty.Register(nameof(MinimapEnabled), typeof(bool), typeof(MonacoEditor),
                new PropertyMetadata(true, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["minimap"] = new Dictionary<string, object> { ["enabled"] = e.NewValue } }); }));



        public string FontFamily
        {
            get { return (string)GetValue(FontFamilyProperty); }
            set { SetValue(FontFamilyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FontFamily.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FontFamilyProperty =
            DependencyProperty.Register(nameof(FontFamily), typeof(string), typeof(MonacoEditor), new PropertyMetadata("Consolas", async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["fontFamily"] = e.NewValue }); }));

        public int FontSize
        {
            get => (int)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }
        public static readonly DependencyProperty FontSizeProperty =
            DependencyProperty.Register(nameof(FontSize), typeof(int), typeof(MonacoEditor),
                new PropertyMetadata(14, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["fontSize"] = e.NewValue }); }));

        public int TabSize
        {
            get => (int)GetValue(TabSizeProperty);
            set => SetValue(TabSizeProperty, value);
        }
        public static readonly DependencyProperty TabSizeProperty =
            DependencyProperty.Register(nameof(TabSize), typeof(int), typeof(MonacoEditor),
                new PropertyMetadata(4, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["tabSize"] = e.NewValue }); }));

        public bool WordWrap
        {
            get => (bool)GetValue(WordWrapProperty);
            set => SetValue(WordWrapProperty, value);
        }
        public static readonly DependencyProperty WordWrapProperty =
            DependencyProperty.Register(nameof(WordWrap), typeof(bool), typeof(MonacoEditor),
                new PropertyMetadata(true, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["wordWrap"] = (bool)e.NewValue ? "on" : "off" }); }));
        public bool ShowLineNumber
        {
            get => (bool)GetValue(ShowLineNumberProperty);
            set => SetValue(ShowLineNumberProperty, value);
        }
        public static readonly DependencyProperty ShowLineNumberProperty =
            DependencyProperty.Register(nameof(ShowLineNumber), typeof(bool), typeof(MonacoEditor),
                new PropertyMetadata(true, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["lineNumbers"] = (bool)e.NewValue ? "on" : "off" }); }));

        public int LineNumbersChars
        {
            get => (int)GetValue(LineNumbersCharsProperty);
            set => SetValue(LineNumbersCharsProperty, value);
        }
        public static readonly DependencyProperty LineNumbersCharsProperty =
            DependencyProperty.Register(nameof(LineNumbersChars), typeof(int), typeof(MonacoEditor),
                new PropertyMetadata(5, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["lineNumbersMinChars"] = e.NewValue }); }));

        public int LineHeight
        {
            get => (int)GetValue(LineHeightProperty);
            set => SetValue(LineHeightProperty, value);
        }
        public static readonly DependencyProperty LineHeightProperty =
            DependencyProperty.Register(nameof(LineHeight), typeof(int), typeof(MonacoEditor),
                new PropertyMetadata(19, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["lineHeight"] = e.NewValue }); }));

        public bool Folding
        {
            get => (bool)GetValue(FoldingProperty);
            set => SetValue(FoldingProperty, value);
        }
        public static readonly DependencyProperty FoldingProperty =
            DependencyProperty.Register(nameof(Folding), typeof(bool), typeof(MonacoEditor),
                new PropertyMetadata(true, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["folding"] = e.NewValue }); }));

        public bool ContextMenuEnable
        {
            get => (bool)GetValue(ContextMenuEnableProperty);
            set => SetValue(ContextMenuEnableProperty, value);
        }
        public static readonly DependencyProperty ContextMenuEnableProperty =
            DependencyProperty.Register(nameof(ContextMenuEnable), typeof(bool), typeof(MonacoEditor),
                new PropertyMetadata(true, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["contextmenu"] = e.NewValue }); }));

        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(HScrollBarVisibilityProperty); }
            set { SetValue(HScrollBarVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HScrollBarVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HScrollBarVisibilityProperty =
            DependencyProperty.Register(nameof(HorizontalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(MonacoEditor), new PropertyMetadata(ScrollBarVisibility.Auto, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["scrollbar"] = new Dictionary<string, object> { ["horizontal"] = e.NewValue.ToString().ToLower() } }); }));

        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get { return (ScrollBarVisibility)GetValue(VScrollBarVisibilityProperty); }
            set { SetValue(VScrollBarVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HScrollBarVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VScrollBarVisibilityProperty =
            DependencyProperty.Register(nameof(VerticalScrollBarVisibility), typeof(ScrollBarVisibility), typeof(MonacoEditor), new PropertyMetadata(ScrollBarVisibility.Auto, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["scrollbar"] = new Dictionary<string, object> { ["vertical"] = e.NewValue.ToString().ToLower() } }); }));

        public bool ShowStickyScroll
        {
            get { return (bool)GetValue(ShowStickyScrollProperty); }
            set { SetValue(ShowStickyScrollProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowStickyScroll.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowStickyScrollProperty =
            DependencyProperty.Register(nameof(ShowStickyScroll), typeof(bool), typeof(MonacoEditor), new PropertyMetadata(true, async (o, e) => { await (o as MonacoEditor)?.editorWrapper.UpdateOptions(new Dictionary<string, object> { ["stickyScroll"] = new Dictionary<string, object> { ["enabled"] = e.NewValue } }); }));


        public async Task<string> GetEditorOptions() => await editorWrapper.GetRowOptions();
        public async Task<List<string>> GetLanguages() => await editorWrapper.GetLanguages();
        public async Task Focus() => await editorWrapper.ExecuteScriptAsync("editor.focus();");

        public async Task<Position> GetPosition() => await editorWrapper.GetPosion();
        public async Task SetPosition(Position position) => await editorWrapper.SetPosion(position);
        public async Task<string> GetSelection() => await editorWrapper.GetSelection();
        public async Task SetSelection(Selection selection) => await editorWrapper.SetSelection(selection);
        public async Task SelectAll() { await Focus(); await editorWrapper.SelectAll(); }
        public async Task Clear() => Text = string.Empty;
        public async Task Format() => await editorWrapper.FormatText();
        public async Task GoToLine(int line) => await editorWrapper.GoToLine(line);
        public async Task GoToPosition(Position position) => await editorWrapper.GoToPosition(position);
        public async Task GoToRange(Range range) => await editorWrapper.GoToRange(range);
        public async Task InsertText(string value, Range range) => await editorWrapper.Insert(value, range);

        public async Task ExecuteEditCommand(string command, Dictionary<string, object> param) => await editorWrapper.ExecuteEditCommand(command, param);
        public async Task ExecuteTrigger(string source, string func, object args = null) => await editorWrapper.ExecuteTrigger(source, func, args);

        public MonacoEditor()
        {
            IWebView2 webView2 = new WebView2();
            editorWrapper = new MonacoEditorWrapper(webView2);
            Content = webView2;

            Loaded += async (_, _) =>
            {
                await editorWrapper.Initialize();
                await editorWrapper.SetText(Text);
                await editorWrapper.SetTheme(Theme);
            };

            BindingEvent();
        }

        private void BindingEvent()
        {
            editorWrapper.OnContentChanged = async e =>
            {
                ContentChanged?.Invoke(editorWrapper, e);
                innerChange = true;
                SetCurrentValue(TextProperty, await editorWrapper.GetText());
                innerChange = false;
            };
            editorWrapper.OnCursorPositionChanged = e => CursorPositionChanged?.Invoke(editorWrapper, e);
            editorWrapper.OnSelectionChanged = e => SelectionChanged?.Invoke(editorWrapper, e);
            editorWrapper.OnEditorFocused = () => EditorFocused?.Invoke(editorWrapper, null);
            editorWrapper.OnEditorBlurred = () => EditorBlurred?.Invoke(editorWrapper, null);
            editorWrapper.OnEditorWidgetFocused = () => EditorWidgetFocused?.Invoke(editorWrapper, null);
            editorWrapper.OnEditorWidgetBlurred = () => EditorWidgetBlurred?.Invoke(editorWrapper, null);
            editorWrapper.OnMouseDown = e => EditorMouseDown?.Invoke(editorWrapper, e);
            editorWrapper.OnMouseUp = e => EditorMouseUp?.Invoke(editorWrapper, e);
            editorWrapper.OnKeyDown = e => EditorKeyDown?.Invoke(editorWrapper, e);
            editorWrapper.OnKeyUp = e => EditorKeyUp?.Invoke(editorWrapper, e);
            editorWrapper.OnPaste = e => EditorPaste?.Invoke(editorWrapper, e);
            editorWrapper.OnLanguageChanged = e => LanguageChanged?.Invoke(editorWrapper, e);
            editorWrapper.OnScrollChanged = e => ScrollChanged?.Invoke(editorWrapper, e);
            editorWrapper.OnConfigurationChanged = (e) => ConfigurationChanged?.Invoke(editorWrapper, e);
        }

        #region EventHandler

        public event EventHandler<string>? TextChanged;
        public event EventHandler<ContentChangedEventArgs> ContentChanged;
        public event EventHandler<CursorPositionChangedEventArgs> CursorPositionChanged;
        public event EventHandler<SelectionChangedEventArgs> SelectionChanged;

        public event EventHandler EditorFocused;
        public event EventHandler EditorBlurred;
        public event EventHandler EditorWidgetFocused;
        public event EventHandler EditorWidgetBlurred;

        public event EventHandler<MouseEventArgs> EditorMouseDown;
        public event EventHandler<MouseEventArgs> EditorMouseUp;

        public event EventHandler<KeyboardEventArgs> EditorKeyDown;
        public event EventHandler<KeyboardEventArgs> EditorKeyUp;
        public event EventHandler<PasteEventArgs> EditorPaste;

        public event EventHandler<LanguageChangedEventArgs> LanguageChanged;

        public event EventHandler<ScrollChangedEventArgs> ScrollChanged;
        public event EventHandler<Dictionary<string, object>> ConfigurationChanged;

        #endregion

        public void Dispose()
        {
            editorWrapper.Dispose();
        }
    }
}