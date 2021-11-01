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
    public class IncreaseVolumeAction : PluginAction
    {

        public override string Name => "Increase volume";

        public override string DisplayName { get; set; } = "Increase volume";

        public override string Description => "Increase the volume of the current playback device";

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_UP);
        }
    }
}
