using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Actions;
using SuchByte.WindowsUtils.Language;
using System.Collections.Generic;
using WindowsInput;

namespace SuchByte.WindowsUtils;

public static class PluginInstance
{
    public static Main Main;
}

public class Main : MacroDeckPlugin
{
    public static Main Instance;

    public InputSimulator InputSimulator = new();

    public System.Timers.Timer TickTimer;

    public Main()
    {
        Instance = this;
        PluginInstance.Main = this;
    }

    public override void Enable()
    {
        PluginLanguageManager.Initialize();
        this.Actions = new List<PluginAction>
        {
            new WriteTextAction(),
            new CommandlineAction(),
            new OpenFileAction(),
            new OpenFolderAction(),
            new StartApplicationAction(),
            new IncreaseVolumeAction(),
            new DecreaseVolumeAction(),
            new MuteVolumeAction(),
            new WindowsExplorerControlAction(),
            //new WebrequestAction(), // TODO
            //new WindowsOpenWebsiteAction(), // TODO
            new HotkeyAction(),
            //new MultiHotkeyAction(),
        };

        this.TickTimer = new System.Timers.Timer()
        {
            Enabled = true,
            Interval = 2000,
        };
        this.TickTimer.Start();
    }
}
