using System.Drawing;

namespace SuchByte.WindowsUtils.Utils;

public class ImageResize
{

    public static Bitmap Resize(Bitmap original, int width, int height)
    {
        Bitmap result = new Bitmap(width, height);
        using (Graphics g = Graphics.FromImage(result))
        {
            g.DrawImage(original, 0, 0, width, height);
        }

        return result;
    }


}
