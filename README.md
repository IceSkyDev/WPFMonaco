# WPFMonaco
A fully-featured WPF wrapper control for Microsoft's Monaco editor (the code editor that powers VS Code), built on WebView2.

**Recommended Windows apps**
[https://iceskydev.github.io/AppDoc/](https://iceskydev.github.io/AppDoc/)

## ✨ Features
* Monaco option:
  * Theme
  * ModelLanguage
  * ReadOnly
  * FontSize
  * MinimapEnabled
  * TabSize
  * WordWrap
  * LineNumber
  * LineHeight
  * Folding
  * StickyScroll
* Monaco method:
  * GetLanguages
  * GetText
  * SetText
  * GetPosition
  * SetPosition
  * GetSelection
  * SetSelection
  * Focus
  * Format
  * Clear
* Monaco event:
  * ContentChanged
  * CursorPositionChanged
  * SelectionChanged
  * EditorFocused
  * EditorBlurred
  * MouseDown
  * MouseUp
  * KeyDown
  * KeyUp
  * LanguageChanged
  * ScrollChanged
 
## 📦 Installation
**Prerequisites**
* .NET 8.0 or later
* Microsoft Edge WebView2 Runtime installed
* Visual Studio 2022 or later (recommended)

## 🚀 Quick Start
**Basic Usage**
``` xml
<Window xmlns:editor="clr-namespace:WPFMonaco;assembly=WPFMonaco">
  ...
  <editor:MonacoEditor />
  ...
</Window>
```

## 🛠️ Building from Source ##
**Requirements**
* Visual Studio 2022
* .NET 8.0 SDK
* WebView2 Runtime

**Steps**
1. Clone the repository
2. Open MonacoEditor.Wpf.sln
3. Build the solution
4. Reference the output assembly in your project

## 🔗 Useful Links ##
* [Monaco Editor Documentation](https://microsoft.github.io/monaco-editor/)
* [WebView2 Documentation](https://docs.microsoft.com/en-us/microsoft-edge/webview2/)

