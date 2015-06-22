using ConwaysGameOfLife_with_parser.Core.Parser;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConwaysGameOfLife_with_parser.Core.CGOF
{
    public class ConwaysGameOfLifeV0_1
    {
        int w = 0;
        bool isInitialized;

        public Cell[,] CellMap2D { get; set; }
        public int MapWidth { get; private set; }
        public int MapHeight { get; private set; }
        
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
        private bool operationIsRunning;
        
        private Thread gThread;
        private bool isRunning;

        public ConwaysGameOfLifeV0_1(Size _s)
        {
            CellWidth = _s.Width;
            CellHeight = _s.Height;
            isEditing = true;
            gThread = new Thread(new ThreadStart(updateGame));
        }

        public void CreateMap(int _w, int _h)
        {
            while (operationIsRunning) { }
            CellMap2D = new Cell[_w, _h];
            for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                {
                    CellMap2D[i, j] = new Cell(new Point(i, j), new Size(CellWidth, CellHeight), Color.Black, Color.White, false);
                }
            }
            matrix3x3 = new ArrayDataLoader2D<Cell>(3, 3, CellMap2D);
            MapWidth = _w;
            MapHeight = _h;
            isInitialized = true;
        }
        public void RunGame()
        {
            if (!isRunning)
            {
                gThread.Start();
                isRunning = true;
            }
            else
                isRunning = false;
        }
        private void updateGame()
        {
            while (isRunning)
            {
                if (!isEditing)
                {
                    operationIsRunning = true;
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
                    operationIsRunning = false;
                }
            }
        }
        public void Render(Graphics g)
        {
            for (int i = 0; i <= CellMap2D.GetUpperBound(0) - 1; i++)
            {
                for (int j = 0; j <= CellMap2D.GetUpperBound(1) - 1; j++)
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
        public void applySettings()
        {
            isEditing = !isEditing;
        }
        public void setCameraPosition(int x, int y)
        {
            if (isInitialized)
                for (int i = 0; i <= CellMap2D.GetUpperBound(0); i++)
                {
                    for (int j = 0; j <= CellMap2D.GetUpperBound(1); j++)
                    {
                        //if (x < 5 && x > -((CellMap2D[i, j].SizeCell.Width * MapWidth) / 5) + 10 && y < 5 && y > -((CellMap2D[i, j].SizeCell.Height * MapHeight) / 5) + 10)
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
