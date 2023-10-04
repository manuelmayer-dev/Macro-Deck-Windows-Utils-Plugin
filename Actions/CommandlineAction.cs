using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.MacroDeck.Variables;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.Actions;

public class CommandlineAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionCommandline;

    public override string Description => PluginLanguageManager.PluginStrings.ActionCommandlineDescription;

    public override bool CanConfigure => true;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        if (!string.IsNullOrWhiteSpace(this.Configuration))
        {
            try
            {
                JObject configurationObject = JObject.Parse(this.Configuration);
                var workingDirectory = configurationObject["workingDirectory"].ToString();
                var command = configurationObject["command"].ToString();
                bool.TryParse(configurationObject["saveVariable"].ToString(), out bool saveVariable);

                var p = new Process
                {
                    StartInfo = new ProcessStartInfo("cmd.exe")
                    {
                        UseShellExecute = false,
                        WorkingDirectory = workingDirectory,
                        Arguments = "/C " + command,
                        RedirectStandardOutput = saveVariable,
                    }
                };
                p.Start();
                if (saveVariable)
                {
                    var output = p.StandardOutput.ReadToEnd().Replace(Environment.NewLine, String.Empty);
                    Debug.WriteLine(output);
                    var variableName = configurationObject["variableName"].ToString();
                    Enum.TryParse(typeof(VariableType), configurationObject["variableType"].ToString(), true, out object type);
                    VariableManager.SetValue(variableName, output, (VariableType) type, PluginInstance.Main, null);
                }
            }
            catch (Exception e) {
                Debug.WriteLine(e.Message);
            }
        }
    }

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new CommandSelector(this);
    }
}
