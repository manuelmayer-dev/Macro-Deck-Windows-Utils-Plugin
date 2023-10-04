using SuchByte.MacroDeck.Logging;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Models;
using System;
using System.Collections.Generic;

namespace SuchByte.WindowsUtils.ViewModels;

internal class MultiHotkeyActionConfigViewModel : ISerializableConfigViewModel
{
    private readonly PluginAction _action;
    public MultiHotkeyActionConfigModel Configuration { get; set; }

    ISerializableConfiguration ISerializableConfigViewModel.SerializableConfiguration => Configuration;

    public List<IMultiHotkeyAction> MultiHotkeyActions
    {
        get => Configuration.MultiHotkeyActions;
        set => Configuration.MultiHotkeyActions = value;
    }

    public bool SyncButtonState
    {
        get => Configuration.SyncButtonState;
        set => Configuration.SyncButtonState = value;
    }



    public MultiHotkeyActionConfigViewModel(PluginAction action)
    {
        this.Configuration = MultiHotkeyActionConfigModel.Deserialize(action.Configuration);
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
        _action.ConfigurationSummary = $"{Configuration.MultiHotkeyActions.Count} actions";
        _action.Configuration = Configuration.Serialize();
    }
}
