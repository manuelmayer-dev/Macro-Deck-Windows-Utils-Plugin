using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SuchByte.WindowsUtils.Actions
{

    public class OpenFolderAction : PluginAction
    {
        public override string Name => "Open folder";

        public override string DisplayName { get; set; } = "Open folder";

        public override string Description => "Opens a folder";

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (!String.IsNullOrWhiteSpace(this.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.Configuration);
                    var path = configurationObject["path"].ToString();

                    var p = new Process
                    {
                        StartInfo = new ProcessStartInfo(path)
                        {
                            UseShellExecute = true,
                        }
                    };
                    p.Start();
                }
                catch { }
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new FolderSelector(this, actionConfigurator);
        }
    }
}
