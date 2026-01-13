// ----------------------------------------------------------------
// Copyright ©2026 IceSky All Rights Reserved.
// Author: IceSky
// IceSky App Doc: https://iceskydev.github.io/AppDoc/
// ----------------------------------------------------------------
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using System.Text;

namespace WPFMonaco
{
    public class BracketPairColorization
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("independentColorPoolPerBracketType")]
        public bool IndependentColorPoolPerBracketType { get; set; }
    }

    public class Guides
    {
        [JsonProperty("bracketPairs")]
        public bool BracketPairs { get; set; }

        [JsonProperty("bracketPairsHorizontal")]
        public string BracketPairsHorizontal { get; set; }

        [JsonProperty("highlightActiveBracketPair")]
        public bool HighlightActiveBracketPair { get; set; }

        [JsonProperty("indentation")]
        public bool Indentation { get; set; }

        [JsonProperty("highlightActiveIndentation")]
        public bool HighlightActiveIndentation { get; set; }
    }

    public class Comments
    {
        [JsonProperty("insertSpace")]
        public bool InsertSpace { get; set; }

        [JsonProperty("ignoreEmptyLines")]
        public bool IgnoreEmptyLines { get; set; }
    }

    public class DropIntoEditor
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("showDropSelector")]
        public string ShowDropSelector { get; set; }
    }

    public class Find
    {
        [JsonProperty("cursorMoveOnType")]
        public bool CursorMoveOnType { get; set; }

        [JsonProperty("findOnType")]
        public bool FindOnType { get; set; }

        [JsonProperty("seedSearchStringFromSelection")]
        public string SeedSearchStringFromSelection { get; set; }

        [JsonProperty("autoFindInSelection")]
        public string AutoFindInSelection { get; set; }

        [JsonProperty("globalFindClipboard")]
        public bool GlobalFindClipboard { get; set; }

        [JsonProperty("addExtraSpaceOnTop")]
        public bool AddExtraSpaceOnTop { get; set; }

        [JsonProperty("loop")]
        public bool Loop { get; set; }

        [JsonProperty("history")]
        public string History { get; set; }

        [JsonProperty("replaceHistory")]
        public string ReplaceHistory { get; set; }
    }

    public class FontInfo
    {
        [JsonProperty("pixelRatio")]
        public double PixelRatio { get; set; }

        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontFeatureSettings")]
        public string FontFeatureSettings { get; set; }

        [JsonProperty("fontVariationSettings")]
        public string FontVariationSettings { get; set; }

        [JsonProperty("lineHeight")]
        public int LineHeight { get; set; }

        [JsonProperty("letterSpacing")]
        public int LetterSpacing { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("isTrusted")]
        public bool IsTrusted { get; set; }

        [JsonProperty("isMonospace")]
        public bool IsMonospace { get; set; }

        [JsonProperty("typicalHalfwidthCharacterWidth")]
        public double TypicalHalfwidthCharacterWidth { get; set; }

        [JsonProperty("typicalFullwidthCharacterWidth")]
        public double TypicalFullwidthCharacterWidth { get; set; }

        [JsonProperty("canUseHalfwidthRightwardsArrow")]
        public bool CanUseHalfwidthRightwardsArrow { get; set; }

        [JsonProperty("spaceWidth")]
        public double SpaceWidth { get; set; }

        [JsonProperty("middotWidth")]
        public double MiddotWidth { get; set; }

        [JsonProperty("wsmiddotWidth")]
        public double WsmiddotWidth { get; set; }

        [JsonProperty("maxDigitWidth")]
        public double MaxDigitWidth { get; set; }
    }

    public class GotoLocation
    {
        [JsonProperty("multiple")]
        public string Multiple { get; set; }

        [JsonProperty("multipleDefinitions")]
        public string MultipleDefinitions { get; set; }

        [JsonProperty("multipleTypeDefinitions")]
        public string MultipleTypeDefinitions { get; set; }

        [JsonProperty("multipleDeclarations")]
        public string MultipleDeclarations { get; set; }

        [JsonProperty("multipleImplementations")]
        public string MultipleImplementations { get; set; }

        [JsonProperty("multipleReferences")]
        public string MultipleReferences { get; set; }

        [JsonProperty("multipleTests")]
        public string MultipleTests { get; set; }

        [JsonProperty("alternativeDefinitionCommand")]
        public string AlternativeDefinitionCommand { get; set; }

        [JsonProperty("alternativeTypeDefinitionCommand")]
        public string AlternativeTypeDefinitionCommand { get; set; }

        [JsonProperty("alternativeDeclarationCommand")]
        public string AlternativeDeclarationCommand { get; set; }

        [JsonProperty("alternativeImplementationCommand")]
        public string AlternativeImplementationCommand { get; set; }

        [JsonProperty("alternativeReferenceCommand")]
        public string AlternativeReferenceCommand { get; set; }

        [JsonProperty("alternativeTestsCommand")]
        public string AlternativeTestsCommand { get; set; }
    }

    public class Hover
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("delay")]
        public int Delay { get; set; }

        [JsonProperty("hidingDelay")]
        public int HidingDelay { get; set; }

        [JsonProperty("sticky")]
        public bool Sticky { get; set; }

        [JsonProperty("above")]
        public bool Above { get; set; }
    }

    public class InlineSuggest
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("mode")]
        public string Mode { get; set; }

        [JsonProperty("showToolbar")]
        public string ShowToolbar { get; set; }

        [JsonProperty("suppressSuggestions")]
        public bool SuppressSuggestions { get; set; }

        [JsonProperty("keepOnBlur")]
        public bool KeepOnBlur { get; set; }

        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("syntaxHighlightingEnabled")]
        public bool SyntaxHighlightingEnabled { get; set; }

        [JsonProperty("minShowDelay")]
        public int MinShowDelay { get; set; }

        [JsonProperty("suppressInSnippetMode")]
        public bool SuppressInSnippetMode { get; set; }

        [JsonProperty("edits")]
        public Edits Edits { get; set; } = new Edits();

        [JsonProperty("triggerCommandOnProviderChange")]
        public bool TriggerCommandOnProviderChange { get; set; }

        [JsonProperty("experimental")]
        public Experimental Experimental { get; set; } = new Experimental();
    }

    public class Edits
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("showCollapsed")]
        public bool ShowCollapsed { get; set; }

        [JsonProperty("renderSideBySide")]
        public string RenderSideBySide { get; set; }

        [JsonProperty("allowCodeShifting")]
        public string AllowCodeShifting { get; set; }
    }

    public class Experimental
    {
        [JsonProperty("suppressInlineSuggestions")]
        public string SuppressInlineSuggestions { get; set; }

        [JsonProperty("showOnSuggestConflict")]
        public string ShowOnSuggestConflict { get; set; }

        [JsonProperty("emptyResponseInformation")]
        public bool EmptyResponseInformation { get; set; }
    }

    public class LineNumbers
    {
        [JsonProperty("renderType")]
        public int RenderType { get; set; }

        [JsonProperty("renderFn")]
        public object RenderFn { get; set; }
    }

    public class Minimap
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("size")]
        public string Size { get; set; }

        [JsonProperty("side")]
        public string Side { get; set; }

        [JsonProperty("showSlider")]
        public string ShowSlider { get; set; }

        [JsonProperty("autohide")]
        public string Autohide { get; set; }

        [JsonProperty("renderCharacters")]
        public bool RenderCharacters { get; set; }

        [JsonProperty("maxColumn")]
        public int MaxColumn { get; set; }

        [JsonProperty("scale")]
        public int Scale { get; set; }

        [JsonProperty("showRegionSectionHeaders")]
        public bool ShowRegionSectionHeaders { get; set; }

        [JsonProperty("showMarkSectionHeaders")]
        public bool ShowMarkSectionHeaders { get; set; }

        [JsonProperty("markSectionHeaderRegex")]
        public string MarkSectionHeaderRegex { get; set; }

        [JsonProperty("sectionHeaderFontSize")]
        public int SectionHeaderFontSize { get; set; }

        [JsonProperty("sectionHeaderLetterSpacing")]
        public int SectionHeaderLetterSpacing { get; set; }
    }

    public class Padding
    {
        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("bottom")]
        public int Bottom { get; set; }
    }

    public class PasteAs
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("showPasteSelector")]
        public string ShowPasteSelector { get; set; }
    }

    public class ParameterHints
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("cycle")]
        public bool Cycle { get; set; }
    }

    public class QuickSuggestions
    {
        [JsonProperty("other")]
        public string Other { get; set; }

        [JsonProperty("comments")]
        public string Comments { get; set; }

        [JsonProperty("strings")]
        public string Strings { get; set; }
    }

    public class Scrollbar
    {
        [JsonProperty("vertical")]
        public int Vertical { get; set; }

        [JsonProperty("horizontal")]
        public int Horizontal { get; set; }

        [JsonProperty("arrowSize")]
        public int ArrowSize { get; set; }

        [JsonProperty("useShadows")]
        public bool UseShadows { get; set; }

        [JsonProperty("verticalHasArrows")]
        public bool VerticalHasArrows { get; set; }

        [JsonProperty("horizontalHasArrows")]
        public bool HorizontalHasArrows { get; set; }

        [JsonProperty("horizontalScrollbarSize")]
        public int HorizontalScrollbarSize { get; set; }

        [JsonProperty("horizontalSliderSize")]
        public int HorizontalSliderSize { get; set; }

        [JsonProperty("verticalScrollbarSize")]
        public int VerticalScrollbarSize { get; set; }

        [JsonProperty("verticalSliderSize")]
        public int VerticalSliderSize { get; set; }

        [JsonProperty("handleMouseWheel")]
        public bool HandleMouseWheel { get; set; }

        [JsonProperty("alwaysConsumeMouseWheel")]
        public bool AlwaysConsumeMouseWheel { get; set; }

        [JsonProperty("scrollByPage")]
        public bool ScrollByPage { get; set; }

        [JsonProperty("ignoreHorizontalScrollbarInContentHeight")]
        public bool IgnoreHorizontalScrollbarInContentHeight { get; set; }
    }

    public class SmartSelect
    {
        [JsonProperty("selectLeadingAndTrailingWhitespace")]
        public bool SelectLeadingAndTrailingWhitespace { get; set; }

        [JsonProperty("selectSubwords")]
        public bool SelectSubwords { get; set; }
    }

    public class StickyScroll
    {
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("maxLineCount")]
        public int MaxLineCount { get; set; }

        [JsonProperty("defaultModel")]
        public string DefaultModel { get; set; }

        [JsonProperty("scrollWithEditor")]
        public bool ScrollWithEditor { get; set; }
    }

    public class Suggest
    {
        [JsonProperty("insertMode")]
        public string InsertMode { get; set; }

        [JsonProperty("filterGraceful")]
        public bool FilterGraceful { get; set; }

        [JsonProperty("snippetsPreventQuickSuggestions")]
        public bool SnippetsPreventQuickSuggestions { get; set; }

        [JsonProperty("localityBonus")]
        public bool LocalityBonus { get; set; }

        [JsonProperty("shareSuggestSelections")]
        public bool ShareSuggestSelections { get; set; }

        [JsonProperty("selectionMode")]
        public string SelectionMode { get; set; }

        [JsonProperty("showIcons")]
        public bool ShowIcons { get; set; }

        [JsonProperty("showStatusBar")]
        public bool ShowStatusBar { get; set; }

        [JsonProperty("preview")]
        public bool Preview { get; set; }

        [JsonProperty("previewMode")]
        public string PreviewMode { get; set; }

        [JsonProperty("showInlineDetails")]
        public bool ShowInlineDetails { get; set; }

        [JsonProperty("showMethods")]
        public bool ShowMethods { get; set; }

        [JsonProperty("showFunctions")]
        public bool ShowFunctions { get; set; }

        [JsonProperty("showConstructors")]
        public bool ShowConstructors { get; set; }

        [JsonProperty("showDeprecated")]
        public bool ShowDeprecated { get; set; }

        [JsonProperty("matchOnWordStartOnly")]
        public bool MatchOnWordStartOnly { get; set; }

        [JsonProperty("showFields")]
        public bool ShowFields { get; set; }

        [JsonProperty("showVariables")]
        public bool ShowVariables { get; set; }

        [JsonProperty("showClasses")]
        public bool ShowClasses { get; set; }

        [JsonProperty("showStructs")]
        public bool ShowStructs { get; set; }

        [JsonProperty("showInterfaces")]
        public bool ShowInterfaces { get; set; }

        [JsonProperty("showModules")]
        public bool ShowModules { get; set; }

        [JsonProperty("showProperties")]
        public bool ShowProperties { get; set; }

        [JsonProperty("showEvents")]
        public bool ShowEvents { get; set; }

        [JsonProperty("showOperators")]
        public bool ShowOperators { get; set; }

        [JsonProperty("showUnits")]
        public bool ShowUnits { get; set; }

        [JsonProperty("showValues")]
        public bool ShowValues { get; set; }

        [JsonProperty("showConstants")]
        public bool ShowConstants { get; set; }

        [JsonProperty("showEnums")]
        public bool ShowEnums { get; set; }

        [JsonProperty("showEnumMembers")]
        public bool ShowEnumMembers { get; set; }

        [JsonProperty("showKeywords")]
        public bool ShowKeywords { get; set; }

        [JsonProperty("showWords")]
        public bool ShowWords { get; set; }

        [JsonProperty("showColors")]
        public bool ShowColors { get; set; }

        [JsonProperty("showFiles")]
        public bool ShowFiles { get; set; }

        [JsonProperty("showReferences")]
        public bool ShowReferences { get; set; }

        [JsonProperty("showFolders")]
        public bool ShowFolders { get; set; }

        [JsonProperty("showTypeParameters")]
        public bool ShowTypeParameters { get; set; }

        [JsonProperty("showSnippets")]
        public bool ShowSnippets { get; set; }

        [JsonProperty("showUsers")]
        public bool ShowUsers { get; set; }

        [JsonProperty("showIssues")]
        public bool ShowIssues { get; set; }
    }

    public class UnicodeHighlighting
    {
        [JsonProperty("nonBasicASCII")]
        public string NonBasicASCII { get; set; }

        [JsonProperty("invisibleCharacters")]
        public bool InvisibleCharacters { get; set; }

        [JsonProperty("ambiguousCharacters")]
        public bool AmbiguousCharacters { get; set; }

        [JsonProperty("includeComments")]
        public string IncludeComments { get; set; }

        [JsonProperty("includeStrings")]
        public bool IncludeStrings { get; set; }

        [JsonProperty("allowedCharacters")]
        public BracketPairColorization AllowedCharacters { get; set; } = new BracketPairColorization();

        [JsonProperty("allowedLocales")]
        public AllowedLocales AllowedLocales { get; set; } = new AllowedLocales();
    }

    public class AllowedLocales
    {
        [JsonProperty("_os")]
        public bool _os { get; set; }

        [JsonProperty("_vscode")]
        public bool _vscode { get; set; }
    }

    public class InlayHints
    {
        [JsonProperty("enabled")]
        public string Enabled { get; set; }

        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("padding")]
        public bool Padding { get; set; }

        [JsonProperty("maximumLength")]
        public int MaximumLength { get; set; }
    }

    public class LayoutInfo
    {
        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("glyphMarginLeft")]
        public int GlyphMarginLeft { get; set; }

        [JsonProperty("glyphMarginWidth")]
        public int GlyphMarginWidth { get; set; }

        [JsonProperty("glyphMarginDecorationLaneCount")]
        public int GlyphMarginDecorationLaneCount { get; set; }

        [JsonProperty("lineNumbersLeft")]
        public int LineNumbersLeft { get; set; }

        [JsonProperty("lineNumbersWidth")]
        public int LineNumbersWidth { get; set; }

        [JsonProperty("decorationsLeft")]
        public int DecorationsLeft { get; set; }

        [JsonProperty("decorationsWidth")]
        public int DecorationsWidth { get; set; }

        [JsonProperty("contentLeft")]
        public int ContentLeft { get; set; }

        [JsonProperty("contentWidth")]
        public int ContentWidth { get; set; }

        [JsonProperty("minimap")]
        public Anonymous26 Minimap { get; set; } = new Anonymous26();

        [JsonProperty("viewportColumn")]
        public int ViewportColumn { get; set; }

        [JsonProperty("isWordWrapMinified")]
        public bool IsWordWrapMinified { get; set; }

        [JsonProperty("isViewportWrapping")]
        public bool IsViewportWrapping { get; set; }

        [JsonProperty("wrappingColumn")]
        public int WrappingColumn { get; set; }

        [JsonProperty("verticalScrollbarWidth")]
        public int VerticalScrollbarWidth { get; set; }

        [JsonProperty("horizontalScrollbarHeight")]
        public int HorizontalScrollbarHeight { get; set; }

        [JsonProperty("overviewRuler")]
        public OverviewRuler OverviewRuler { get; set; } = new OverviewRuler();
    }

    public class Anonymous26
    {
        [JsonProperty("renderMinimap")]
        public int RenderMinimap { get; set; }

        [JsonProperty("minimapLeft")]
        public int MinimapLeft { get; set; }

        [JsonProperty("minimapWidth")]
        public int MinimapWidth { get; set; }

        [JsonProperty("minimapHeightIsEditorHeight")]
        public bool MinimapHeightIsEditorHeight { get; set; }

        [JsonProperty("minimapIsSampling")]
        public bool MinimapIsSampling { get; set; }

        [JsonProperty("minimapScale")]
        public int MinimapScale { get; set; }

        [JsonProperty("minimapLineHeight")]
        public int MinimapLineHeight { get; set; }

        [JsonProperty("minimapCanvasInnerWidth")]
        public int MinimapCanvasInnerWidth { get; set; }

        [JsonProperty("minimapCanvasInnerHeight")]
        public int MinimapCanvasInnerHeight { get; set; }

        [JsonProperty("minimapCanvasOuterWidth")]
        public double MinimapCanvasOuterWidth { get; set; }

        [JsonProperty("minimapCanvasOuterHeight")]
        public double MinimapCanvasOuterHeight { get; set; }
    }

    public class OverviewRuler
    {
        [JsonProperty("top")]
        public int Top { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("right")]
        public int Right { get; set; }
    }

    public class WrappingInfo
    {
        [JsonProperty("isDominatedByLongLines")]
        public bool IsDominatedByLongLines { get; set; }

        [JsonProperty("isWordWrapMinified")]
        public bool IsWordWrapMinified { get; set; }

        [JsonProperty("isViewportWrapping")]
        public bool IsViewportWrapping { get; set; }

        [JsonProperty("wrappingColumn")]
        public int WrappingColumn { get; set; }
    }

    public class EditorOptions : OptionBase
    {
        private static readonly EditorOptions defaultOptions;

        static EditorOptions()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            var resourceName = $"{assembly.GetName().Name}.DefaultOptions.json";

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using StreamReader reader = new StreamReader(stream, Encoding.UTF8);
            var defaultJson = reader.ReadToEnd();

            defaultOptions = JsonConvert.DeserializeObject<EditorOptions>(defaultJson);
        }

        public EditorOptions() : base(defaultOptions)
        {
        }

        [JsonProperty("acceptSuggestionOnCommitCharacter")]
        public bool AcceptSuggestionOnCommitCharacter { get; set; }

        [JsonProperty("acceptSuggestionOnEnter")]
        public string AcceptSuggestionOnEnter { get; set; }

        [JsonProperty("accessibilitySupport")]
        public int AccessibilitySupport { get; set; }

        [JsonProperty("accessibilityPageSize")]
        public int AccessibilityPageSize { get; set; }

        [JsonProperty("allowOverflow")]
        public bool AllowOverflow { get; set; }

        [JsonProperty("allowVariableLineHeights")]
        public bool AllowVariableLineHeights { get; set; }

        [JsonProperty("allowVariableFonts")]
        public bool AllowVariableFonts { get; set; }

        [JsonProperty("allowVariableFontsInAccessibilityMode")]
        public bool AllowVariableFontsInAccessibilityMode { get; set; }

        [JsonProperty("ariaLabel")]
        public string AriaLabel { get; set; }

        [JsonProperty("ariaRequired")]
        public bool AriaRequired { get; set; }

        [JsonProperty("autoClosingBrackets")]
        public string AutoClosingBrackets { get; set; }

        [JsonProperty("autoClosingComments")]
        public string AutoClosingComments { get; set; }

        [JsonProperty("screenReaderAnnounceInlineSuggestion")]
        public bool ScreenReaderAnnounceInlineSuggestion { get; set; }

        [JsonProperty("autoClosingDelete")]
        public string AutoClosingDelete { get; set; }

        [JsonProperty("autoClosingOvertype")]
        public string AutoClosingOvertype { get; set; }

        [JsonProperty("autoClosingQuotes")]
        public string AutoClosingQuotes { get; set; }

        [JsonProperty("autoIndent")]
        public int AutoIndent { get; set; }

        [JsonProperty("autoIndentOnPaste")]
        public bool AutoIndentOnPaste { get; set; }

        [JsonProperty("autoIndentOnPasteWithinString")]
        public bool AutoIndentOnPasteWithinString { get; set; }

        [JsonProperty("automaticLayout")]
        public bool AutomaticLayout { get; set; }

        [JsonProperty("autoSurround")]
        public string AutoSurround { get; set; }

        [JsonProperty("bracketPairColorization")]
        public BracketPairColorization BracketPairColorization { get; set; } = new BracketPairColorization();

        [JsonProperty("guides")]
        public Guides Guides { get; set; } = new Guides();

        [JsonProperty("codeLens")]
        public bool CodeLens { get; set; }

        [JsonProperty("codeLensFontFamily")]
        public string CodeLensFontFamily { get; set; }

        [JsonProperty("codeLensFontSize")]
        public int CodeLensFontSize { get; set; }

        [JsonProperty("colorDecorators")]
        public bool ColorDecorators { get; set; }

        [JsonProperty("colorDecoratorsLimit")]
        public int ColorDecoratorsLimit { get; set; }

        [JsonProperty("columnSelection")]
        public bool ColumnSelection { get; set; }

        [JsonProperty("comments")]
        public Comments Comments { get; set; } = new Comments();

        [JsonProperty("contextmenu")]
        public bool Contextmenu { get; set; }

        [JsonProperty("copyWithSyntaxHighlighting")]
        public bool CopyWithSyntaxHighlighting { get; set; }

        [JsonProperty("cursorBlinking")]
        public int CursorBlinking { get; set; }

        [JsonProperty("cursorSmoothCaretAnimation")]
        public string CursorSmoothCaretAnimation { get; set; }

        [JsonProperty("cursorStyle")]
        public int CursorStyle { get; set; }

        [JsonProperty("cursorSurroundingLines")]
        public int CursorSurroundingLines { get; set; }

        [JsonProperty("cursorSurroundingLinesStyle")]
        public string CursorSurroundingLinesStyle { get; set; }

        [JsonProperty("cursorWidth")]
        public int CursorWidth { get; set; }

        [JsonProperty("cursorHeight")]
        public int CursorHeight { get; set; }

        [JsonProperty("disableLayerHinting")]
        public bool DisableLayerHinting { get; set; }

        [JsonProperty("disableMonospaceOptimizations")]
        public bool DisableMonospaceOptimizations { get; set; }

        [JsonProperty("domReadOnly")]
        public bool DomReadOnly { get; set; }

        [JsonProperty("dragAndDrop")]
        public bool DragAndDrop { get; set; }

        [JsonProperty("dropIntoEditor")]
        public DropIntoEditor DropIntoEditor { get; set; } = new DropIntoEditor();

        [JsonProperty("editContext")]
        public bool EditContext { get; set; }

        [JsonProperty("emptySelectionClipboard")]
        public bool EmptySelectionClipboard { get; set; }

        [JsonProperty("experimentalGpuAcceleration")]
        public string ExperimentalGpuAcceleration { get; set; }

        [JsonProperty("experimentalWhitespaceRendering")]
        public string ExperimentalWhitespaceRendering { get; set; }

        [JsonProperty("extraEditorClassName")]
        public string ExtraEditorClassName { get; set; }

        [JsonProperty("fastScrollSensitivity")]
        public int FastScrollSensitivity { get; set; }

        [JsonProperty("find")]
        public Find Find { get; set; }

        [JsonProperty("fixedOverflowWidgets")]
        public bool FixedOverflowWidgets { get; set; }

        [JsonProperty("folding")]
        public bool Folding { get; set; }

        [JsonProperty("foldingStrategy")]
        public string FoldingStrategy { get; set; }

        [JsonProperty("foldingHighlight")]
        public bool FoldingHighlight { get; set; }

        [JsonProperty("foldingImportsByDefault")]
        public bool FoldingImportsByDefault { get; set; }

        [JsonProperty("foldingMaximumRegions")]
        public int FoldingMaximumRegions { get; set; }

        [JsonProperty("unfoldOnClickAfterEndOfLine")]
        public bool UnfoldOnClickAfterEndOfLine { get; set; }

        [JsonProperty("fontFamily")]
        public string FontFamily { get; set; }

        [JsonProperty("fontInfo")]
        public FontInfo FontInfo { get; set; }

        [JsonProperty("fontLigatures")]
        public string FontLigatures { get; set; }

        [JsonProperty("fontSize")]
        public int FontSize { get; set; }

        [JsonProperty("fontWeight")]
        public string FontWeight { get; set; }

        [JsonProperty("fontVariations")]
        public string FontVariations { get; set; }

        [JsonProperty("formatOnPaste")]
        public bool FormatOnPaste { get; set; }

        [JsonProperty("formatOnType")]
        public bool FormatOnType { get; set; }

        [JsonProperty("glyphMargin")]
        public bool GlyphMargin { get; set; }

        [JsonProperty("gotoLocation")]
        public GotoLocation GotoLocation { get; set; } = new GotoLocation();

        [JsonProperty("hideCursorInOverviewRuler")]
        public bool HideCursorInOverviewRuler { get; set; }

        [JsonProperty("hover")]
        public Hover Hover { get; set; } = new Hover();

        [JsonProperty("inDiffEditor")]
        public bool InDiffEditor { get; set; }

        [JsonProperty("inlineSuggest")]
        public InlineSuggest InlineSuggest { get; set; } = new InlineSuggest();

        [JsonProperty("letterSpacing")]
        public int LetterSpacing { get; set; }

        [JsonProperty("lightbulb")]
        public BracketPairColorization Lightbulb { get; set; } = new BracketPairColorization();

        [JsonProperty("lineDecorationsWidth")]
        public int LineDecorationsWidth { get; set; }

        [JsonProperty("lineHeight")]
        public int LineHeight { get; set; }

        [JsonProperty("lineNumbers")]
        public LineNumbers LineNumbers { get; set; } = new LineNumbers();

        [JsonProperty("lineNumbersMinChars")]
        public int LineNumbersMinChars { get; set; }

        [JsonProperty("linkedEditing")]
        public bool LinkedEditing { get; set; }

        [JsonProperty("links")]
        public bool Links { get; set; }

        [JsonProperty("matchBrackets")]
        public string MatchBrackets { get; set; }

        [JsonProperty("minimap")]
        public Minimap Minimap { get; set; } = new Minimap();

        [JsonProperty("mouseStyle")]
        public string MouseStyle { get; set; }

        [JsonProperty("mouseWheelScrollSensitivity")]
        public int MouseWheelScrollSensitivity { get; set; }

        [JsonProperty("mouseWheelZoom")]
        public bool MouseWheelZoom { get; set; }

        [JsonProperty("multiCursorMergeOverlapping")]
        public bool MultiCursorMergeOverlapping { get; set; }

        [JsonProperty("multiCursorModifier")]
        public string MultiCursorModifier { get; set; }

        [JsonProperty("mouseMiddleClickAction")]
        public string MouseMiddleClickAction { get; set; }

        [JsonProperty("multiCursorPaste")]
        public string MultiCursorPaste { get; set; }

        [JsonProperty("multiCursorLimit")]
        public int MultiCursorLimit { get; set; }

        [JsonProperty("occurrencesHighlight")]
        public string OccurrencesHighlight { get; set; }

        [JsonProperty("occurrencesHighlightDelay")]
        public int OccurrencesHighlightDelay { get; set; }

        [JsonProperty("overtypeCursorStyle")]
        public int OvertypeCursorStyle { get; set; }

        [JsonProperty("overtypeOnPaste")]
        public bool OvertypeOnPaste { get; set; }

        [JsonProperty("overviewRulerBorder")]
        public bool OverviewRulerBorder { get; set; }

        [JsonProperty("overviewRulerLanes")]
        public int OverviewRulerLanes { get; set; }

        [JsonProperty("padding")]
        public Padding Padding { get; set; } = new Padding();

        [JsonProperty("pasteAs")]
        public PasteAs PasteAs { get; set; } = new PasteAs();

        [JsonProperty("parameterHints")]
        public ParameterHints ParameterHints { get; set; } = new ParameterHints();

        [JsonProperty("peekWidgetDefaultFocus")]
        public string PeekWidgetDefaultFocus { get; set; }

        [JsonProperty("definitionLinkOpensInPeek")]
        public bool DefinitionLinkOpensInPeek { get; set; }

        [JsonProperty("quickSuggestions")]
        public QuickSuggestions QuickSuggestions { get; set; } = new QuickSuggestions();

        [JsonProperty("quickSuggestionsDelay")]
        public int QuickSuggestionsDelay { get; set; }

        [JsonProperty("readOnly")]
        public bool ReadOnly { get; set; }

        [JsonProperty("renameOnType")]
        public bool RenameOnType { get; set; }

        [JsonProperty("renderRichScreenReaderContent")]
        public bool RenderRichScreenReaderContent { get; set; }

        [JsonProperty("renderControlCharacters")]
        public bool RenderControlCharacters { get; set; }

        [JsonProperty("renderFinalNewline")]
        public string RenderFinalNewline { get; set; }

        [JsonProperty("renderLineHighlight")]
        public string RenderLineHighlight { get; set; }

        [JsonProperty("renderLineHighlightOnlyWhenFocus")]
        public bool RenderLineHighlightOnlyWhenFocus { get; set; }

        [JsonProperty("renderValidationDecorations")]
        public string RenderValidationDecorations { get; set; }

        [JsonProperty("renderWhitespace")]
        public string RenderWhitespace { get; set; }

        [JsonProperty("revealHorizontalRightPadding")]
        public int RevealHorizontalRightPadding { get; set; }

        [JsonProperty("roundedSelection")]
        public bool RoundedSelection { get; set; }

        [JsonProperty("rulers")]
        public List<object> Rulers { get; set; }

        [JsonProperty("scrollbar")]
        public Scrollbar Scrollbar { get; set; } = new Scrollbar();

        [JsonProperty("scrollBeyondLastColumn")]
        public int ScrollBeyondLastColumn { get; set; }

        [JsonProperty("scrollBeyondLastLine")]
        public bool ScrollBeyondLastLine { get; set; }

        [JsonProperty("scrollPredominantAxis")]
        public bool ScrollPredominantAxis { get; set; }

        [JsonProperty("selectionClipboard")]
        public bool SelectionClipboard { get; set; }

        [JsonProperty("selectionHighlight")]
        public bool SelectionHighlight { get; set; }

        [JsonProperty("selectionHighlightMaxLength")]
        public int SelectionHighlightMaxLength { get; set; }

        [JsonProperty("selectionHighlightMultiline")]
        public bool SelectionHighlightMultiline { get; set; }

        [JsonProperty("selectOnLineNumbers")]
        public bool SelectOnLineNumbers { get; set; }

        [JsonProperty("showFoldingControls")]
        public string ShowFoldingControls { get; set; }

        [JsonProperty("showUnused")]
        public bool ShowUnused { get; set; }

        [JsonProperty("snippetSuggestions")]
        public string SnippetSuggestions { get; set; }

        [JsonProperty("smartSelect")]
        public SmartSelect SmartSelect { get; set; } = new SmartSelect();

        [JsonProperty("smoothScrolling")]
        public bool SmoothScrolling { get; set; }

        [JsonProperty("stickyScroll")]
        public StickyScroll StickyScroll { get; set; } = new StickyScroll();

        [JsonProperty("stickyTabStops")]
        public bool StickyTabStops { get; set; }

        [JsonProperty("stopRenderingLineAfter")]
        public int StopRenderingLineAfter { get; set; }

        [JsonProperty("suggest")]
        public Suggest Suggest { get; set; } = new Suggest();

        [JsonProperty("suggestFontSize")]
        public int SuggestFontSize { get; set; }

        [JsonProperty("suggestLineHeight")]
        public int SuggestLineHeight { get; set; }

        [JsonProperty("suggestOnTriggerCharacters")]
        public bool SuggestOnTriggerCharacters { get; set; }

        [JsonProperty("suggestSelection")]
        public string SuggestSelection { get; set; }

        [JsonProperty("tabCompletion")]
        public string TabCompletion { get; set; }

        [JsonProperty("tabIndex")]
        public int TabIndex { get; set; }

        [JsonProperty("trimWhitespaceOnDelete")]
        public bool TrimWhitespaceOnDelete { get; set; }

        [JsonProperty("unicodeHighlighting")]
        public UnicodeHighlighting UnicodeHighlighting { get; set; } = new UnicodeHighlighting();

        [JsonProperty("unusualLineTerminators")]
        public string UnusualLineTerminators { get; set; }

        [JsonProperty("useShadowDOM")]
        public bool UseShadowDOM { get; set; }

        [JsonProperty("useTabStops")]
        public bool UseTabStops { get; set; }

        [JsonProperty("wordBreak")]
        public string WordBreak { get; set; }

        [JsonProperty("wordSegmenterLocales")]
        public List<object> WordSegmenterLocales { get; set; } = new List<object>();

        [JsonProperty("wordSeparators")]
        public string WordSeparators { get; set; }

        [JsonProperty("wordWrap")]
        public string WordWrap { get; set; }

        [JsonProperty("wordWrapBreakAfterCharacters")]
        public string WordWrapBreakAfterCharacters { get; set; }

        [JsonProperty("wordWrapBreakBeforeCharacters")]
        public string WordWrapBreakBeforeCharacters { get; set; }

        [JsonProperty("wordWrapColumn")]
        public int WordWrapColumn { get; set; }

        [JsonProperty("wordWrapOverride1")]
        public string WordWrapOverride1 { get; set; }

        [JsonProperty("wordWrapOverride2")]
        public string WordWrapOverride2 { get; set; }

        [JsonProperty("wrappingIndent")]
        public int WrappingIndent { get; set; }

        [JsonProperty("wrappingStrategy")]
        public string WrappingStrategy { get; set; }

        [JsonProperty("showDeprecated")]
        public bool ShowDeprecated { get; set; }

        [JsonProperty("inertialScroll")]
        public bool InertialScroll { get; set; }

        [JsonProperty("inlayHints")]
        public InlayHints InlayHints { get; set; } = new InlayHints();

        [JsonProperty("wrapOnEscapedLineFeeds")]
        public bool WrapOnEscapedLineFeeds { get; set; }

        [JsonProperty("effectiveCursorStyle")]
        public int EffectiveCursorStyle { get; set; }

        [JsonProperty("editorClassName")]
        public string EditorClassName { get; set; }

        [JsonProperty("pixelRatio")]
        public double PixelRatio { get; set; }

        [JsonProperty("tabFocusMode")]
        public bool TabFocusMode { get; set; }

        [JsonProperty("layoutInfo")]
        public LayoutInfo LayoutInfo { get; set; } = new LayoutInfo();

        [JsonProperty("wrappingInfo")]
        public WrappingInfo WrappingInfo { get; set; }

        [JsonProperty("defaultColorDecorators")]
        public string DefaultColorDecorators { get; set; }

        [JsonProperty("colorDecoratorsActivatedOn")]
        public string ColorDecoratorsActivatedOn { get; set; }

        [JsonProperty("inlineCompletionsAccessibilityVerbose")]
        public bool InlineCompletionsAccessibilityVerbose { get; set; }

        [JsonProperty("effectiveEditContext")]
        public bool EffectiveEditContext { get; set; }

        [JsonProperty("scrollOnMiddleClick")]
        public bool ScrollOnMiddleClick { get; set; }

        [JsonProperty("effectiveAllowVariableFonts")]
        public bool EffectiveAllowVariableFonts { get; set; }
    }
}
