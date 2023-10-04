using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using SuchByte.WindowsUtils.Models;
using SuchByte.WindowsUtils.ViewModels;
using System;
using System.Linq;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

public partial class StartApplicationActionConfigView : ActionConfigControl
{
    private readonly StartApplicationActionConfigViewModel _viewModel;

    private readonly PluginAction _action;

    public StartApplicationActionConfigView(PluginAction action)
    {
        InitializeComponent();

        this._action ??= action;

        this.lblPath.Text = PluginLanguageManager.PluginStrings.Path;
        this.lblArguments.Text = PluginLanguageManager.PluginStrings.Arguments;
        this.path.PlaceHolderText = PluginLanguageManager.PluginStrings.ChooseAFileOrDragAndDrop;

        this.method.Items.AddRange(new[] { PluginLanguageManager.PluginStrings.MethodStart, 
                                            PluginLanguageManager.PluginStrings.MethodStartStop, 
                                            PluginLanguageManager.PluginStrings.MethodStartFocus, });

        this.path.AllowDrop = true;
        this.path.DragEnter += ApplicationSelector_DragEnter;
        this.path.DragDrop += ApplicationSelector_DragDrop;
        this.AllowDrop = true;
        this.DragEnter += ApplicationSelector_DragEnter;
        this.DragDrop += ApplicationSelector_DragDrop;


        this._viewModel = new StartApplicationActionConfigViewModel(action);
    }

    private void ApplicationSelector_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop)).FirstOrDefault();
            this.path.Text = file;
        }
        catch { }
    }

    private void ApplicationSelector_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    private void StartApplicationActionConfigView_Load(object sender, EventArgs e)
    {
        this.path.Text = this._viewModel.Path;
        this.arguments.Text = this._viewModel.Arguments;
        switch (this._viewModel.StartMethod)
        {
            case StartMethod.Start:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodStart;
                break;
            case StartMethod.StartStop:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodStartStop;
                break;
            case StartMethod.StartFocus:
                this.method.Text = PluginLanguageManager.PluginStrings.MethodStartFocus;
                break;
        }
        this.checkRunAsAdmin.Checked = this._viewModel.RunAsAdmin;
        this.checkSyncButtonState.Checked = this._viewModel.SyncButtonState;
    }

    public override bool OnActionSave()
    {
        if (string.IsNullOrWhiteSpace(this.path.Text))
        {
            return false;
        }
        this._viewModel.Path = this.path.Text;
        this._viewModel.Arguments = this.arguments.Text;
        if (this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodStart))
        {
            this._viewModel.StartMethod = StartMethod.Start;
        }
        else if(this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodStartStop))
        {
            this._viewModel.StartMethod = StartMethod.StartStop;
        }
        else if (this.method.Text.Equals(PluginLanguageManager.PluginStrings.MethodStartFocus))
        {
            this._viewModel.StartMethod = StartMethod.StartFocus;
        }
        this._viewModel.RunAsAdmin = this.checkRunAsAdmin.Checked;
        this._viewModel.SyncButtonState = this.checkSyncButtonState.Checked;

       


        using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
        {
            if (msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.QuestionImportFilesIcon, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    var iconModel = Utils.FileIconImport.ImportIcon(this.path.Text);
                    if (iconModel != null)
                    {
                    }
                }
                catch (Exception ex)
                {
                    MacroDeckLogger.Error(Main.Instance, $"Failed to import the file icon: {ex.Message + Environment.NewLine + ex.StackTrace}");
                }
            }
        }
        return this._viewModel.SaveConfig();
    }

    private void BtnBrowse_Click(object sender, EventArgs e)
    {
        using (var openFileDialog = new OpenFileDialog
        {
            Title = "Start application",
            CheckFileExists = false,
            CheckPathExists = false,
            DefaultExt = "exe",
            Filter = "Applications (*.exe)|*.exe|Shortcuts (*.ink)|*.ink|All files (*.*)|*.*",
            SupportMultiDottedExtensions = true,
            ValidateNames = false,
            DereferenceLinks = false,
        })
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = openFileDialog.FileName;
            }
        }
    }

}

