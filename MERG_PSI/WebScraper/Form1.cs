using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebScraper
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async void ButtonScrape_Click(object sender, EventArgs e)
        {
            var allScrapers = new AllScrapers(this);
            await allScrapers.ScrapeAllWebsites();

            TextBox1.AppendText("Done\n");
        }

        public void OnScrapingDomain(object source, ScrapingDomainEventArgs e)
        {
            TextBox1.AppendText("\n" + "Scraping domain...  " + e.Domain + "\n");
        }
    }
}

