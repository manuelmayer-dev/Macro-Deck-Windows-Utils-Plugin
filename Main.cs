using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Actions;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
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
    public static class PluginInstance
    {
        public static Main Main;
    }


    public class Main : MacroDeckPlugin
    {
        public override string Description => "Trigger keyboard hotkeys, open applications, open folders and more";
        public override Image Icon => Properties.Resources.Windows_Utils;

        public InputSimulator InputSimulator = new InputSimulator();

        public Main()
        {
            PluginInstance.Main = this;
        }

        public override void Enable()
        {
            PluginLanguageManager.Initialize();
            this.Actions = new List<PluginAction>
            {
                new OpenFileAction(),
                new OpenFolderAction(),
                new StartApplicationAction(),
                new IncreaseVolumeAction(),
                new DecreaseVolumeAction(),
                new MuteVolumeAction(),
                new WindowsExplorerControlAction(),
                //new WebrequestAction(), // TODO
                //new WindowsOpenWebsiteAction(), // TODO
                //new MultiHotkeyAction(), // TODO
                new HotkeyAction(),
            };
        }
    }
}
