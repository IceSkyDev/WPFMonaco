using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WPFMonaco
{
    public class EditorReadyEventArgs : EventArgs
    {
        public string EditorId { get; set; }
    }

    public class ContentChangedEventArgs : EventArgs
    {
        [JsonPropertyName("changes")]
        public List<ModelChange> Changes { get; set; }

        [JsonPropertyName("isFlush")]
        public bool IsFlush { get; set; }

        [JsonPropertyName("eol")]
        public string Eol { get; set; }

        [JsonPropertyName("versionId")]
        public int VersionId { get; set; }
        [JsonPropertyName("isRedoing")]
        public bool IsRedoing { get; set; }
        [JsonPropertyName("isUndoing")]
        public bool IsUndoing { get; set; }
    }

    public class ModelChange
    {
        [JsonPropertyName("range")]
        public Range Range { get; set; }

        [JsonPropertyName("rangeOffset")]
        public int RangeOffset { get; set; }

        [JsonPropertyName("rangeLength")]
        public int RangeLength { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }

    public class Range
    {
        [JsonPropertyName("startLineNumber")]
        public int StartLineNumber { get; set; }

        [JsonPropertyName("startColumn")]
        public int StartColumn { get; set; }

        [JsonPropertyName("endLineNumber")]
        public int EndLineNumber { get; set; }

        [JsonPropertyName("endColumn")]
        public int EndColumn { get; set; }
    }

    public class Position
    {
        [JsonPropertyName("lineNumber")]
        public int LineNumber { get; set; }

        [JsonPropertyName("column")]
        public int Column { get; set; }
    }

    public class CursorPositionChangedEventArgs : EventArgs
    {
        [JsonPropertyName("position")]
        public Position Position { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }

    public class SelectionChangedEventArgs : EventArgs
    {
        [JsonPropertyName("selection")]
        public Selection Selection { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

        [JsonPropertyName("source")]
        public string Source { get; set; }
    }

    public class Selection : Range
    {
        // 继承Range的所有属性
    }

    public class MouseEventArgs : EventArgs
    {
        [JsonPropertyName("target")]
        public string Target { get; set; }

        [JsonPropertyName("event")]
        public MouseEvent Event { get; set; }
    }

    public class MouseEvent
    {
        [JsonPropertyName("posx")]
        public int PosX { get; set; }

        [JsonPropertyName("posy")]
        public int PosY { get; set; }

        [JsonPropertyName("clientX")]
        public int ClientX { get; set; }

        [JsonPropertyName("clientY")]
        public int ClientY { get; set; }

        [JsonPropertyName("buttons")]
        public int Button { get; set; }
        [JsonPropertyName("leftButton")]
        public bool LeftButton { get; set; }
        [JsonPropertyName("middleButton")]
        public bool MiddleButton { get; set; }
        [JsonPropertyName("rightButton")]
        public bool RightButton { get; set; }
    }

    public class KeyboardEventArgs : EventArgs
    {
        [JsonPropertyName("key")]
        public string Key { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("keyCode")]
        public int KeyCode { get; set; }

        [JsonPropertyName("ctrlKey")]
        public bool CtrlKey { get; set; }

        [JsonPropertyName("shiftKey")]
        public bool ShiftKey { get; set; }

        [JsonPropertyName("altKey")]
        public bool AltKey { get; set; }

        [JsonPropertyName("metaKey")]
        public bool MetaKey { get; set; }
    }

    public class PasteEventArgs : EventArgs
    {
        [JsonPropertyName("range")]
        public Range Range { get; set; }
    }

    public class ScrollChangedEventArgs : EventArgs
    {
        [JsonPropertyName("scrollTop")]
        public int ScrollTop { get; set; }

        [JsonPropertyName("scrollLeft")]
        public int ScrollLeft { get; set; }

        [JsonPropertyName("scrollWidth")]
        public int ScrollWidth { get; set; }

        [JsonPropertyName("scrollHeight")]
        public int ScrollHeight { get; set; }
    }

    public class LanguageChangedEventArgs : EventArgs
    {
        [JsonPropertyName("oldLanguage")]
        public string OldLanguage { get; set; }

        [JsonPropertyName("newLanguage")]
        public string NewLanguage { get; set; }
    }

    public class ThemeChangedEventArgs : EventArgs
    {
        public string Theme { get; set; }
    }

    public class ErrorEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
