using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConwaysGameOfLife_with_parser.Tools
{
    public static class ColorTools
    {
        public static List<Color> getAndSortAvaiblePixels(Bitmap _image)
        {
            Bitmap t = _image;
            LockBitmap lockBits = new LockBitmap(t);
            Dictionary<Color, int> dict = new Dictionary<Color, int>();
            lockBits.LockBits();
            for (int x = 0; x < t.Width; x++)
            {
                for (int y = 0; y < t.Height; y++)
                {
                    Color argb = lockBits.GetPixel(x, y);
                    if (!dict.Keys.Contains(argb))
                        dict.Add(argb, 1);
                    else
                        dict[argb] = dict[argb] + 1;
                }
            }
            lockBits.UnlockBits();
            dict = dict.OrderBy(i => i.Value).ToDictionary(i => i.Key, i => i.Value);
            return dict.Keys.ToList();
        }
        public static List<Color> getAndSortBrightestPixel(Bitmap _image)
        {
            Bitmap t = _image;
            Dictionary<Color, float> dict = new Dictionary<Color, float>();
            for (int x = 0; x < t.Width; x++)
            {
                for (int y = 0; y < t.Height; y++)
                {
                    Color argb = t.GetPixel(x, y);
                    if (!dict.Keys.Contains(argb))
                        dict.Add(argb, argb.GetBrightness());
                }
            }
            dict = dict.OrderBy(i => i.Value).ToDictionary(j => j.Key, j => j.Value);
            return dict.Keys.ToList();
        }
        public static Point getCoordinateOfFirstPixel(Bitmap _image, Color _pixel)
        {
            Bitmap t = _image;
            for (int x = 0; x < t.Width; x++)
            {
                for (int y = 0; y < t.Height; y++)
                {
                    Color argb = t.GetPixel(x, y);
                    if (argb == _pixel)
                    {
                        return new Point(x, y);
                    }
                }
            }

            throw new Exception("Pixel doesn't exist!");
        }
        public static Color[,] convertBitmapToArray(Bitmap _image)
        {
            Color[,] data2d = new Color[_image.Width, _image.Height];
            for (int i = 0; i < data2d.GetUpperBound(0); i++)
            {
                for (int j = 0; j < data2d.GetUpperBound(1); j++)
                {
                    data2d[i, j] = _image.GetPixel(i, j); 
                }
            }
            return data2d;
        }
    }
}
