using System;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;

namespace SuchByte.WindowsUtils.GUI;

public partial class FileFolderSelector : ActionConfigControl
{

    PluginAction pluginAction;

    SelectType type;

    public FileFolderSelector(PluginAction pluginAction, ActionConfigurator actionConfigurator, SelectType selectType)
    {
        this.pluginAction = pluginAction;
        this.type = selectType;
        InitializeComponent();

        this.lblPath.Text = PluginLanguageManager.PluginStrings.Path;

        switch (this.type)
        {
            case SelectType.FOLDER:
                this.lblChoose.Text = PluginLanguageManager.PluginStrings.ChooseAFolderOrDragAndDrop;
                break;
            case SelectType.FILE:
                this.lblChoose.Text = PluginLanguageManager.PluginStrings.ChooseAFileOrDragAndDrop;
                break;
        }


        this.AllowDrop = true;
        this.DragEnter += FileFolderSelector_DragEnter;
        this.DragDrop += FileFolderSelector_DragDrop;


        this.LoadConfig();
    }

    private void FileFolderSelector_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
            this.path.Text = file;
        }
        catch { }
    }

    private void FileFolderSelector_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            e.Effect = DragDropEffects.Copy;
        }
    }

    public override bool OnActionSave()
    {
        if (string.IsNullOrWhiteSpace(this.path.Text))
        {
            return false;
        }
        if (this.type != SelectType.FOLDER)
        {
            using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
            {
                if (msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.QuestionImportFileTypesIcon, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        Utils.FileIconImport.ImportIcon(this.path.Text);
                    }
                    catch { }
                }
            }
        }
        FileAttributes attr = File.GetAttributes(this.path.Text);
        if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
        {
            if (this.type == SelectType.FILE)
            {
                using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                {
                    msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.SelectedPathNotAFile, MessageBoxButtons.OK);
                }
                return false;
            }
        }
        else
        {
            if (this.type == SelectType.FOLDER)
            {
                using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                {
                    msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.SelectedPathNotAFolder, MessageBoxButtons.OK);
                }
                return false;
            }
        }


        JObject configurationObject = JObject.FromObject(new
        {
            path = this.path.Text,
        });
        this.pluginAction.Configuration = configurationObject.ToString();
        this.pluginAction.ConfigurationSummary = this.path.Text;
        return true;
    }



    private void LoadConfig()
    {
        if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                this.path.Text = configurationObject["path"].ToString();
            }
            catch { }
        }
    }

    private void BtnBrowse_Click(object sender, EventArgs e)
    {
        switch (this.type)
        {
            case SelectType.FOLDER:
                this.ShowFolderBrowserDialog();
                break;
            case SelectType.FILE:
                ShowOpenFileDialog();
                break;
        }
    }

    private void ShowFolderBrowserDialog()
    {
        using (var folderBrowserDialog = new FolderBrowserDialog
        {
            ShowNewFolderButton = true,
            UseDescriptionForTitle = true,
        })
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                this.path.Text = folderBrowserDialog.SelectedPath;
            }
        }
    }

    private void ShowOpenFileDialog()
    {
        using (var openFileDialog = new OpenFileDialog
        {
            CheckFileExists = false,
            CheckPathExists = false,
            Filter = "All files (*.*)|*.*",
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



public enum SelectType
{
    FOLDER,
    FILE,
}
