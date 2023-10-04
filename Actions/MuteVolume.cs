using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using WindowsInput;

namespace SuchByte.WindowsUtils.Actions;

public class MuteVolumeAction : PluginAction
{
    public override string Name => PluginLanguageManager.PluginStrings.ActionMuteVolume;

    public override string Description => PluginLanguageManager.PluginStrings.ActionMuteVolumeDescription;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        PluginInstance.Main.InputSimulator.Keyboard.KeyPress(VirtualKeyCode.VOLUME_MUTE);
    }
}
