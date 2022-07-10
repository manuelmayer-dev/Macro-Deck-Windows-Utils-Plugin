using System;
using ImageMagick;
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
                        icon = ico.ToBitmap();

                        Cursor.Current = Cursors.WaitCursor;
                        try
                        {
                            var file = Path.Combine(MacroDeck.MacroDeck.TempDirectoryPath, "fileicon.original");
                            icon.Save(file, ImageFormat.Png);
                            using (var collection = new MagickImageCollection(new FileInfo(file)))
                            {
                                collection.Coalesce();
                                if (iconImportQuality.Pixels >= 0)
                                {
                                    foreach (var image in collection)
                                    {
                                        image.Resize(iconImportQuality.Pixels, iconImportQuality.Pixels);
                                        image.Quality = 100;
                                        image.Crop(iconImportQuality.Pixels, iconImportQuality.Pixels);
                                    }
                                }
                                collection.Write(MacroDeck.MacroDeck.TempDirectoryPath + new FileInfo(file).Name + ".resized");
                                byte[] imageBytes = File.ReadAllBytes(MacroDeck.MacroDeck.TempDirectoryPath + new FileInfo(file).Name + ".resized");
                                using (var ms = new MemoryStream(imageBytes))
                                {
                                    icon = Image.FromStream(ms);
                                }
                            }
                        }
                        catch { }
                        Cursor.Current = Cursors.Default;


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
