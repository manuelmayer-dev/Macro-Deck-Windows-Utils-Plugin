using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class ApplicationSelector : ActionConfigControl
    {

        PluginAction pluginAction;

        public ApplicationSelector(PluginAction pluginAction, ActionConfigurator actionConfigurator)
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
                    this.arguments.Text = configurationObject["arguments"].ToString();                    
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
                arguments = this.arguments.Text,
            });
            this.pluginAction.Configuration = configurationObject.ToString();
            this.pluginAction.DisplayName = this.pluginAction.Name + " -> " + this.path.Text + (!String.IsNullOrWhiteSpace(this.arguments.Text) ? (" -> " + this.arguments.Text) : "");
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
}

