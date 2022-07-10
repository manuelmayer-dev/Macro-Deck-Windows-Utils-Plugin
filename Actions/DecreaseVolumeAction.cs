using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions
{
    public class DecreaseVolumeAction : PluginAction
    {

        public override string Name => PluginLanguageManager.PluginStrings.ActionDecreaseVolume;

        public override string Description => PluginLanguageManager.PluginStrings.ActionDecreaseVolumeDescription;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_DOWN);
        }
    }
}
