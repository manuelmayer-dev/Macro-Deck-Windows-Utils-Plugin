using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WindowsInput;
using WindowsInput.Native;

namespace SuchByte.WindowsUtils.Actions
{
    public class HotkeyAction : PluginAction
    {
        public override string Name => "Hotkey";

        public override string Description => "Single hotkey";

        public override string DisplayName { get; set; } = "Hotkey";
        public override bool CanConfigure => true;


        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new HotkeyConfigurator(this, actionConfigurator);
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
                            PluginInstance.Main.InputSimulator.Keyboard.KeyDown(modifierKey);
                        }

                        PluginInstance.Main.InputSimulator.Keyboard.KeyDown(virtualKeyCode);

                        Thread.Sleep(100);

                        PluginInstance.Main.InputSimulator.Keyboard.KeyUp(virtualKeyCode);

                        foreach (VirtualKeyCode modifierKey in modifierKeys)
                        {
                            PluginInstance.Main.InputSimulator.Keyboard.KeyUp(modifierKey);
                        }

                    }
                }
            }
            catch { }
        }
    }
}
