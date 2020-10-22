using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            while (websitePage < 5)
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
                        var ias = new InsideAdScraper(link);
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        if (IsAdHasAllNeededData(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.MapCoords))
                        {
                            _scrapedRealEstate.Add(new RealEstate(link, ias.Area, ias.PricePerSqM, ias.NumberOfRooms,
                            ias.Floor, ias.Price, ias.MapLink, "", "", ias.BuildYear, ias.MapCoords)); //fix Municipality, Street instead of "", ""
                        }
                        else
                        {
                            MyLog.AdInvalid(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, "", ""); //fix Municipality, Street instead of "", ""
                        }
                    }
                    websitePage++;
                }
                else { _reachedPageNoAds = true; }
            }


            //TempOutput();
            richTextBox2.AppendText("Serializing...\n");
            OutputToJson output = new OutputToJson(_scrapedRealEstate);
            richTextBox2.AppendText("Writing to File (serialized)...\n");
            output.WriteToFile();

            richTextBox2.AppendText("Writing to File (log)...\n");
            MyLog.WriteToFile();
            richTextBox2.AppendText("Done\n");
        }

        private void TempOutput()
        {
            foreach (var element in _scrapedRealEstate)
            {
                richTextBox1.AppendText(element.ToString());
            }
        }

        private bool IsAdHasAllNeededData(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, string mapCoords)
        {
           var calculatedPrice = pricePerSqM * area;
            if (mapCoords == "" ||
                link == "" ||
                mapLink == "" ||
                numberOfRooms == 0 ||
                (calculatedPrice == 0 && scrapedPrice == 0) ||
                !IsValuesClose(calculatedPrice, scrapedPrice, 1000)
                /*Municipality == /*fix to be implemented*/
                /*Street == /*fix to be implemented*/)
            {
                return false;
            }
            else { return true; }
        }

        public bool IsValuesClose(double value1, double value2, int roundErr)
        {
            var diff = value1 - value2;
            if ((diff < roundErr && diff >= 0) || (diff <= 0 && diff > -roundErr))
            {
                return true;
            }
            else { return false; }
        }
    }
}

