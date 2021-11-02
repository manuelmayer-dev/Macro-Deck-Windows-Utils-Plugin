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

    public class OpenFolderAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionOpenFolder;

        public override string DisplayName { get; set; } = PluginLanguageManager.PluginStrings.ActionOpenFolder;

        public override string Description => PluginLanguageManager.PluginStrings.ActionOpenFolderDescription;

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
            return new FileFolderSelector(this, actionConfigurator, SelectType.FOLDER);
        }
    }
}
