using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using ConwaysGameOfLife_with_parser.Core.CGOF;
namespace ConwaysGameOfLife_with_parser.Core
{
    public class Core
    {
        public GUI.GUI MainGUI { get; private set; }
        public Rectangle Window { get; private set; }

        public bool isGameRunning { get; set; }
        public Thread gLoop { get; private set; }
        public int Interval { get; set; }
        public ConwaysGameOfLife gCgol { get; private set; }

        public Core(GUI.GUI _gui, Rectangle _rect, int _cellSize)
        {
            MainGUI = _gui;
            Window = _rect;
            MainGUI.Width = Window.Width;
            MainGUI.Height = Window.Height;
            gCgol = new ConwaysGameOfLife(new Size(_cellSize, _cellSize));
            gLoop = new Thread(new ThreadStart(Update));
            Interval = 1;
        }

        private void Update()
        {
            isGameRunning = !isGameRunning;
            while (isGameRunning)
            {
                gCgol.Update();
                Thread.Sleep(Interval);
                MainGUI.Invalidate();
            }
            gLoop.Join();
        }

        public void Run(int _w, int _h)
        {
            if (!isGameRunning)
            {
                gCgol.CreateMap(_w, _h);
                gLoop.Start();
            }
            else
                gLoop.Abort();
        }

        public void Render(Graphics g)
        {
            gCgol.Render(g);
        }
   
    }
}
