using System;
using System.Threading;
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

            var thread = new Thread(allScrapers.ScrapeAllWebsites);
            thread.Start();

            TextBox1.AppendText("Done\n");
        }

        public void OnScrapingDomain(object source, ScrapingDomainEventArgs e)
        {
            TextBox1.BeginInvoke
            (
                new Action<string>((domain) => TextBox1.AppendText("\n" + "Scraping domain...  " + domain + "\n"))
                , e.Domain
            );
        }
    }
}

