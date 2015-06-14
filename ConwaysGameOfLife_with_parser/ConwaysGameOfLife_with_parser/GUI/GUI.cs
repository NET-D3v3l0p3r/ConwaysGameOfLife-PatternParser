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
using ConwaysGameOfLife_with_parser.Core.CGOF;
namespace ConwaysGameOfLife_with_parser.GUI
{
    public partial class GUI : Form
    {
        Core.Core mainGame;
        public GUI()
        {
            InitializeComponent();

        }
        private void pbRenderer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guiRenderer(object sender, PaintEventArgs e)
        {
            pbRenderer.Invalidate();
        }

        private void GUI_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            ControlTools.SetDoubleBuffered(pbRenderer);
            mainGame = new Core.Core(this, new Rectangle(0, 0, 1350, 800));
        }

    }
}
