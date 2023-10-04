using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;

namespace SuchByte.WindowsUtils.GUI;

public partial class ExplorerControlConfigurator : ActionConfigControl
{
    PluginAction pluginAction;
    ActionConfigurator actionConfigurator;

    public ExplorerControlConfigurator(PluginAction pluginAction, ActionConfigurator actionConfigurator)
    {
        this.pluginAction = pluginAction;
        this.actionConfigurator = actionConfigurator;
        InitializeComponent();

        this.lblAction.Text = PluginLanguageManager.PluginStrings.Action;
        this.radioBack.Text = PluginLanguageManager.PluginStrings.Back;
        this.radioForward.Text = PluginLanguageManager.PluginStrings.Forward;
        this.radioHome.Text = PluginLanguageManager.PluginStrings.Home;
        this.radioRefresh.Text = PluginLanguageManager.PluginStrings.Refresh;

        this.LoadConfig();
    }

    public override bool OnActionSave()
    {
        JObject jObject = new JObject();
        if (this.radioBack.Checked)
        {
            jObject["action"] = "back";
        }
        else if (this.radioForward.Checked)
        {
            jObject["action"] = "forward";
        }
        else if (this.radioHome.Checked)
        {
            jObject["action"] = "home";
        }
        else if (this.radioRefresh.Checked)
        {
            jObject["action"] = "refresh";
        }
        this.pluginAction.Configuration = jObject.ToString();
        this.pluginAction.ConfigurationSummary = jObject["action"].ToString();
        return true;
    }


    private void LoadConfig()
    {
        if (this.pluginAction.Configuration != null && this.pluginAction.Configuration.Length > 0)
        {
            JObject jObject = JObject.Parse(this.pluginAction.Configuration);
            if (jObject != null)
            {
                switch (jObject["action"].ToString())
                {
                    case "back":
                        this.radioBack.Checked = true;
                        break;
                    case "forward":
                        this.radioForward.Checked = true;
                        break;
                    case "home":
                        this.radioHome.Checked = true;
                        break;
                    case "refresh":
                        this.radioRefresh.Checked = true;
                        break;
                }
            }
        }
    }


}
