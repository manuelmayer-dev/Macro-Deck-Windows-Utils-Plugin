using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SuchByte.WindowsUtils.Actions
{
    public class StartApplicationAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionStartApplication;

        public override string Description => PluginLanguageManager.PluginStrings.ActionStartApplicationDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (!String.IsNullOrWhiteSpace(this.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.Configuration);
                    var path = configurationObject["path"].ToString();
                    var arguments = configurationObject["arguments"].ToString();

                    var p = new Process
                    {
                        StartInfo = new ProcessStartInfo(path)
                        {
                            UseShellExecute = true,
                            Arguments = arguments,
                        }
                    };
                    p.Start();
                }
                catch { }
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new ApplicationSelector(this, actionConfigurator);
        }
    }
}
