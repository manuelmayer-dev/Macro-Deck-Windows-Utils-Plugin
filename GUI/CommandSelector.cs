using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Language;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class CommandSelector : ActionConfigControl
    {
        PluginAction pluginAction;

        public CommandSelector(PluginAction pluginAction)
        {
            this.pluginAction = pluginAction;

            InitializeComponent();

            this.lblCommand.Text = PluginLanguageManager.PluginStrings.Command;
            this.lblWorkingDirectory.Text = PluginLanguageManager.PluginStrings.WorkingDirectory;
            this.checkSaveVariable.Text = PluginLanguageManager.PluginStrings.SaveOutputToVariable;
            this.workingDirectory.PlaceHolderText = PluginLanguageManager.PluginStrings.ChooseAFolderOrDragAndDrop;
            this.variableName.PlaceHolderText = PluginLanguageManager.PluginStrings.VariableName;


            this.variableType.Items.AddRange(new string[]
            {
                "String",
                "Integer",
                "Float",
                "Bool"
            });
            this.variableType.Text = "String";


            this.workingDirectory.AllowDrop = true;
            this.workingDirectory.DragEnter += WorkingDirectory_DragEnter;
            this.workingDirectory.DragDrop += WorkingDirectory_DragDrop;

            this.LoadConfig();
        }

        public override bool OnActionSave()
        {
            if (String.IsNullOrWhiteSpace(this.command.Text))
            {
                return false;
            }

            if (String.IsNullOrWhiteSpace(this.workingDirectory.Text)) {
                try
                {
                    FileAttributes attr = File.GetAttributes(this.workingDirectory.Text);
                    if ((attr & FileAttributes.Directory) != FileAttributes.Directory)
                    {
                        using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                        {
                            msgBox.ShowDialog(LanguageManager.Strings.Error, PluginLanguageManager.PluginStrings.SelectedPathNotAFile, MessageBoxButtons.OK);
                        }
                        return false;
                    }
                } catch {}
            }

            JObject configurationObject = JObject.FromObject(new
            {
                command = this.command.Text,
                workingDirectory = this.workingDirectory.Text,
                saveVariable = this.checkSaveVariable.Checked,
                variableName = this.variableName.Text,
                variableType = this.variableType.Text,
            });
            this.pluginAction.Configuration = configurationObject.ToString();
            this.pluginAction.ConfigurationSummary = this.command.Text + (!String.IsNullOrWhiteSpace(this.workingDirectory.Text) ? " in " + this.workingDirectory.Text : "");
            return true;
        }


        private void WorkingDirectory_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                this.workingDirectory.Text = path;
            }
            catch { }
        }

        private void WorkingDirectory_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void LoadConfig()
        {
            if (!string.IsNullOrWhiteSpace(this.pluginAction.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                    this.command.Text = configurationObject["command"].ToString();
                    this.workingDirectory.Text = configurationObject["workingDirectory"].ToString();
                    bool.TryParse(configurationObject["saveVariable"].ToString(), out bool saveVariable);
                    this.checkSaveVariable.Checked = saveVariable;
                    this.variableName.Text = configurationObject["variableName"].ToString();
                    this.variableType.Text = configurationObject["variableType"].ToString();
                }
                catch { }
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var folderBrowserDialog = new FolderBrowserDialog
            {
                ShowNewFolderButton = true,
                UseDescriptionForTitle = true,
            })
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    this.workingDirectory.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void CheckSaveVariable_CheckedChanged(object sender, EventArgs e)
        {
            this.variableName.Visible = this.checkSaveVariable.Checked;
            this.variableType.Visible = this.checkSaveVariable.Checked;
        }

        private void lblWorkingDirectory_Click(object sender, EventArgs e)
        {

        }
    }
}
