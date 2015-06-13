using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ConwaysGameOfLife_with_parser.Core.Parser;
using ConwaysGameOfLife_with_parser.Tools;
using System.Windows.Forms;
using System.Diagnostics;
namespace ConwaysGameOfLife_with_parser.Core.CGOF.Parser
{
    public class CGOFPatternsParser
    {
        public Bitmap Pattern { get; private set; }

        public Color[,] PatternMatrix { get; private set; }
        public int PatternMatrixWidth { get; private set; }
        public int PatternmatrixHeight { get; private set; }

        private PatternAnalyzer patternAnalyzer;
        private ArrayDataLoader2D<Color> colorMatrix;
        public CGOFPatternsParser(Bitmap _pattern)
        {
            Pattern = _pattern;

            patternAnalyzer = new PatternAnalyzer(Pattern);
            patternAnalyzer.anaylzePattern();

            PatternMatrixWidth = (Pattern.Width - (patternAnalyzer.TotalStripes.Width * patternAnalyzer.StripeWidth)) / patternAnalyzer.CellWidth;
            PatternmatrixHeight = (Pattern.Height - (patternAnalyzer.TotalStripes.Height * patternAnalyzer.StripeHeight)) / patternAnalyzer.CellHeight;
            PatternMatrix = new Color[PatternMatrixWidth, PatternmatrixHeight];

            colorMatrix = new ArrayDataLoader2D<Color>(1, 1, ColorTools.convertBitmapToArray(Pattern));
        }

        public void processParsing()
        {
            int stepI = patternAnalyzer.CellWidth + patternAnalyzer.StripeWidth;
            int stepJ = patternAnalyzer.CellHeight + patternAnalyzer.StripeHeight;

            Point firstWhite = ColorTools.getCoordinateOfFirstPixel(Pattern, patternAnalyzer.DeadCell);
            Point firstBlack = ColorTools.getCoordinateOfFirstPixel(Pattern, patternAnalyzer.LivingCell);
            Point toUsePoint = new Point();

            int _i = -1;
            int _j = -1;

            if (firstWhite.X < firstBlack.X && firstWhite.Y < firstBlack.Y)
                toUsePoint = firstWhite;
            else
                toUsePoint = firstBlack;

            for (int i = toUsePoint.X; i < Pattern.Width; i += stepI)
            {

                _i++;
                for (int j = toUsePoint.Y; j < Pattern.Height; j += stepJ)
                {
                    _j++;
                    ArrayDataLoader2D<Color> tmp = colorMatrix.moveTo(new Point(0, 0), new Point(i, j));

                    if (tmp.Matrix2D[0, 0] == patternAnalyzer.LivingCell)
                        PatternMatrix[_i, _j] = Color.Black;
                    else
                        PatternMatrix[_i, _j] = Color.White;

                }
                _j = -1;
            }
        }
    }
}
