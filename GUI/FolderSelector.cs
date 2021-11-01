using System;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class FolderSelector : ActionConfigControl
    {

        PluginAction pluginAction;

        public FolderSelector(PluginAction pluginAction, ActionConfigurator actionConfigurator)
        {
            this.pluginAction = pluginAction;
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

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                UseDescriptionForTitle = true,
                Description = "Select a folder to open"
            })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.path.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }
    }
}
