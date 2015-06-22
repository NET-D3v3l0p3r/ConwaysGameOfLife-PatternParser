using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ConwaysGameOfLife_with_parser.Core.CGOF.FastImplementation
{
    public class Cell : IEquatable<Cell>
    {
        public Point Position { get; private set; }
        
        public bool CurrentStatus { get; set; }
        public bool StatusNextRound { get; private set; }

        public static int Scale { get; set; }
        
        public static Color LiveCellColor { get; set; }
        public static Color DeadCellColor { get; set; }


        public Cell(Point postion_cell, bool spawn_status)
        {
            Position = postion_cell;
            CurrentStatus = spawn_status;
        }

        public void setNextRound(bool status_next_round)
        {
            StatusNextRound = status_next_round;
        }

        public void applyNextRound()
        {
            CurrentStatus = StatusNextRound;
        }

        public void renderCell(Graphics g)
        {
            Brush solidBrush = null;
            if (CurrentStatus)
                solidBrush = new SolidBrush(LiveCellColor);
            else
                solidBrush = new SolidBrush(DeadCellColor);

            g.FillRectangle(solidBrush, new Rectangle(Position.X * Scale, Position.Y * Scale, Scale, Scale));
            g.DrawRectangle(Pens.Black, new Rectangle(Position.X * Scale, Position.Y * Scale, Scale, Scale));

        }

        public bool Equals(Cell other)
        {
            return this.Position.X == other.Position.X && this.Position.Y == other.Position.Y && this.CurrentStatus == other.CurrentStatus;
        }

        public override string ToString()
        {
            return Position.ToString() + "; STATUS_ALIVE=" + CurrentStatus.ToString();
        }
    }
}
