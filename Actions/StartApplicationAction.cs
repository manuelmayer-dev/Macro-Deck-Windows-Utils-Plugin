using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Language;
using SuchByte.WindowsUtils.Models;
using SuchByte.WindowsUtils.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.Actions
{
    public class StartApplicationAction : PluginAction
    {
        public override string Name => PluginLanguageManager.PluginStrings.ActionStartApplication;

        public override string Description => PluginLanguageManager.PluginStrings.ActionStartApplicationDescription;

        public override bool CanConfigure => true;

        private System.Timers.Timer stateUpdateTimer;

        public override void Trigger(string clientId, ActionButton actionButton)
        {
            var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
            if (configModel == null) return;

            switch (configModel.StartMethod)
            {
                case StartMethod.Start:
                    ApplicationLauncher.StartApplication(configModel.Path, configModel.Arguments, configModel.RunAsAdmin);
                    break;
                case StartMethod.StartStop:
                    if (ApplicationLauncher.IsRunning(configModel.Path))
                    {
                        ApplicationLauncher.KillApplication(configModel.Path);
                    }
                    else
                    {
                        ApplicationLauncher.StartApplication(configModel.Path, configModel.Arguments, configModel.RunAsAdmin);
                    }
                    break;
                case StartMethod.StartFocus:
                    if (!ApplicationLauncher.IsRunning(configModel.Path))
                    {
                        ApplicationLauncher.StartApplication(configModel.Path, configModel.Arguments, configModel.RunAsAdmin);
                    } else
                    {
                        ApplicationLauncher.BringToForeground(configModel.Path);
                    }
                    break;
            }
        }

        public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
        {
            return new StartApplicationActionConfigView(this);
        }

        public override void OnActionButtonLoaded()
        {
            var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
            if (configModel == null || !configModel.SyncButtonState) return;
            this.stateUpdateTimer = new System.Timers.Timer()
            {
                Enabled = true,
                Interval = 2000,
            };
            this.stateUpdateTimer.Elapsed += StateUpdateTimer_Elapsed;
        }

        public override void OnActionButtonDelete()
        {
            if (this.stateUpdateTimer == null) return;
            this.stateUpdateTimer.Stop();
            this.stateUpdateTimer.Dispose();
        }


        private void StateUpdateTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            Task.Run(UpdateState);
        }

        private void UpdateState()
        {
            if (this.ActionButton == null) return;
            var configModel = StartApplicationActionConfigModel.Deserialize(this.Configuration);
            if (configModel == null || !configModel.SyncButtonState || string.IsNullOrWhiteSpace(configModel.Path)) return;
            this.ActionButton.State = ApplicationLauncher.IsRunning(configModel.Path);
        }
    }
}
