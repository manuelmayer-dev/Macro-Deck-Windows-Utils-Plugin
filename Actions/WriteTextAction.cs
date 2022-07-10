using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.Actions
{
    public class WriteTextAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionWriteText;

        public override string Description => PluginLanguageManager.PluginStrings.ActionWriteTextDescription;

        public override bool CanConfigure => true;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (!string.IsNullOrWhiteSpace(this.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.Configuration);
                    var text = configurationObject["text"].ToString();

                    foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.ListVariables.ToList().FindAll(x => text.ToLower().Contains("{" + x.Name.ToLower() + "}")))
                    {
                        text = text.Replace("{" + variable.Name + "}", variable.Value.ToString(), StringComparison.OrdinalIgnoreCase);
                    }

                    PluginInstance.Main.InputSimulator.Keyboard.TextEntry(text);
                }
                catch (Exception ex)
                {
                    MacroDeckLogger.Warning(PluginInstance.Main, typeof(WriteTextAction) + ": " + ex.Message);
                }
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new TextSelector(this);
        }
    }
}
