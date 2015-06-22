using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using ConwaysGameOfLife_with_parser.Core.CGOF;
using System.Diagnostics;
namespace ConwaysGameOfLife_with_parser.Core
{
    public class Core
    {
        public GUI.GUI MainGUI { get; private set; }
        public Rectangle Window { get; private set; }

        public bool isGameRunning { get; set; }

        public Stopwatch GameTime { get; private set; }
        public long CurrentTick { get; private set; }
        public long Interval { get; set; }

        public Thread gLoop { get; private set; }

        public ConwaysGameOfLifeV0_1 gCgol { get; private set; }

        public Core(GUI.GUI _gui, Rectangle _rect, int _cellSize)
        {
            MainGUI = _gui;
            Window = _rect;
            MainGUI.Width = Window.Width;
            MainGUI.Height = Window.Height;
            gCgol = new ConwaysGameOfLifeV0_1(new Size(_cellSize, _cellSize));

            GameTime = new Stopwatch();
            gLoop = new Thread(new ThreadStart(Update));
            Interval = 1;

            gCgol.RunGame();
        }

        private void Update()
        {
            isGameRunning = !isGameRunning;
            GameTime.Start();
            do
            {
                CurrentTick = GameTime.ElapsedMilliseconds;
                MainGUI.updateGame();
                while (GameTime.ElapsedMilliseconds - CurrentTick < Interval)
                {
                    MainGUI.pbRenderer.Invalidate();
                }
           
            } while (isGameRunning);

            GameTime.Stop();
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
