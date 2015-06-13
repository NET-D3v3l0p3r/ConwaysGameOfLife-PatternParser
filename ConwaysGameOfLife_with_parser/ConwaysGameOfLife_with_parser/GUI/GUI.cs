using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ConwaysGameOfLife_with_parser.Tools;
using ConwaysGameOfLife_with_parser.Core.Parser;
using ConwaysGameOfLife_with_parser.Core.CGOF.Parser;
namespace ConwaysGameOfLife_with_parser.GUI
{
    public partial class GUI : Form
    {
        public GUI()
        {
            InitializeComponent();
        }

        private void pbRenderer_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < parser.PatternMatrixWidth; i++)
            {
                for (int j = 0; j < parser.PatternmatrixHeight; j++)
                {
                    if (parser.PatternMatrix[i, j] == Color.Black)
                        e.Graphics.FillRectangle(Brushes.White, new Rectangle(i * 15, j * 15, 14, 14));
                }
            }
        }

        private void guiRenderer(object sender, PaintEventArgs e)
        {
        }
        CGOFPatternsParser parser;
        private void GUI_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            ControlTools.SetDoubleBuffered(pbRenderer);

            Bitmap t = new Bitmap(@"Pattern\" + Microsoft.VisualBasic.Interaction.InputBox("Image file: ") + ".png");
            parser = new CGOFPatternsParser(t);
            parser.processParsing();
        }
    }
}
