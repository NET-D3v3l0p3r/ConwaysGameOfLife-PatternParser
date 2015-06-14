using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Diagnostics;
namespace ConwaysGameOfLife_with_parser.Core.Parser
{
    /// <summary>
    /// ArrayDataLoader2D provides a matrix which locates all objects around the center of 
    /// the matrix
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ArrayDataLoader2D<T>
    {
        public T[,] Matrix2D { get; private set; }
        public T[,] MapData2D { get; private set; }

        public int MatrixWidth { get; private set; }
        public int MatrixHeight { get; private set; }

        public T this[int i, int j]
        {
            get { return Matrix2D[i, j]; }
            set { Matrix2D[i, j] = value; }
        }
    
        /// <summary>
        /// Initializes ArrayDataLoader2D
        /// </summary>
        /// <param name="mWidth"></param>
        /// <param name="mHeight"></param>
        /// <param name="map_data"></param>
        public ArrayDataLoader2D(int mWidth, int mHeight, T[,] map_data)
        {
            MatrixWidth = mWidth;
            MatrixHeight = mHeight;

            Matrix2D = new T[MatrixWidth, MatrixHeight];
            MapData2D = map_data;
        }
        /// <summary>
        /// Moves the matrix to the current position.
        /// [EXPLINATION]
        /// matrix_reference_point is the point which represents the center of the matrix
        /// array_data_point is the point which locates the coordinate of the MapData2D
        /// </summary>
        /// <param name="matrix_reference_point"></param>
        /// <param name="array_data_point"></param>
        /// <returns></returns>
        public ArrayDataLoader2D<T> moveTo(Point matrix_reference_point, Point array_data_point)
        {
            Point exPointW = new Point(-(matrix_reference_point.X), (Matrix2D.GetUpperBound(0) + matrix_reference_point.X) - (matrix_reference_point.X * 2));
            Point exPointH = new Point(-(matrix_reference_point.Y), (Matrix2D.GetUpperBound(1) + matrix_reference_point.Y) - (matrix_reference_point.Y * 2));

            int _i = -1;
            int _j = -1;

            for (int i = (array_data_point.X + exPointW.X); i <= (array_data_point.X + exPointW.Y); i++)
            {
                if (_i + 1 < MatrixWidth)
                    _i++;
                for (int j = (array_data_point.Y + exPointH.X); j <= (array_data_point.Y + exPointH.Y); j++)
                {
                    if (_j + 1 < MatrixHeight)
                        _j++;

                    if(i > -1 && j > -1 && i < MapData2D.GetUpperBound(0) && j < MapData2D.GetUpperBound(1))
                        Matrix2D[_i, _j] = MapData2D[i, j];
                    else
                        Matrix2D[_i, _j] = default(T);
                }
                _j = -1;
            }

            return this;
        }
        /// <summary>
        /// Returns the total count of an element which exist in the matrix
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public int findAndCountAmount(ArrayDataLoader2D<T> matrix, T element)
        {
            int counter = 0;
            for (int i = 0; i <= matrix.Matrix2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= matrix.Matrix2D.GetUpperBound(1); j++)
                {
                    if (matrix.Matrix2D[i, j].Equals(element))
                        counter++;
                }
            }
            return counter;
        }
        /// <summary>
        /// Converts the array matrix to string and formats it.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string arrayStr = "";

            for (int j = 0; j <= Matrix2D.GetUpperBound(1); j++)
            {
                arrayStr += Environment.NewLine + "(";
                for (int i = 0; i <= Matrix2D.GetUpperBound(0); i++)
                {
                    arrayStr += Matrix2D[i, j] + ";";
                }
                arrayStr += ")";
            }

            return arrayStr;
        }
    }
}
