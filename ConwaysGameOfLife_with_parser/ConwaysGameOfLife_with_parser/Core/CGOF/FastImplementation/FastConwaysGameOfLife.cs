using ConwaysGameOfLife_with_parser.Core.Parser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConwaysGameOfLife_with_parser.Core.CGOF.FastImplementation;
using System.Diagnostics;
namespace ConwaysGameOfLife_with_parser.Core.CGOF.FastImplementation
{
    public class FastConwaysGameOfLife
    {
        public List<Cell> CellList = new List<Cell>();
        private ArrayDataLoader2D<Point> PointMatrix = new ArrayDataLoader2D<Point>(3, 3, null);

        public FastConwaysGameOfLife(int cell_scale, Color living_cell_color, Color dead_cell_color)
        {
            Cell.Scale = cell_scale;
            Cell.LiveCellColor = living_cell_color;
            Cell.DeadCellColor = dead_cell_color;
        }

        public void updateGraphics()
        {
            int neighbours = 0;
            for (int i = 0; i < CellList.Count; i++)
            {
                if (CellList[i].CurrentStatus)
                {
                    neighbours = countNeighboursOfCell(CellList[i].Position);
                    if (neighbours > 3)
                        CellList[i].setNextRound(false);
                    else if (neighbours < 2)
                        CellList[i].setNextRound(false);
                    else if (neighbours == 3)
                        CellList[i].setNextRound(true);
                    else if (neighbours == 2)
                        CellList[i].setNextRound(true);
                }
                else if (!CellList[i].CurrentStatus)
                {
                    neighbours = countNeighboursOfCell(CellList[i].Position);
                    if (neighbours == 3)
                        CellList[i].setNextRound(true);
                }
            }

                applyNextRound();
        }
        public int countNeighboursOfCell(Point current_position)
        {
            int counter = 0;
            PointMatrix.moveWithoutBounds(PointMatrix, new Point(1, 1), current_position);

            for (int i = 0; i < PointMatrix.MatrixWidth; i++)
            {
                for (int j = 0; j < PointMatrix.MatrixHeight; j++)
                {
                    foreach (var cell in CellList)
                    {
                        if (cell.Position != current_position)
                            if (cell.Position == PointMatrix[i, j] && cell.CurrentStatus)
                                counter++;
                    }
                }
            }

            return counter;
        }
        private void findDeadCellsAroundLivingCell(Cell living_cell)
        {
            PointMatrix.moveWithoutBounds(PointMatrix, new Point(1, 1), living_cell.Position);
            for (int i = 0; i < PointMatrix.MatrixWidth; i++)
            {
                for (int j = 0; j < PointMatrix.MatrixHeight; j++)
                {
                    if (PointMatrix[i, j] != living_cell.Position)
                        if (!CellList.Exists(p => p.Position.X == PointMatrix[i, j].X && p.Position.Y == PointMatrix[i, j].Y && p.CurrentStatus == true) && !CellList.Exists(p => p.Position.X == PointMatrix[i, j].X && p.Position.Y == PointMatrix[i, j].Y && p.CurrentStatus == false))
                        {
                            var tmp = new Cell(PointMatrix[i, j], false);
                            CellList.Add(tmp);
                            sortList();

                        }
                }
            }
        }
        private void sortList()
        {
            CellList = CellList.OrderBy(p => p.Position.X).ThenBy(p => p.Position.Y).ToList();
        }
        public void addLivingCell(Point cell_position)
        {
            Cell living_cell = new Cell(cell_position, true);
            for (int i = 0; i < CellList.Count; i++)
            {
                if (CellList[i].Position == living_cell.Position && CellList[i].CurrentStatus == living_cell.CurrentStatus)
                {
                    return;
                }
                else
                    if (CellList[i].Position == living_cell.Position && !CellList[i].CurrentStatus)
                    {
                        CellList[i] = living_cell;
                        findDeadCellsAroundLivingCell(CellList[i]);
                        return;
                    }
            }

            CellList.Add(living_cell);
            sortList();
            findDeadCellsAroundLivingCell(living_cell);
        }
        public void filterAllDeadCells()
        {
            CellList.RemoveAll(p => !p.CurrentStatus);
        }
        public void applyNextRound()
        {
            CellList.ForEach(p => p.applyNextRound());
            filterAllDeadCells();
            loadAllDeadCellsOfCellList();
        }
        public void loadAllDeadCellsOfCellList()
        {
            for (int i = 0; i < CellList.Count; i++)
            {
                if (CellList[i].CurrentStatus)
                    findDeadCellsAroundLivingCell(CellList[i]);
            }
        }

        public void renderGraphics(Graphics g)
        {
            CellList.ForEach(p => p.renderCell(g));
        }

    }
}
