using SuchByte.MacroDeck.ActionButton;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.GUI;
using SuchByte.WindowsUtils.Models;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.Actions;

public class MultiHotkeyAction : PluginAction
{
    public override string Name => "MultiHotkeyAction";

    public override string Description => "";

    public override bool CanConfigure => true;

    private bool stop = false;

    private bool executing = false;

    public override void Trigger(string clientId, ActionButton actionButton)
    {
        var configModel = MultiHotkeyActionConfigModel.Deserialize(this.Configuration);
        if (configModel == null) return;
        if (executing == !stop)
        {
            stop = true;
        }
        Task.Run(() =>
        {
            if (configModel.SyncButtonState) this.ActionButton.State = true;
            executing = true;
            foreach (var multiHotkeyAction in configModel.MultiHotkeyActions)
            {
                if (stop)
                {
                    stop = false;
                    break;
                }
                multiHotkeyAction.Execute();
            }
            executing = false;
            if (configModel.SyncButtonState) this.ActionButton.State = false;
        });
        
    }

    public override ActionConfigControl GetActionConfigControl(ActionConfigurator actionConfigurator)
    {
        return new StartApplicationActionConfigView(this);
    }

    
}
