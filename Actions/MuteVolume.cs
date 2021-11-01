using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
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

        public override string Name => "Mute volume";

        public override string DisplayName { get; set; } = "Mute volume";

        public override string Description => "Mute the current playback device";

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE);
        }
    }
}
