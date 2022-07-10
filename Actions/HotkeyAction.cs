using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions
{
    public class HotkeyAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionHotkey;

        public override string Description => PluginLanguageManager.PluginStrings.ActionHotkeyDescription;

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

                        if (bool.Parse(jObject["lwin"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LWIN);
                        }
                        if (bool.Parse(jObject["rwin"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RWIN);
                        }

                        if (bool.Parse(jObject["ctrl"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.CONTROL);
                        }
                        if (bool.Parse(jObject["lctrl"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LCONTROL);
                        }
                        if (bool.Parse(jObject["rctrl"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RCONTROL);
                        }

                        if (bool.Parse(jObject["shift"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.SHIFT);
                        }
                        if (bool.Parse(jObject["lshift"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LSHIFT);
                        }
                        if (bool.Parse(jObject["rshift"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.RSHIFT);
                        }

                        if (bool.Parse(jObject["alt"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.MENU);
                        }
                        if (bool.Parse(jObject["lalt"].ToString()))
                        {
                            modifierKeys.Add(VirtualKeyCode.LMENU);
                        }
                        if (bool.Parse(jObject["ralt"].ToString()))
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
