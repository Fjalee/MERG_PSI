using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        private string _websiteLink = "https://www.kampas.lt";
        private List<RealEstate> _scrapedRealEstate = new List<RealEstate>();
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
                richTextBox2.AppendText("\n" + "Scraping domain...  " + linkWithPage + "\n");

                var adCardLinkScraper = new AdCardLinkScraper(_websiteLink, "k-ad-card-wide");
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();

                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        //richTextBox2.AppendText("Scraping subdomain...  " + link + "\n");
                        var ias = new InsideAdScraper();
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        _scrapedRealEstate.Add(new RealEstate(link, ias.Area, ias.PricePerSqM, ias.NumberOfRooms,
                            ias.Floor, ias.MapLink, ias.Municipality, ias.Street, ias.BuildYear));
                    }

                    websitePage++;
                }
                else { _reachedPageNoAds = true; }
            }

            TempOutput();
            OutputToJson output = new OutputToJson(_scrapedRealEstate);
            output.WriteToFile();
        }

        private void TempOutput()
        {
            foreach (var element in _scrapedRealEstate)
            {
                richTextBox2.AppendText("Serializing " + element.Link + "\n");
                richTextBox1.AppendText(element.ToString());
            }
        }
    }
}

