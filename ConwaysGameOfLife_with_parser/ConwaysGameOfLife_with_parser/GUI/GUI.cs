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
using System.Threading;
using System.Diagnostics;
namespace ConwaysGameOfLife_with_parser.GUI
{
    public partial class GUI : Form
    {
        private Core.Core mainGame;
        
        private bool isChoosingPatternPT;
        private CGOFPatternsParser parser;
        private Point mousePoint = new Point();
        private int s_width_height_cell = 15;
        private int x = 0;
        private int y = 0;
        public GUI()
        {
            InitializeComponent();
            this.Paint += new PaintEventHandler(guiRenderer);
            this.FormClosing += new FormClosingEventHandler((object sender, FormClosingEventArgs e) =>
            {
                mainGame.Run(0, 0);
            });
            pbRenderer.MouseDown += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                if (!isChoosingPatternPT)
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        mainGame.gCgol.editCell(true, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        mainGame.gCgol.editCell(false, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
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
                    {
                        mainGame.gCgol.editCell(true, e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        mainGame.gCgol.editCell(false, e.X / mainGame.gCgol.CellWidth , e.Y / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
                    }
                else
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        mainGame.gCgol.addPatternToCellMap(parser.PatternMatrix, new Point(e.X / mainGame.gCgol.CellWidth, e.Y / mainGame.gCgol.CellHeight));
                        isChoosingPatternPT = false;
                    }
                    mousePoint = new Point((e.X - 20) + x, (e.Y - 30) + y);
                }
            });
            pbRenderer.MouseWheel += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                if (e.Delta > 0)
                {
                    if (s_width_height_cell++ < mainGame.gCgol.CellWidth * 5)
                    {
                        mainGame.gCgol.CellWidth = s_width_height_cell;
                        mainGame.gCgol.CellHeight = s_width_height_cell;
                    }
                }
                else if (e.Delta < 0)
                {
                    if (s_width_height_cell-- > 15)
                    {
                        mainGame.gCgol.CellWidth = s_width_height_cell;
                        mainGame.gCgol.CellHeight = s_width_height_cell;
                    }
                }
            });

            pbRenderer.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                pbRenderer.Focus();
            });

            pbRenderer.PreviewKeyDown += new PreviewKeyDownEventHandler((object sender, PreviewKeyDownEventArgs e) =>
            {
                //215 biiznillah

                if (e.KeyCode == Keys.W)
                    mainGame.gCgol.setCameraPosition(x, y+=5);

                if (e.KeyCode == Keys.A)
                    mainGame.gCgol.setCameraPosition(x+=5, y);

                if (e.KeyCode == Keys.S)
                    mainGame.gCgol.setCameraPosition(x, y-=5);

                if (e.KeyCode == Keys.D)
                    mainGame.gCgol.setCameraPosition(x-=5, y);
            });
            
        }
        private void pbRenderer_Paint(object sender, PaintEventArgs e)
        {
            mainGame.Render(e.Graphics);

            if(isChoosingPatternPT)
            {
                for (int i = 0; i < parser.PatternMatrix.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < parser.PatternMatrix.GetUpperBound(1); j++)
                    {
                        if (parser.PatternMatrix[i, j])
                            e.Graphics.FillRectangle(Brushes.Black, i * mainGame.gCgol.CellWidth + mousePoint.X, j * mainGame.gCgol.CellHeight + mousePoint.Y, mainGame.gCgol.CellWidth, mainGame.gCgol.CellHeight);
                        generation_lb.Text = mousePoint.ToString();
                    }
                }
            }
        }
        private void guiRenderer(object sender, PaintEventArgs e)
        {
            pbRenderer.Invalidate();
        }
        private void GUI_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            ControlTools.SetDoubleBuffered(pbRenderer);
            mainGame = new Core.Core(this, new Rectangle(0, 0, 1350, 800), 20);
            mainGame.Run(65, 50);
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
            run_bttn.Text = "Run...";
            interval_tb.Enabled = true;
            btn_eddit.Enabled = true;
            mainGame.gCgol.isEditing = true;

            PatternDownloader downloader = new PatternDownloader();

            downloader.Show();

            new Thread(new ThreadStart(() =>
            {
                while (this.Visible)
                {
                    if (downloader.PatternImage != null)
                    {
                        try
                        {
                            parser = new CGOFPatternsParser(new Bitmap(downloader.PatternImage));
     
                        parser.processParsing();
                        isChoosingPatternPT = true;
                        downloader.Close();
                        break;
                        }
                        catch { }
                    }
                }
            })).Start();
        }
        private void rst_button_Click(object sender, EventArgs e)
        {
            mainGame.gCgol.CreateMap(int.Parse(tb_width.Text), int.Parse(tb_height.Text));
        }

    }
}
