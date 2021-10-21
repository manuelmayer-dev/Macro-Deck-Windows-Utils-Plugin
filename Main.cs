using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace SuchByte.WindowsUtils
{
    public class Main : MacroDeckPlugin
    {
        public override string Description => "(Beta) Includes Explorer shortcuts and keyboard hotkeys";
        public override Image Icon => Properties.Resources.Windows_Utils;
        public override void Enable()
        {
            this.Actions = new List<PluginAction>
            {
                new WindowsExplorerControlAction(),
                //new WebrequestAction(),
                //new WindowsOpenFolderAction(),
                //new WindowsVolumeControlAction(),
                //new OpenApplicationAction(),
                //new WindowsOpenWebsiteAction(),
                //new MultiHotkeyAction(),
                new HotkeyAction(),
            };
        }

        public override void OpenConfigurator() {}
    }

    public class WindowsExplorerControlAction : PluginAction
    {
        public override string Name => "Explorer control";

        public override string Description => "Explorer/browser (back/forward/home/refresh)";

        public override string DisplayName { get; set; } = "";
        public override bool CanConfigure => true;

        private InputSimulator inputSimulator = new InputSimulator();

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new ExplorerControlConfigurator(this);
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

    public class HotkeyAction : PluginAction
    {
        public override string Name => "Hotkey";

        public override string Description => "Single hotkey";

        public override string DisplayName { get; set; } = "Hotkey";
        public override bool CanConfigure => true;

        private InputSimulator inputSimulator = new InputSimulator();

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new HotkeyConfigurator(this);
        }

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            try
            {
                if (this.Configuration != null && this.Configuration.Length > 0)
                {
                    JObject jObject = JObject.Parse(this.Configuration);
                    if (jObject != null)
                    {
                        List<VirtualKeyCode> modifierKeys = new List<VirtualKeyCode>();
                        VirtualKeyCode virtualKeyCode = (VirtualKeyCode)Enum.Parse(typeof(VirtualKeyCode), jObject["key"].ToString());

                        if (Boolean.Parse(jObject["lwin"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LWIN);
                        }
                        if (Boolean.Parse(jObject["rwin"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RWIN);
                        }

                        if (Boolean.Parse(jObject["ctrl"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.CONTROL);
                        }
                        if (Boolean.Parse(jObject["lctrl"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LCONTROL);
                        }
                        if (Boolean.Parse(jObject["rctrl"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RCONTROL);
                        }

                        if (Boolean.Parse(jObject["shift"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.SHIFT);
                        }
                        if (Boolean.Parse(jObject["lshift"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LSHIFT);
                        }
                        if (Boolean.Parse(jObject["rshift"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RSHIFT);
                        }

                        if (Boolean.Parse(jObject["alt"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.MENU);
                        }
                        if (Boolean.Parse(jObject["lalt"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LMENU);
                        }
                        if (Boolean.Parse(jObject["ralt"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RMENU);
                        }

                        // Using KeyDown and KeyUp with delay because some applications doesn't recognize the ModifiedKeyStroke of H.InputSimulator because it's too fast

                        foreach (VirtualKeyCode modifierKey in modifierKeys)
                        {
                            this.inputSimulator.Keyboard.KeyDown(modifierKey);
                        }

                        this.inputSimulator.Keyboard.KeyDown(virtualKeyCode);

                        Thread.Sleep(100);

                        this.inputSimulator.Keyboard.KeyUp(virtualKeyCode);

                        foreach (VirtualKeyCode modifierKey in modifierKeys)
                        {
                            this.inputSimulator.Keyboard.KeyUp(modifierKey);
                        }

                    }
                }
            } catch { }
        }
    }
}
