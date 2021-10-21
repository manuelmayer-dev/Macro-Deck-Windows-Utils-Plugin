using Newtonsoft.Json.Linq;
using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.WindowsUtils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WindowsInput.Native;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class HotkeyConfigurator : ActionConfigControl
    {

        HotkeyAction _macroDeckAction;
        public HotkeyConfigurator(HotkeyAction macroDeckAction)
        {
            this._macroDeckAction = macroDeckAction;
            InitializeComponent();

            foreach (VirtualKeyCode keyCode in (VirtualKeyCode[])Enum.GetValues(typeof(VirtualKeyCode)))
            {
                this.key.Items.Add(keyCode);
            }
            if (macroDeckAction.Configuration != null && macroDeckAction.Configuration.Length > 0)
            {
                JObject jObject = JObject.Parse(macroDeckAction.Configuration);
                if (jObject != null)
                {
                    this.checkLWin.Checked = Boolean.Parse(jObject["lwin"].ToString());
                    this.checkRWin.Checked = Boolean.Parse(jObject["rwin"].ToString());
                    this.checkCtrl.Checked = Boolean.Parse(jObject["ctrl"].ToString());
                    this.checkLCtrl.Checked = Boolean.Parse(jObject["lctrl"].ToString());
                    this.checkRCtrl.Checked = Boolean.Parse(jObject["rctrl"].ToString());
                    this.checkShift.Checked = Boolean.Parse(jObject["shift"].ToString());
                    this.checkLShift.Checked = Boolean.Parse(jObject["lshift"].ToString());
                    this.checkRShift.Checked = Boolean.Parse(jObject["rshift"].ToString());
                    this.checkAlt.Checked = Boolean.Parse(jObject["alt"].ToString());
                    this.checkLAlt.Checked = Boolean.Parse(jObject["lalt"].ToString());
                    this.checkRAlt.Checked = Boolean.Parse(jObject["ralt"].ToString());
                    this.key.Text = jObject["key"].ToString();
                }
            }
            this.checkLWin.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkRWin.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkCtrl.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkLCtrl.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkRCtrl.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkShift.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkLShift.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkRShift.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkAlt.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkLAlt.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.checkRAlt.CheckedChanged += new EventHandler(this.Check_CheckedChanged);
            this.key.SelectedIndexChanged += new EventHandler(this.Key_SelectedIndexChanged);
        }

        private void LblDetails_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var p = new Process
            {
                StartInfo = new ProcessStartInfo("https://github.com/HavenDV/H.InputSimulator/blob/master/src/libs/H.InputSimulator/Native/VirtualKeyCode.cs")
                {
                    UseShellExecute = true
                }
            };
            p.Start();
        }

        private void Key_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateConfig();
        }

        private void Check_CheckedChanged(object sender, EventArgs e)
        {
            this.UpdateConfig();
        }

        private void UpdateConfig()
        {
            JObject jObject = new JObject
            {
                ["lwin"] = checkLWin.Checked.ToString(),
                ["rwin"] = checkRWin.Checked.ToString(),
                ["ctrl"] = checkCtrl.Checked.ToString(),
                ["lctrl"] = checkLCtrl.Checked.ToString(),
                ["rctrl"] = checkRCtrl.Checked.ToString(),
                ["shift"] = checkShift.Checked.ToString(),
                ["lshift"] = checkLShift.Checked.ToString(),
                ["rshift"] = checkRShift.Checked.ToString(),
                ["alt"] = checkAlt.Checked.ToString(),
                ["lalt"] = checkLAlt.Checked.ToString(),
                ["ralt"] = checkRAlt.Checked.ToString(),
                ["key"] = this.key.Text.ToString()
            };
            if (this.key.Text.Length > 0)
            {
                this._macroDeckAction.Configuration = jObject.ToString();
            }
            this._macroDeckAction.DisplayName = this._macroDeckAction.Name + " -> " +
                (checkLWin.Checked ? "lwin + " : "") + (checkRWin.Checked ? "rwin + " : "") +
                (checkLCtrl.Checked ? "lctrl + " : "") + (checkRCtrl.Checked ? "rctrl + " : "") + (checkCtrl.Checked ? "ctrl + " : "") + 
                (checkLShift.Checked ? "lshift + " : "") + (checkRShift.Checked ? "rshift + " : "") + (checkShift.Checked ? "shift + " : "") +
                (checkLAlt.Checked ? "lalt + " : "") + (checkRAlt.Checked ? "ralt + " : "") + (checkAlt.Checked ? "alt + " : "") +
                key.Text;
        }
    }
}
