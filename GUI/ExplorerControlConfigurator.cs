using Newtonsoft.Json.Linq;
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
        PluginAction _macroDeckAction;

        public ExplorerControlConfigurator(PluginAction macroDeckAction)
        {
            this._macroDeckAction = macroDeckAction;
            InitializeComponent();
            if (macroDeckAction.Configuration != null && macroDeckAction.Configuration.Length > 0)
            {
                JObject jObject = JObject.Parse(macroDeckAction.Configuration);
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
            this.radioBack.CheckedChanged += this.Radio_CheckedChanged;
            this.radioForward.CheckedChanged += this.Radio_CheckedChanged;
            this.radioHome.CheckedChanged += this.Radio_CheckedChanged;
            this.radioRefresh.CheckedChanged += this.Radio_CheckedChanged;
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            JObject jObject = new JObject();
            if (this.radioBack.Checked)
            {
                jObject["action"] = "back";
            } else if (this.radioForward.Checked)
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
            this._macroDeckAction.Configuration = jObject.ToString();
            this._macroDeckAction.DisplayName = this._macroDeckAction.Name + " -> " + jObject["action"].ToString();
        }
    }
}
