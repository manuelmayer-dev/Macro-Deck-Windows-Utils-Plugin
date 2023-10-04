using SuchByte.MacroDeck.GUI.CustomControls;
using SuchByte.MacroDeck.Icons;
using SuchByte.MacroDeck.Language;
using System;
using System.Windows.Forms;

namespace SuchByte.WindowsUtils.GUI;

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

        this.btnOk.Text = LanguageManager.Strings.Ok;

        if (IconManager.IconPacks.FindAll(i => !i.ExtensionStoreManaged).Count == 0)
        {
            IconManager.CreateIconPack("Imported icons", Environment.UserName, "1.0.0");
        }

        foreach (IconPack iconPack in IconManager.IconPacks.FindAll(i => !i.ExtensionStoreManaged))
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
