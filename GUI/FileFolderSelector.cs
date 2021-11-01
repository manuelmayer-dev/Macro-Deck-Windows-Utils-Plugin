using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class FileFolderSelector : ActionConfigControl
    {

        PluginAction pluginAction;

        SelectType type;

        public FileFolderSelector(PluginAction pluginAction, ActionConfigurator actionConfigurator, SelectType selectType)
        {
            this.pluginAction = pluginAction;
            this.type = selectType;
            InitializeComponent();

            switch (this.type)
            {
                case SelectType.FOLDER:
                    this.lblChoose.Text = "Choose a folder or drag and drop it here";
                    break;
                case SelectType.FILE:
                    this.lblChoose.Text = "Choose a file or drag and drop it here";
                    break;
            }


            this.AllowDrop = true;
            this.DragEnter += FileFolderSelector_DragEnter;
            this.DragDrop += FileFolderSelector_DragDrop;

            actionConfigurator.ActionSave += OnActionSave;

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

        private void OnActionSave(object sender, EventArgs e)
        {
            if (this.type != SelectType.FOLDER)
            {
                using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                {
                    if (msgBox.ShowDialog("Import icon", "Do you want to import icon of the file type?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            Utils.FileIconImport.ImportIcon(this.path.Text);
                        }
                        catch { }
                    }
                }
            }
            this.UpdateConfig();
        }


        private void LoadConfig()
        {
            if (!String.IsNullOrWhiteSpace(this.pluginAction.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                    this.path.Text = configurationObject["path"].ToString();
                }
                catch { }
            }
        }

        private void UpdateConfig()
        {
            if (String.IsNullOrWhiteSpace(this.path.Text))
            {
                return;
            }

            FileAttributes attr = File.GetAttributes(this.path.Text);
            if ((attr & FileAttributes.Directory) == FileAttributes.Directory)
            {
                Debug.WriteLine("folder");
                if (this.type == SelectType.FILE)
                {
                    using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                    {
                        msgBox.ShowDialog("Error", "The selected path is not a valid file.", MessageBoxButtons.OK);
                    }
                    return;
                }
            } else
            {
                Debug.WriteLine("file");
                if (this.type == SelectType.FOLDER)
                {
                    using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                    {
                        msgBox.ShowDialog("Error", "The selected path is not a valid folder.", MessageBoxButtons.OK);
                    }
                    return;
                }
            }


            JObject configurationObject = JObject.FromObject(new
            {
                path = this.path.Text,
            });
            this.pluginAction.Configuration = configurationObject.ToString();
            this.pluginAction.DisplayName = this.pluginAction.Name + " -> " + this.path.Text;
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
                Description = "Select a folder to open",
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
                Title = "Open file",
                CheckFileExists = false,
                CheckPathExists = false,
                DefaultExt = "exe",
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
}
