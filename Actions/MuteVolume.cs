using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using WindowsInput.Native;

namespace SuchByte.WindowsUtils.Actions
{
    public class MuteVolumeAction : PluginAction
    {

        public override string Name => PluginLanguageManager.PluginStrings.ActionMuteVolume;

        public override string Description => PluginLanguageManager.PluginStrings.ActionMuteVolumeDescription;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE);
        }
    }
}
