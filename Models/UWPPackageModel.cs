
namespace SuchByte.WindowsUtils.Models
{
    public class UWPPackageModel
    {
        public string DisplayName { get; private set; }

        public string Path { get; private set; }


        public UWPPackageModel(string name, string path)
        {
            DisplayName = name;
            Path = path;
        }
    }
}
