using SuchByte.MacroDeck.Logging;
using SuchByte.WindowsUtils.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuchByte.WindowsUtils.Services
{
    public class UWPManager
    {

        public static void GetInstalledPackagesAsync(Action<List<UWPPackageModel>> callback)
        {
            Task.Run(() =>
            {
                List<UWPPackageModel> installedApps = new List<UWPPackageModel>();
                try
                {
                    Windows.Management.Deployment.PackageManager packageManager = new Windows.Management.Deployment.PackageManager();
                    IEnumerable<Windows.ApplicationModel.Package> packages = packageManager.FindPackagesForUser("");
                    foreach (var package in packages.Where(p => !p.IsFramework).OrderBy(p => p.DisplayName))
                    {
                        try
                        {
                            var location = Path.Combine(Path.GetFullPath(package.InstalledLocation.Path), package.DisplayName, ".exe");
                            installedApps.Add(new UWPPackageModel(package.DisplayName, location));
                        } catch { }
                    }
                }
                catch (Exception ex)
                {
                    MacroDeckLogger.Error(Main.Instance, $"Failed to load installed UWP apps: {ex.Message + Environment.NewLine + ex.StackTrace}");
                }

                if (callback != null)
                {
                    callback(installedApps);
                }
            });
        }



    }
}
