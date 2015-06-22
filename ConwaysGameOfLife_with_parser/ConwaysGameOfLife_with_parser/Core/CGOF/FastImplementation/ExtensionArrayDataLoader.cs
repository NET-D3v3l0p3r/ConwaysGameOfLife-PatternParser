using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLife_with_parser.Core.CGOF.Parser;
using System.Drawing;
using ConwaysGameOfLife_with_parser.Core.Parser;
namespace ConwaysGameOfLife_with_parser.Core.CGOF.FastImplementation
{
    public static class Extensions
    {

        public static ArrayDataLoader2D<Point> moveWithoutBounds<T>(this IArrayDataLoader<T> array_data_loader, ArrayDataLoader2D<Point> _owner, Point matrix_reference_point, Point array_data_point)
        {
            Point exPointW = new Point(-(matrix_reference_point.X), (_owner.Matrix2D.GetUpperBound(0) + matrix_reference_point.X) - (matrix_reference_point.X * 2));
            Point exPointH = new Point(-(matrix_reference_point.Y), (_owner.Matrix2D.GetUpperBound(1) + matrix_reference_point.Y) - (matrix_reference_point.Y * 2));

            int _i = -1;
            int _j = -1;

            for (int i = (array_data_point.X + exPointW.X); i <= (array_data_point.X + exPointW.Y); i++)
            {
                if (_i + 1 < _owner.MatrixWidth)
                    _i++;
                for (int j = (array_data_point.Y + exPointH.X); j <= (array_data_point.Y + exPointH.Y); j++)
                {
                    if (_j + 1 < _owner.MatrixHeight)
                        _j++;


                    _owner.Matrix2D[_i, _j] = new Point(i, j);

                }
                _j = -1;
            }
            return _owner;
        }

    }
}
