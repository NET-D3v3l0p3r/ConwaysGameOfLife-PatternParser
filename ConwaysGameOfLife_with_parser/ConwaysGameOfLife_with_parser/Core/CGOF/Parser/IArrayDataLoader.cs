using ConwaysGameOfLife_with_parser.Core.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife_with_parser.Core.CGOF.Parser
{
    public interface IArrayDataLoader<T>
    {
        T[,] Matrix2D { get; set; }
        T[,] MapData2D { get; set; }

        int MatrixWidth { get; set; }
        int MatrixHeight { get; set; }

        ArrayDataLoader2D<T> moveTo(Point matrix_reference_point, Point array_data_point);
    }
}
