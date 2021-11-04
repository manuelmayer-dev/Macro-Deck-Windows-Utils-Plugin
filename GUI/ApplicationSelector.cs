using ImageMagick;
using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Icons;
using SuchByte.MacroDeck.Plugins;
using SuchByte.WindowsUtils.Language;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class ApplicationSelector : ActionConfigControl
    {

        PluginAction pluginAction;
        ActionConfigurator actionConfigurator;

        public ApplicationSelector(PluginAction pluginAction, ActionConfigurator actionConfigurator)
        {
            this.pluginAction = pluginAction;
            this.actionConfigurator = actionConfigurator;
            InitializeComponent();

            this.lblPath.Text = PluginLanguageManager.PluginStrings.Path;
            this.lblArguments.Text = PluginLanguageManager.PluginStrings.Arguments;
            this.lblChoose.Text = PluginLanguageManager.PluginStrings.ChooseAFileOrDragAndDrop;

            this.AllowDrop = true;
            this.DragEnter += ApplicationSelector_DragEnter;
            this.DragDrop += ApplicationSelector_DragDrop;

            this.LoadConfig();
        }


        private void ApplicationSelector_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string file = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                this.path.Text = file;
            }
            catch { }
        }

        private void ApplicationSelector_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        public override bool OnActionSave()
        {
            if (String.IsNullOrWhiteSpace(this.path.Text))
            {
                return false;
            }
            using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
            {
                if (msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.QuestionImportFilesIcon, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        Utils.FileIconImport.ImportIcon(this.path.Text);
                    }
                    catch { }
                }
                JObject configurationObject = JObject.FromObject(new
                {
                    path = this.path.Text,
                    arguments = this.arguments.Text,
                });
                this.pluginAction.Configuration = configurationObject.ToString();
                this.pluginAction.ConfigurationSummary = this.path.Text + (!String.IsNullOrWhiteSpace(this.arguments.Text) ? (" -> " + this.arguments.Text) : "");
            }
            return true;
        }

        private void OnActionSave(object sender, EventArgs e)
        {
            
        }


        private void LoadConfig()
        {
            if (!String.IsNullOrWhiteSpace(this.pluginAction.Configuration))
            {
                try
                {
                    JObject configurationObject = JObject.Parse(this.pluginAction.Configuration);
                    this.path.Text = configurationObject["path"].ToString();
                    this.arguments.Text = configurationObject["arguments"].ToString();                    
                }
                catch { }
            }
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog
            {
                Title = "Start application",
                CheckFileExists = false,
                CheckPathExists = false,
                DefaultExt = "exe",
                Filter = "Applications (*.exe)|*.exe|Shortcuts (*.ink)|*.ink|All files (*.*)|*.*",
                SupportMultiDottedExtensions = true,
                ValidateNames = false,
                DereferenceLinks = false,
            })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    this.path.Text = openFileDialog.FileName;
                }
            }
        }


    }
}

