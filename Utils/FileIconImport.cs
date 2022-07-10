using System;
using SuchByte.MacroDeck.Icons;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using SuchByte.WindowsUtils.GUI;
using System.Diagnostics;
using SuchByte.WindowsUtils.Language;
using SuchByte.WindowsUtils.Models;

namespace SuchByte.WindowsUtils.Utils
{
    public static class FileIconImport
    {

        public static IconImportModel ImportIcon(string filePath)
        {
            using (var iconImportQuality = new MacroDeck.GUI.Dialogs.IconImportQuality())
            {
                if (iconImportQuality.ShowDialog() == DialogResult.OK)
                {
                    Image icon;


                    IntPtr hIcon = ShellIcon.GetJumboIcon(ShellIcon.GetIconIndex(filePath));

                    using (System.Drawing.Icon ico = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(hIcon).Clone())
                    {
                        icon = iconImportQuality.Pixels >= 0 ? ImageResize.Resize(ico.ToBitmap(), iconImportQuality.Pixels, iconImportQuality.Pixels) : ico.ToBitmap();

                        if (icon == null)
                        {
                            using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                            {
                                msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, PluginLanguageManager.PluginStrings.FailedToImportIcon, MessageBoxButtons.OK);
                            }
                            return null;
                        }

                        using (var iconPackSelector = new IconPackSelector())
                        {
                            if (iconPackSelector.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    IconPack iconPack = IconManager.GetIconPackByName(iconPackSelector.IconPack);
                                    MacroDeck.Icons.Icon macroDeckIcon = IconManager.AddIconImage(iconPack, icon);
                                    using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                                    {
                                        msgBox.ShowDialog(PluginLanguageManager.PluginStrings.ImportIcon, String.Format(PluginLanguageManager.PluginStrings.IconSuccessfullyImportedToX, iconPackSelector.IconPack), MessageBoxButtons.OK);
                                    }
                                    return new IconImportModel()
                                    {
                                        IconPack = iconPack.Name,
                                        IconId = macroDeckIcon.IconId,
                                    };
                                }
                                catch { }
                            }
                        }
                    }
                }
            }

            return null;
        }

    }
}
