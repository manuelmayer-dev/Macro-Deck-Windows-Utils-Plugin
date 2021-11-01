using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class ExplorerControlConfigurator : ActionConfigControl
    {
        PluginAction pluginAction;

        public ExplorerControlConfigurator(PluginAction pluginAction, ActionConfigurator actionConfigurator)
        {
            this.pluginAction = pluginAction;
            InitializeComponent();

            this.LoadConfig();

            actionConfigurator.ActionSave += OnActionSave;
        }
        private void OnActionSave(object sender, EventArgs e)
        {
            this.UpdateConfig();
        }

        private void LoadConfig()
        {
            if (this.pluginAction.Configuration != null && this.pluginAction.Configuration.Length > 0)
            {
                JObject jObject = JObject.Parse(this.pluginAction.Configuration);
                if (jObject != null)
                {
                    switch (jObject["action"].ToString())
                    {
                        case "back":
                            this.radioBack.Checked = true;
                            break;
                        case "forward":
                            this.radioForward.Checked = true;
                            break;
                        case "home":
                            this.radioHome.Checked = true;
                            break;
                        case "refresh":
                            this.radioRefresh.Checked = true;
                            break;
                    }
                }
            }
        }

        private void UpdateConfig()
        {
            JObject jObject = new JObject();
            if (this.radioBack.Checked)
            {
                jObject["action"] = "back";
            }
            else if (this.radioForward.Checked)
            {
                jObject["action"] = "forward";
            }
            else if (this.radioHome.Checked)
            {
                jObject["action"] = "home";
            }
            else if (this.radioRefresh.Checked)
            {
                jObject["action"] = "refresh";
            }
            this.pluginAction.Configuration = jObject.ToString();
            this.pluginAction.DisplayName = this.pluginAction.Name + " -> " + jObject["action"].ToString();
        }

    }
}
