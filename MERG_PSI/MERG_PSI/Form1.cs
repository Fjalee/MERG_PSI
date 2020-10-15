using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using AngleSharp.Text;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace MERG_PSI{
    public partial class Form1 : Form{
        private List<string> kampasAdsLinks = new List<string>();

        public Form1(){
            InitializeComponent();
        }
        public async void button1_Click(object sender, EventArgs e){
            AdCardLinkScraper ws = new AdCardLinkScraper("https://www.kampas.lt", "https://www.kampas.lt", "k-ad-card-wide");
            await ws.GetIHtmlDoc();
            ws.ScrapeUrls();
            kampasAdsLinks = ws.GetUrls();

            foreach (var link in kampasAdsLinks){
                InsideAdScraper ias = new InsideAdScraper(link, "k-classified-icon-item");
                await ias.GetIHtmlDoc();
                ias.ScrapeBuildingInfo();
                ias.ScrapeMapCoord();
                
                richTextBox1.AppendText(link);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText(ias.GetBuildingInfo());
                richTextBox1.AppendText("\n\n*\n*\n*\n");
            }
        }
    }
}

