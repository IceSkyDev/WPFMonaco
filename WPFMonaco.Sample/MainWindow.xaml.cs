// ----------------------------------------------------------------
// Copyright ©2026 IceSky All Rights Reserved.
// Author: IceSky
// IceSky App Doc: https://iceskydev.github.io/AppDoc/
// ----------------------------------------------------------------
using Microsoft.Win32;
using Newtonsoft.Json;
using System.IO;
using System.Windows;

namespace WPFMonaco.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Closing += (o, e) => tbMonaco.Dispose();
            Loaded += async (o, e) => cbLang.ItemsSource = (await tbMonaco.GetLanguages()).OrderBy(l => l);
            btnOpen.Click += async (o, e) =>
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    tbMonaco.Text = await File.ReadAllTextAsync(dialog.FileName);
                }
            };
            btnSave.Click += async (o, e) =>
            {
                var dialog = new SaveFileDialog();

                if (dialog.ShowDialog() == true)
                {
                    await File.WriteAllTextAsync(dialog.FileName, tbMonaco.Text);
                }
            };
            btnClearLog.Click += (o, e) => tbLog.Text = string.Empty;
            btnOption.Click += async (o, e) => tbLog.Text = await tbMonaco.GetEditorOptions();
            tbMonaco.TextChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---TextChanged---:\r\n {e}");
            tbMonaco.ContentChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---ContentChanged---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.CursorPositionChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---CursorPositionChanged---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.SelectionChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---SelectionChanged---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorFocused += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---EditorFocused---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorBlurred += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---EditorBlurred---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorMouseDown += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---MouseDown---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorMouseUp += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---MouseUp---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorKeyDown += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---KeyDown---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorKeyUp += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---KeyUp---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.EditorPaste += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---Paste---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.LanguageChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---LanguageChanged---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.ScrollChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---ScrollChanged---:\r\n {JsonConvert.SerializeObject(e)}");
            tbMonaco.ConfigurationChanged += (o, e) => tbLog.Text = tbLog.Text.Insert(0, $"\r\n---ConfigurationChanged---:\r\n {JsonConvert.SerializeObject(e)}");

            btnFocus.Click += async (o, e) => await tbMonaco.Focus();
            btnClear.Click += async (o, e) => await tbMonaco.Clear();
            btnFormat.Click += async (o, e) => await tbMonaco.Format();
            btnGetPos.Click += async (o, e) => tbLog.Text = JsonConvert.SerializeObject(await tbMonaco.GetPosition());
            btnSetPos.Click += async (o, e) => await tbMonaco.SetPosition(new Position { LineNumber = 2, Column = 3 });
            btnGetSel.Click += async (o, e) => tbLog.Text = await tbMonaco.GetSelection();
            btnSetSel.Click += async (o, e) => await tbMonaco.SetSelection(new Selection { StartLineNumber = 2, StartColumn = 2, EndLineNumber = 3, EndColumn = 3 });
            btnSelAll.Click += async (o, e) => await tbMonaco.SelectAll();
            btnGotoLine.Click += async (o, e) => await tbMonaco.GoToLine(2);
            btnGotoPos.Click += async (o, e) => await tbMonaco.GoToPosition(new Position { LineNumber = 20, Column = 30 });
            btnGotoRange.Click += async (o, e) => await tbMonaco.GoToRange(new Range { StartLineNumber = 5, StartColumn = 3, EndLineNumber = 8, EndColumn = 6 });
            btnInstText.Click += async (o, e) => await tbMonaco.InsertText("IceSky", new Range { StartLineNumber = 1, StartColumn = 3, EndLineNumber = 1, EndColumn = 6 });

            btnIndent.Click += async (o, e) => await tbMonaco.ExecuteTrigger("script", "editor.action.indentLines");
            btnOutdent.Click += async (o, e) => await tbMonaco.ExecuteTrigger("script", "editor.action.outdentLines");
            btnFold.Click += async (o, e) => await tbMonaco.ExecuteTrigger("editor", "editor.fold");
            btnUnfold.Click += async (o, e) => await tbMonaco.ExecuteTrigger("editor", "editor.unfold");
            btnDupLine.Click += async (o, e) => await tbMonaco.ExecuteTrigger("editor", "editor.action.copyLinesUpAction");
            btnComment.Click += async (o, e) => await tbMonaco.ExecuteTrigger("editor", "editor.action.commentLine");
            btnTypeA.Click += async (o, e) => await tbMonaco.ExecuteTrigger("keyboard", "type", "{ text: 'IceSky ' }");
            btnDelete.Click += async (o, e) => await tbMonaco.ExecuteTrigger("keyboard", "deleteLeft");
            btnCursorDown.Click += async (o, e) => await tbMonaco.ExecuteTrigger("script", "cursorDown");
            btnSelLine.Click += async (o, e) => await tbMonaco.ExecuteTrigger("script", "expandLineSelection");
            btnOpenFind.Click += async (o, e) => await tbMonaco.ExecuteTrigger("toolbar", "actions.find");
        }
    }
}