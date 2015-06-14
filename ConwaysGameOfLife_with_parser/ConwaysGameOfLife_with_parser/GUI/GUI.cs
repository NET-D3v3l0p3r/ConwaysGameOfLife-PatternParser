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
        bool isChoosingPatternPT;
        CGOFPatternsParser parser;
        public GUI()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(guiRenderer);
            this.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                Environment.Exit(Environment.ExitCode);
            });
            pbRenderer.MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                if (!isChoosingPatternPT)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        mainGame.gCgol.editCell(true, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        mainGame.gCgol.editCell(false, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                }
                else
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        mainGame.gCgol.addPatternToCellMap(parser.PatternMatrix, new Point(e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight));
                        isChoosingPatternPT = false;
                    }
                }
            });
            pbRenderer.MouseMove += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                if (!isChoosingPatternPT)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                        mainGame.gCgol.editCell(true, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                        mainGame.gCgol.editCell(false, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                }
                else
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        mainGame.gCgol.addPatternToCellMap(parser.PatternMatrix, new Point(e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight));
                        isChoosingPatternPT = false;
                    }
                }
            });
            
        }
        private void pbRenderer_Paint(object sender, PaintEventArgs e)
        {
            mainGame.Render(e.Graphics);
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
            mainGame.Run(65, 55);
            CheckForIllegalCrossThreadCalls = false;
        }

        private void run_bttn_Click(object sender, EventArgs e)
        {
            if (run_bttn.Text == "Run...")
            {
                run_bttn.Text = "Close..";
                btn_eddit.Enabled = false;
                interval_tb.Enabled = true;
            }
            else
            {
                run_bttn.Text = "Run...";
                interval_tb.Enabled = true;
                btn_eddit.Enabled = true;
            }
            mainGame.gCgol.applySettings();
        }

        private void btn_eddit_Click(object sender, EventArgs e)
        {
            mainGame.Interval = int.Parse(interval_tb.Text);
        }

        private void add_btn_Click(object sender, EventArgs e)
        {
            mainGame.gCgol.isEditing = true;
            OpenFileDialog fileDialogue = new OpenFileDialog();
            fileDialogue.ShowDialog();

            if(fileDialogue.FileName != null)
            {
                try
                {
                    parser = new CGOFPatternsParser(new Bitmap(fileDialogue.FileName));
                    parser.processParsing();
                    MessageBox.Show("Choose point with your mouse where the pattern should copy..!");
                    isChoosingPatternPT = true;
                }
                catch
                {

                }
            }

        }

    }
}
