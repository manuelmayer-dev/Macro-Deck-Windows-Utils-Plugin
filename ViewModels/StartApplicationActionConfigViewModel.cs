using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuchByte.WindowsUtils.ViewModels
{
    internal class StartApplicationActionConfigViewModel : ISerializableConfigViewModel
    {
        private readonly PluginAction _action;
        public StartApplicationActionConfigModel Configuration { get; set; }

        ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

        public string Path
        {
            get => Configuration.Path;
            set => Configuration.Path = value;
        }

        public string Arguments
        {
            get => Configuration.Arguments;
            set => Configuration.Arguments = value;
        }

        public bool RunAsAdmin
        {
            get => Configuration.RunAsAdmin;
            set => Configuration.RunAsAdmin = value;
        }

        public bool SyncButtonState
        {
            get => Configuration.SyncButtonState;
            set => Configuration.SyncButtonState = value;
        }

        public StartMethod StartMethod
        {
            get => Configuration.StartMethod;
            set => Configuration.StartMethod = value;
        }



        public StartApplicationActionConfigViewModel(PluginAction action)
        {
            this.Configuration = StartApplicationActionConfigModel.Deserialize(action.Configuration);
            this._action = action;
        }

        public bool SaveConfig()
        {
            try
            {
                SetConfig();
                MacroDeckLogger.Info(PluginInstance.Main, $"{GetType().Name}: config saved");
            }
            catch (Exception ex)
            {
                MacroDeckLogger.Error(PluginInstance.Main, $"{GetType().Name}: Error while saving config: { ex.Message + Environment.NewLine + ex.StackTrace }");
            }
            return true;
        }

        public void SetConfig()
        {
            _action.ConfigurationSummary = Configuration.Path.ToString();
            _action.Configuration = Configuration.Serialize();
        }
    }
}
