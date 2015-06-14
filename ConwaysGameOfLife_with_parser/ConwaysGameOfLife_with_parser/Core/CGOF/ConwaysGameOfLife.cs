using ConwaysGameOfLife_with_parser.Core.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife_with_parser.Core.CGOF
{
    public class ConwaysGameOfLife
    {
        public Cell[,] CellMap2D { get; set; }

        public int CellWidth { get; private set; }
        public int CellHeight { get; private set; }

        private Random RAND = new Random();
        private ArrayDataLoader2D<Cell> matrix3x3;

        public ConwaysGameOfLife(Size _s)
        {
            CellWidth = _s.Width;
            CellHeight = _s.Height;
        }

        public void CreateMap(int _w, int _h)
        {
            CellMap2D = new Cell[_w, _h];
            for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                {
                    CellMap2D[i, j] = new Cell(new Point(i, j), new Size(CellWidth, CellHeight), Color.Black, Color.White, false);
                }
            }
            matrix3x3 = new ArrayDataLoader2D<Cell>(3, 3, CellMap2D);
        }

        public void Update()
        {
            for (int i = 0; i < CellMap2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j < CellMap2D.GetUpperBound(1); j++)
                {
                    matrix3x3.moveTo(new Point(1, 1), new Point(i, j));
                    int count = countElements(matrix3x3, true);

                    if (CellMap2D[i, j].isAlive)
                    {
                        if (count > 3)
                            CellMap2D[i, j].setNextRound(false);
                        else if (count < 2)
                            CellMap2D[i, j].setNextRound(false);
                        else if (count == 3)
                            CellMap2D[i, j].setNextRound(true);
                        else if (count == 2)
                            CellMap2D[i, j].setNextRound(true);
                    }
                    else
                        if (count == 3)
                            CellMap2D[i, j].setNextRound(true);
                    }

                
            }

            for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                {
                    CellMap2D[i, j].applyState();
                }
            }
        }
        public void Render(Graphics g)
        {
            for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                {
                    CellMap2D[i, j].Render(g);
                }
            }
        }

        private int countElements(ArrayDataLoader2D<Cell> _matrix, bool _state)
        {
            int counter = 0;
            for (int i = 0; i <= _matrix.Matrix2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= _matrix.Matrix2D.GetUpperBound(1); j++)
                {
                    if (_matrix[i, j] != null)
                        if (_matrix[i, j].isAlive == _state)
                            counter++;
                }
            }
            if (_matrix[1, 1].isAlive)
                counter--;

            return counter;
        }
    }
}
