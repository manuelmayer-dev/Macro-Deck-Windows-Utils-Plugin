using System;
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

            actionConfigurator.ActionSave += OnActionSave;

            this.LoadConfig();
        }

        private void OnActionSave(object sender, EventArgs e)
        {
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
