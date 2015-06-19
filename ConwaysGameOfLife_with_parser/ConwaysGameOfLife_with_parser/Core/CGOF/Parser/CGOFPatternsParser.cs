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

        public bool[,] PatternMatrix { get; private set; }
        public int PatternMatrixWidth { get; private set; }
        public int PatternmatrixHeight { get; private set; }

        private PatternAnalyzer patternAnalyzer;
        private ArrayDataLoader2D<bool> cellMatrix;
        public CGOFPatternsParser(Bitmap _pattern)
        {
            Pattern = _pattern;

            patternAnalyzer = new PatternAnalyzer(Pattern);
            patternAnalyzer.anaylzePattern();

            PatternMatrixWidth = (Pattern.Width - (patternAnalyzer.TotalStripes.Width * patternAnalyzer.StripeWidth)) / patternAnalyzer.CellWidth;
            PatternmatrixHeight = (Pattern.Height - (patternAnalyzer.TotalStripes.Height * patternAnalyzer.StripeHeight)) / patternAnalyzer.CellHeight;
            PatternMatrix = new bool[PatternMatrixWidth, PatternmatrixHeight];

            cellMatrix = new ArrayDataLoader2D<bool>(1, 1, convertColorMapToBoolMap(ColorTools.convertBitmapToArray(Pattern)));
        }
        public bool[,] convertColorMapToBoolMap(Color[,] _map)
        {
            bool[,] _tmp = new bool[_map.GetUpperBound(0), _map.GetUpperBound(1)];
            for (int i = 0; i < _map.GetUpperBound(0); i++) 
            {
                for (int j = 0; j < _map.GetUpperBound(1); j++) 
                {
                    _tmp[i, j] = _map[i, j] == patternAnalyzer.LivingCell;
                }
            }

            return _tmp;
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

            if (firstWhite.X <= firstBlack.X && firstWhite.Y <= firstBlack.Y)
                toUsePoint = firstWhite;
            else
                toUsePoint = firstBlack;

            for (int i = toUsePoint.X; i < Pattern.Width; i += stepI)
            {
                _i++;
                for (int j = toUsePoint.Y; j < Pattern.Height; j += stepJ)
                {
                    _j++;
                    cellMatrix.moveTo(new Point(0, 0), new Point(i, j));
                    PatternMatrix[_i, _j] = cellMatrix.Matrix2D[0, 0];
                }
                _j = -1;
            }
        }
    }
}
