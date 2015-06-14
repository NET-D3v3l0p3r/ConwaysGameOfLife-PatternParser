using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
namespace ConwaysGameOfLife_with_parser.Core
{
    public class Core
    {
        public GUI.GUI MainGUI { get; private set; }
        public Rectangle Window { get; private set; }
        public bool isGameRunning { get; private set; }

        private Thread gLoop;
        public Core(GUI.GUI _gui, Rectangle _rect)
        {
            MainGUI = _gui;
            Window = _rect;
            MainGUI.Width = Window.Width;
            MainGUI.Height = Window.Height;

            gLoop = new Thread(new ThreadStart(Update));
        }

        private void Update()
        {
            isGameRunning = !isGameRunning;
            while (isGameRunning)
            {
                
                Thread.Sleep(1);
                MainGUI.Invalidate();
            }
            gLoop.Join();
        }

        public void Run()
        {
            if (!isGameRunning)
                gLoop.Start();
            else
                gLoop.Abort();
        }

        public void Render(Graphics g)
        {

        }
   
    }
}
