using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.WindowsUtils.Actions;
using SuchByte.WindowsUtils.Language;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

public partial class TextSelector : ActionConfigControl
{
    WriteTextAction pluginAction;
    public TextSelector(WriteTextAction pluginAction)
    {
        this.pluginAction = pluginAction;
        InitializeComponent();

        this.btnAddVariable.Text = PluginLanguageManager.PluginStrings.AddVariable;
        this.textBox.PlaceHolderText = PluginLanguageManager.PluginStrings.TypeTextHere;

        this.LoadConfig();
    }

    public override bool OnActionSave()
    {
        if (String.IsNullOrWhiteSpace(this.textBox.Text))
        {
            return false;
        }

        JObject jObject = new JObject
        {
            ["text"] = this.textBox.Text,
        };

        this.pluginAction.Configuration = jObject.ToString();
        this.pluginAction.ConfigurationSummary = this.textBox.Text.Length <= 150 ? this.textBox.Text : (this.textBox.Text.Substring(0, 147) + "...");

        return true;
    }

    private void LoadConfig()
    {
        if (!String.IsNullOrWhiteSpace(this.pluginAction.Configuration))
        {
            JObject jObject = JObject.Parse(this.pluginAction.Configuration);
            this.textBox.Text = jObject["text"].ToString();
        }
    }


    private void BtnAddVariable_Click(object sender, EventArgs e)
    {
        this.variablesContextMenu.Items.Clear();
        foreach (MacroDeck.Variables.Variable variable in MacroDeck.Variables.VariableManager.Variables)
        {
            ToolStripMenuItem item = new ToolStripMenuItem
            {
                ForeColor = Color.White,
                Text = variable.Name,
            };
            item.Click += AddVariableContextMenuItemClick;
            this.variablesContextMenu.Items.Add(item);
        }
        this.variablesContextMenu.Show(PointToScreen(new Point(((ButtonPrimary)sender).Bounds.Left, ((ButtonPrimary)sender).Bounds.Bottom)));
    }

    private void AddVariableContextMenuItemClick(object sender, EventArgs e)
    {
        ToolStripMenuItem item = (ToolStripMenuItem)sender;
        var selectionIndex = this.textBox.SelectionStart;
        this.textBox.Text = this.textBox.Text.Insert(selectionIndex, "{" + item.Text + "}");
        this.textBox.SelectionStart = selectionIndex + ("{" + item.Text + "}").Length;
    }
}
