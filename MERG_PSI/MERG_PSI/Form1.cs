using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        private List<string> kampasAdsLinks = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }
        public async void button1_Click(object sender, EventArgs e)
        {
            var ws = new AdCardLinkScraper("https://www.kampas.lt", "https://www.kampas.lt", "k-ad-card-wide");
            await ws.GetIHtmlDoc();
            ws.ScrapeUrls();
            kampasAdsLinks = ws.GetUrls();

            foreach (var link in kampasAdsLinks)
            {
                var ias = new InsideAdScraper(link);
                await ias.GetIHtmlDoc();
                ias.ScrapeBuildingInfo("k-classified-icon-item");
                ias.ScrapeMapCoord("li-map-preview");

                richTextBox1.AppendText(link);
                richTextBox1.AppendText("\n");
                richTextBox1.AppendText(ias.GetBuildingInfo());
                richTextBox1.AppendText("\n\n*\n*\n*\n");
            }
        }
    }
}

