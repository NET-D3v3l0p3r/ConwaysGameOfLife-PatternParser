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

        private PatternDownloader downloader;
        private Thread t;
    
        public GUI()
        {
            InitializeComponent();
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
                        if ((e.X - x) / mainGame.gCgol.CellWidth > 0 && (e.X - x) / mainGame.gCgol.CellWidth < mainGame.gCgol.MapWidth
                            && (e.Y - y) / mainGame.gCgol.CellHeight > 0 && (e.Y - y) / mainGame.gCgol.CellHeight < mainGame.gCgol.MapHeight)
                            mainGame.gCgol.editCell(true, (e.X - x) / mainGame.gCgol.CellWidth, (e.Y - y) / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if ((e.X - x) / mainGame.gCgol.CellWidth > 0 && (e.X - x) / mainGame.gCgol.CellWidth < mainGame.gCgol.MapWidth
                   && (e.Y - y) / mainGame.gCgol.CellHeight > 0 && (e.Y - y) / mainGame.gCgol.CellHeight < mainGame.gCgol.MapHeight)
                            mainGame.gCgol.editCell(false, (e.X - x) / mainGame.gCgol.CellWidth, (e.Y - y) / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
                }
                else
                {
                    if (e.Button == System.Windows.Forms.MouseButtons.Left)
                    {
                        mainGame.gCgol.addPatternToCellMap(parser.PatternMatrix, new Point((mousePoint.X - x) / mainGame.gCgol.CellWidth, (mousePoint.Y - y) / mainGame.gCgol.CellHeight));
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
                        if ((e.X - x) / mainGame.gCgol.CellWidth > 0 && (e.X - x) / mainGame.gCgol.CellWidth < mainGame.gCgol.MapWidth
                            && (e.Y - y) / mainGame.gCgol.CellHeight > 0 && (e.Y - y) / mainGame.gCgol.CellHeight < mainGame.gCgol.MapHeight)
                            mainGame.gCgol.editCell(true, (e.X - x) / mainGame.gCgol.CellWidth, (e.Y - y) / mainGame.gCgol.CellHeight);
                        run_bttn.Text = "Run...";
                        interval_tb.Enabled = true;
                        btn_eddit.Enabled = true;
                    }
                    else if (e.Button == System.Windows.Forms.MouseButtons.Right)
                    {
                        if ((e.X - x) / mainGame.gCgol.CellWidth > 0 && (e.X - x) / mainGame.gCgol.CellWidth < mainGame.gCgol.MapWidth
                   && (e.Y - y) / mainGame.gCgol.CellHeight > 0 && (e.Y - y) / mainGame.gCgol.CellHeight < mainGame.gCgol.MapHeight)
                            mainGame.gCgol.editCell(false, (e.X - x) / mainGame.gCgol.CellWidth, (e.Y - y) / mainGame.gCgol.CellHeight);
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


                    if (e.X > x && e.Y > y && e.X < ((mainGame.gCgol.MapWidth * mainGame.gCgol.CellWidth) + x) - parser.PatternMatrix.GetUpperBound(0) * mainGame.gCgol.CellWidth && e.Y < ((mainGame.gCgol.MapHeight * mainGame.gCgol.CellHeight) + y) - (parser.PatternMatrix.GetUpperBound(1) * mainGame.gCgol.CellHeight) - 1 * mainGame.gCgol.CellHeight)
                        mousePoint = new Point(e.X, e.Y);
                }
            });
            pbRenderer.MouseWheel += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                if (e.Delta > 0)
                {
                    mainGame.gCgol.CellWidth = s_width_height_cell;
                    mainGame.gCgol.CellHeight = s_width_height_cell;
                    s_width_height_cell++;
                }
                else if (e.Delta < 0)
                {
                    mainGame.gCgol.CellWidth = s_width_height_cell;
                    mainGame.gCgol.CellHeight = s_width_height_cell;
                    if (s_width_height_cell > 2)
                        s_width_height_cell--;
                }

                x += -(e.X / mainGame.gCgol.CellWidth);
                y += -(e.Y / mainGame.gCgol.CellHeight);
            });

            pbRenderer.MouseEnter += new EventHandler((object sender, EventArgs e) =>
            {
                pbRenderer.Focus();
            });

            pbRenderer.PreviewKeyDown += new PreviewKeyDownEventHandler((object sender, PreviewKeyDownEventArgs e) =>
            {
                //215 biiznillah

                if (e.KeyCode == Keys.W)
                    y += 5;

                if (e.KeyCode == Keys.A)
                    x += 5;

                if (e.KeyCode == Keys.S)
                    y -= 5;

                if (e.KeyCode == Keys.D)
                    x -= 5;
            });
            
        }
        private void pbRenderer_Paint(object sender, PaintEventArgs e)
        {
            /*~~~Clear screen and flush position biiznillah~~~*/
            e.Graphics.Clear(Color.Black);
            mainGame.gCgol.setCameraPosition(x, y);

            mainGame.Render(e.Graphics);
            if (isChoosingPatternPT)
            {
                for (int i = 0; i < parser.PatternMatrix.GetUpperBound(0); i++)
                {
                    for (int j = 0; j < parser.PatternMatrix.GetUpperBound(1); j++)
                    {
                        if (parser.PatternMatrix[i, j])
                            e.Graphics.FillRectangle(Brushes.Black, i * mainGame.gCgol.CellWidth + mousePoint.X, j * mainGame.gCgol.CellHeight + mousePoint.Y, mainGame.gCgol.CellWidth, mainGame.gCgol.CellHeight);
                        e.Graphics.DrawRectangle(Pens.Gray, i * mainGame.gCgol.CellWidth + mousePoint.X, j * mainGame.gCgol.CellHeight + mousePoint.Y, mainGame.gCgol.CellWidth, mainGame.gCgol.CellHeight);
                    }
                }
            }
        }
        private void GUI_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            ControlTools.SetDoubleBuffered(pbRenderer);
            mainGame = new Core.Core(this, new Rectangle(0, 0, 1350, 800), 20);
            mainGame.Run(65, 50);
            t = new Thread(new ThreadStart(() =>
            {
                while (downloader.Visible)
                {
                    if (downloader.PatternImage != null)
                    {
                        parser = new CGOFPatternsParser(new Bitmap(downloader.PatternImage));
                        downloader.Close();
                        try
                        {
                            parser.processParsing();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        isChoosingPatternPT = true;
                        t.Abort();
                    }
                }
                t.Abort();

            }));
            CheckForIllegalCrossThreadCalls = false;

        }
        private void run_bttn_Click(object sender, EventArgs e)
        {
            if (run_bttn.Text == "Run...")
            {
                mainGame.gCgol.setCameraPosition(x, y);
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
            if (!t.IsAlive)
            {
                downloader = new PatternDownloader();
                downloader.Show();
                t = new Thread(new ThreadStart(() =>
                {
                    while (downloader.Visible)
                    {
                        if (downloader.PatternImage != null)
                        {
                            parser = new CGOFPatternsParser(new Bitmap(downloader.PatternImage));
                            downloader.Close();
                            parser.processParsing();
                            isChoosingPatternPT = true;
                            this.Show();
                            t.Abort();
                        }
                    }
                    t.Abort();

                }));
                t.Start();
            }
            else
            {
                downloader.Focus();
            }

        }
        private void rst_button_Click(object sender, EventArgs e)
        {
            run_bttn.Text = "Run...";
            interval_tb.Enabled = true;
            btn_eddit.Enabled = true;
            mainGame.gCgol.isEditing = true;
            mainGame.gCgol.CreateMap(int.Parse(tb_width.Text), int.Parse(tb_height.Text));
            mainGame.gCgol.setCameraPosition(x, y);
        }
    }
}
