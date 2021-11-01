using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Icons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI
{
    public partial class IconPackSelector : DialogForm
    {

        public string IconPack
        {
            get
            {
                return this.iconPacks.Text;
            }
        }

        public IconPackSelector()
        {
            InitializeComponent();

            if (IconManager.IconPacks.FindAll(i => !i.PackageManagerManaged).Count == 0)
            {
                IconManager.CreateIconPack("Imported icons", Environment.UserName, "1.0.0");
                IconManager.SaveIconPacks();
            }

            foreach (IconPack iconPack in IconManager.IconPacks.FindAll(i => !i.PackageManagerManaged))
            {
                this.iconPacks.Items.Add(iconPack.Name);
            }
            this.iconPacks.SelectedIndex = 0;
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
