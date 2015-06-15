using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConwaysGameOfLife_with_parser.Core.CGOF
{
    public class Cell
    {
        public Point PositionArray { get; private set; }
        public Point CameraPos { get; set; }
        public Size SizeCell { get; set; }
        public Color CellColorAlive { get; set; }
        public Color CellColorDead { get; set; }
        public bool isAlive { get; private set; }
        public bool statusNextRound { get; private set; }

        public Cell(Point _pt, Size _s, Color _alive, Color _dead, bool _state)
        {
            PositionArray = _pt;
            SizeCell = _s;
            CellColorAlive = _alive;
            CellColorDead = _dead;
            isAlive = _state;
        }

        public Cell() { }

        public void setNextRound(bool _state)
        {
            statusNextRound = _state;
        }

        public void applyState()
        {
            isAlive = statusNextRound;
        }

        public void Render(Graphics g)
        {
            Brush renderColor = isAlive ? new SolidBrush(CellColorAlive) : new SolidBrush(CellColorDead);
            g.FillRectangle(renderColor, PositionArray.X * SizeCell.Width +CameraPos.X , PositionArray.Y * SizeCell.Height + CameraPos.Y, SizeCell.Width - 1, SizeCell.Height - 1);
        }

        public override string ToString()
        {
            return PositionArray.ToString() + "[STATE]" + isAlive + "[NEWSTATE]" + statusNextRound;
        }

    }
}
