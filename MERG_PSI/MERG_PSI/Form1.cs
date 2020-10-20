using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        private string _websiteLink = "https://www.kampas.lt";
        private List<RealEstate> _scrapedData = new List<RealEstate>();
        private Boolean _reachedPageNoAds = false;

        public Form1()
        {
            InitializeComponent();
        }
        public async void button1_Click(object sender, EventArgs e)
        {
            var websitePage = 1;
            //while (!_reachedPageNoAds)
            while (websitePage < 4)
            {
                var linkWithPage = _websiteLink + "/butai?page=" + websitePage.ToString();

                var adCardLinkScraper = new AdCardLinkScraper(_websiteLink, linkWithPage, "k-ad-card-wide");
                await adCardLinkScraper.GetIHtmlDoc();
                adCardLinkScraper.ScrapeUrls();

                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var insideAdScraper = new InsideAdScraper(link);
                        await insideAdScraper.GetIHtmlDoc();
                        insideAdScraper.ScrapeBuildingInfo();
                        insideAdScraper.ScrapePrice();
                        insideAdScraper.ScrapeMapLink();

                        /*_scrapedData.Add(new RealEstate(
                            link, area, pricePerSqM, numberOfRooms, floor, mapLink,
                            municipality, street, buildYear);*/

                        //fix delete with TempOutput()
                        var buildingInfo = insideAdScraper.GetBuildingInfo();
                        TempOutput(link, buildingInfo);
                    }

                    websitePage++;
                }
                else { _reachedPageNoAds = true; }
            }
        }

       private void TempOutput(string link, string buildingInfo)
       {
            richTextBox1.AppendText(link);
            richTextBox1.AppendText("\n");
            richTextBox1.AppendText(buildingInfo);
            richTextBox1.AppendText("\n\n*\n*\n*\n");
       }
    }
}

