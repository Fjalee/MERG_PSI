﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        private string websiteLink = "https://www.kampas.lt";
        private Boolean reachedPageNoAds = false;

        public Form1()
        {
            InitializeComponent();
        }
        public async void button1_Click(object sender, EventArgs e)
        {
            var websitePage = 1;
            //while (!reachedPageNoAds)
            while (websitePage < 4)
            {
                var tempLinkWithPage = websiteLink + "/butai?page=" + websitePage.ToString();
                var ws = new AdCardLinkScraper(websiteLink, tempLinkWithPage, "k-ad-card-wide");
                await ws.GetIHtmlDoc();
                ws.ScrapeUrls();

                if (ws.Links.Count == 0)
                {
                    reachedPageNoAds = true;
                }

                foreach (var link in ws.Links)
                {
                    var ias = new InsideAdScraper(link);
                    await ias.GetIHtmlDoc();
                    ias.ScrapeBuildingInfo("k-classified-icon-item");
                    ias.ScrapePrice("price");
                    ias.ScrapeMapLink("li-map-preview");


                    richTextBox1.AppendText(link);
                    richTextBox1.AppendText("\n");
                    richTextBox1.AppendText(ias.GetBuildingInfo());
                    richTextBox1.AppendText("\n\n*\n*\n*\n");
                }

                websitePage++;
            }
        }
    }
}

