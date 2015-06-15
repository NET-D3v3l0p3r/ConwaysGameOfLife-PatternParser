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

        int w = 0;
        bool isInitialized;

        public int CellWidth
        {
            get { return w; }
            set
            {
                if(isInitialized)
                    for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                        {
                            CellMap2D[i, j].SizeCell = new Size(w, w);
                        }
                    }
                w = value;
            }
        }
        public int CellHeight
        {
            get { return w; }
            set
            {
                if (isInitialized)
                    for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
                    {
                        for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                        {
                            CellMap2D[i, j].SizeCell = new Size(w, w);
                        }
                    }
                w = value;
            }
        }
        public bool isEditing { get; set; }

        private Random RAND = new Random();
        private ArrayDataLoader2D<Cell> matrix3x3;
        
        public ConwaysGameOfLife(Size _s)
        {
            CellWidth = _s.Width;
            CellHeight = _s.Height;
            isEditing = true;
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
            isInitialized = true;
        }
        public void Update()
        {
            if (!isEditing)
            {
                for (int i = 0; i < CellMap2D.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < CellMap2D.GetUpperBound(1); j++)
                    {
                        matrix3x3.moveTo(new Point(1, 1), new Point(i, j));
                        int count = countElements(matrix3x3);
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
                Parallel.For(0, CellMap2D.GetUpperBound(0) + 1, (int i) =>
                {
                    Parallel.For(0, CellMap2D.GetUpperBound(1) + 1, (int j) =>
                    {
                        CellMap2D[i, j].applyState();
                    });
                });
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
        public void addPatternToCellMap(bool[,] _patternMatrix, Point _pt)
        {
            for (int i = 0; i < _patternMatrix.GetUpperBound(0); i++)
            {
                for (int j = 0; j < _patternMatrix.GetUpperBound(1); j++)
                {
                    CellMap2D[_pt.X + i, _pt.Y + j] = new Cell(new Point(_pt.X + i, _pt.Y + j), new Size(CellWidth, CellHeight), Color.Black, Color.White, _patternMatrix[i, j]);
                }
            }
        }
        public void editCell(bool _state, int i, int j)
        {
            isEditing = true;
            try { CellMap2D[i, j] = new Cell(new Point(i, j), new Size(CellWidth, CellHeight), Color.Black, Color.White, _state); }
            catch { }
        }
        public void applySettings() { isEditing = !isEditing; }
        public void setCameraPosition(int x, int y)
        {
            if (isInitialized)
                for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                    {
                        CellMap2D[i, j].CameraPos = new Point(x, y);
                    }
                }
        }
        private int countElements(ArrayDataLoader2D<Cell> _matrix)
        {
            int counter = 0;
            for (int i = 0; i <= _matrix.Matrix2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= _matrix.Matrix2D.GetUpperBound(1); j++)
                {
                    if (_matrix[i, j] != null)
                        if (_matrix[i, j].isAlive)
                            counter++;
                }
            }
            if (_matrix[1, 1].isAlive)
                counter--;

            return counter;
        }


    }
}
