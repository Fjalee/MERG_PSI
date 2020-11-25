using System;
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
            await allScrapers.ScrapeAllWebsites(FileLog.Instance);

            TextBox1.AppendText("Done\n");
        }

        public void OnScrapingDomain(object source, ScrapingDomainEventArgs e)
        {
            TextBox1.AppendText("\n" + "Scraping domain...  " + e.Domain + "\n");
        }
    }
}

