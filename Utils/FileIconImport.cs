using System;
using ImageMagick;
using SuchByte.MacroDeck.Icons;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using SuchByte.WindowsUtils.GUI;
using System.Diagnostics;

namespace SuchByte.WindowsUtils.Utils
{
    public static class FileIconImport
    {

        public static void ImportIcon(string filePath)
        {
            using (var iconImportQuality = new MacroDeck.GUI.Dialogs.IconImportQuality())
            {
                if (iconImportQuality.ShowDialog() == DialogResult.OK)
                {
                    Image icon;


                    IntPtr hIcon = ShellIcon.GetJumboIcon(ShellIcon.GetIconIndex(filePath));

                    using (System.Drawing.Icon ico = System.Drawing.Icon.ExtractAssociatedIcon(filePath))
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
                                msgBox.ShowDialog("Import icon", "Failed to import the icon", MessageBoxButtons.OK);
                            }
                            return;
                        }

                        using (var iconPackSelector = new IconPackSelector())
                        {
                            if (iconPackSelector.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    IconPack iconPack = IconManager.GetIconPackByName(iconPackSelector.IconPack);
                                    IconManager.AddIconImage(iconPack, icon);
                                    using (var msgBox = new MacroDeck.GUI.CustomControls.MessageBox())
                                    {
                                        msgBox.ShowDialog("Import icon", "Icon successfully imported to " + iconPackSelector.IconPack, MessageBoxButtons.OK);
                                    }
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
        }

    }
}
