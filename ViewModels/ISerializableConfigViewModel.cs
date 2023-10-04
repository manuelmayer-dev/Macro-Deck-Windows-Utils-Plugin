using SuchByte.WindowsUtils.Models;

namespace SuchByte.WindowsUtils.ViewModels;

internal interface ISerializableConfigViewModel
{
    protected ISerializableConfiguration SerializableConfiguration { get; }

    void SetConfig();

    bool SaveConfig();
}
