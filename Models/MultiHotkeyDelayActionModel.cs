using System.Threading;

namespace SuchByte.WindowsUtils.Models;

public class MultiHotkeyDelayActionModel : IMultiHotkeyAction
{
    public int DelayLengthMs { get; set; } = 100;

    public void Execute()
    {
        Thread.Sleep(this.DelayLengthMs);
    }
}
