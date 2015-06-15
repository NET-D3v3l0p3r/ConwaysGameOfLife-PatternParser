using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConwaysGameOfLife_with_parser.Tools;
using System.Diagnostics;
namespace ConwaysGameOfLife_with_parser.Core.Parser
{
    public class PatternAnalyzer
    {
        public Bitmap Pattern { get; private set; }

        public int CellWidth { get; private set; }
        public int CellHeight { get; private set; }
        
        public int StripeWidth { get; private set; }
        public int StripeHeight { get; private set; }
        public Size TotalStripes { get; private set; }

        public Color DeadCell { get; private set; }
        public Color LivingCell { get; private set; }
        public Color Stripe { get; private set; }

        private LockBitmap lockBits;
        private ArrayDataLoader2D<Color> ColorMatrix;

        public PatternAnalyzer(Bitmap pattern)
        {
            Pattern = pattern;
            lockBits = new LockBitmap(Pattern);
        }

        /// <summary>
        /// Starts analyzing and recognize pattern data
        /// </summary>
        public void anaylzePattern()
        {
            var colors = ColorTools.getAndSortBrightestPixel(Pattern);

            if (colors.Count > 3)
                throw new Exception("Pattern is not supported ...(yet.. update 0.2 will fix it.. biiznillah!)");

            DeadCell = colors[colors.Count - 1];
            Stripe = colors[colors.Count - 2];
            LivingCell = colors[colors.Count - 3];

            Size cellSize = getCellSize();
            CellWidth = cellSize.Width;
            CellHeight = cellSize.Height;

            Size stripeSize = getStripeSize();
            StripeWidth = stripeSize.Width;
            StripeHeight = stripeSize.Height;
            TotalStripes = getTotalCountStripesAndDevideBySize();
        }
        private Size getCellSize()
        {
            Point firstWhite = ColorTools.getCoordinateOfFirstPixel(Pattern, DeadCell);
            int width = 0;
            int height = 0;
            for (int i = firstWhite.X; i < Pattern.Width; i++)
            {
                if (Pattern.GetPixel(i, firstWhite.Y) != DeadCell)
                    break;
                width++;
            }
            for (int j = firstWhite.Y; j < Pattern.Height; j++)
            {
                if (Pattern.GetPixel(firstWhite.X, j) != DeadCell)
                    break;
                height++;
            }
            return new Size(width, height);  //TODO
        }
        private Size getStripeSize()
        {
            int size = 1;
            Point stripePoint = new Point();
            ColorMatrix = new ArrayDataLoader2D<Color>(3, 3, ColorTools.convertBitmapToArray(Pattern));
            bool set = false;
            for (int i = 1; i < Pattern.Width - 1; i++)
            {
                for (int j = 1; j < Pattern.Height - 1; j++)
                {
                    ArrayDataLoader2D<Color> tmp = ColorMatrix.moveTo(new Point(1, 1), new Point(i, j));
                    if (Pattern.GetPixel(i, j) == Stripe)
                    {
                        if (tmp.Matrix2D[0, 1] == LivingCell || tmp.Matrix2D[0, 1] == DeadCell)
                        {
                            stripePoint = new Point(i, j);
                            set = !set;
                            break;
                        }
                    }
                }
                if (set)
                    break;
            }
            for (int i = stripePoint.X; i < Pattern.Width; i++)
            {
                var tmp = ColorMatrix.moveTo(new Point(1, 1), new Point(i, stripePoint.Y));
                if (tmp.Matrix2D[2, 1] == LivingCell || tmp.Matrix2D[2, 1] == DeadCell)
                    break;
                else
                    size++;
            }
            return new Size(size, size);
        }
        private Size getTotalCountStripesAndDevideBySize()
        {
            Size size = new Size(StripeWidth, StripeHeight);
            Func<int, int> getM = (int n) =>
            {
                return (int)(((double)n / 2.0) + ((n % 2.0 != 0) ? 0.5 : 0.0));
            };
            Point firstWhite = ColorTools.getCoordinateOfFirstPixel(Pattern, DeadCell);
            int cell_m_horizontal = getM(firstWhite.X + (CellWidth - 1));
            int cell_m_vertical = getM(firstWhite.Y + (CellHeight - 1));
            Color[,] colorMap = ColorTools.convertBitmapToArray(Pattern);
            ColorMatrix = new ArrayDataLoader2D<Color>(1, 1, colorMap);
            for (int i = 0; i <= Pattern.Height; i++)
            {
                var tmp = ColorMatrix.moveTo(new Point(0, 0), new Point(cell_m_horizontal, i));
                size.Width += (tmp.Matrix2D[0, 0] == Stripe) ? 1 : 0;
            }
            for (int i = 0; i <= Pattern.Width; i++)
            {
                var tmp = ColorMatrix.moveTo(new Point(0, 0), new Point(i, cell_m_vertical));
                size.Height += (tmp.Matrix2D[0, 0] == Stripe) ? 1 : 0;
            }
            return new Size(size.Height / StripeHeight, size.Width / StripeWidth);
        }
    }
}
