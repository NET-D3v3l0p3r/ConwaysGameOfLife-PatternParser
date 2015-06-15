using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConwaysGameOfLife_with_parser.GUI
{
    public partial class PatternDownloader : Form
    {
        public Stream PatternImage { get; private set; }

        public PatternDownloader()
        {
            InitializeComponent();
            webBrowser1.Navigated += new WebBrowserNavigatedEventHandler((object sender, WebBrowserNavigatedEventArgs e) =>
            {
                if (e.Url.ToString().Contains("www.conwaylife.com"))
                {
                    if (e.Url.AbsolutePath.Contains(".png") || e.Url.AbsolutePath.Contains(".gif") || e.Url.AbsolutePath.Contains(".jpeg"))
                    {
                        System.Net.WebRequest request = System.Net.WebRequest.Create(e.Url);
                        System.Net.WebResponse response = request.GetResponse();
                        PatternImage = response.GetResponseStream();
                    }
                }else
                {
                    webBrowser1.Navigate("http://www.conwaylife.com/wiki/Category:Patterns");
                    MessageBox.Show("Please select a pattern of this site!" + Environment.NewLine + "Other pattern are not supported yet (Version 0.2.1 will in sha ALLAH)");
                }
            });
        }

        private void PatternDownloader_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://www.conwaylife.com/wiki/Category:Patterns");
        }
    }
}
