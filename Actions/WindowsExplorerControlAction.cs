using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using System;
using System.Collections.Generic;
using System.Text;
using WindowsInput;
using WindowsInput.Native;

namespace SuchByte.WindowsUtils.Actions
{
    public class WindowsExplorerControlAction : PluginAction
    {
        public override string Name => "Explorer control";

        public override string Description => "Explorer/browser (back/forward/home/refresh)";

        public override string DisplayName { get; set; } = "";
        public override bool CanConfigure => true;

        private InputSimulator inputSimulator = new InputSimulator();

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new ExplorerControlConfigurator(this, actionConfigurator);
        }

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            if (this.Configuration.Length == 0) return;
            try
            {
                string type = JObject.Parse(this.Configuration)["action"].ToString();
                switch (type)
                {
                    case "back":
                        inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_BACK);
                        break;
                    case "forward":
                        inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_FORWARD);
                        break;
                    case "home":
                        inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_HOME);
                        break;
                    case "refresh":
                        inputSimulator.Keyboard.KeyPress(VirtualKeyCode.BROWSER_REFRESH);
                        break;
                }
            }
            catch { }
        }
    }
}
