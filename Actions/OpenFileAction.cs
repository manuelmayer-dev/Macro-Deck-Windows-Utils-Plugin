using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.Actions;

public class OpenFileAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionOpenFile;

    public override string Description => PluginLanguageManager.PluginStrings.ActionOpenFile;

    public override bool CanConfigure => true;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!string.IsNullOrWhiteSpace(this.Configuration))
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
        return new FileFolderSelector(this, actionConfigurator, SelectType.FILE);
    }
}
