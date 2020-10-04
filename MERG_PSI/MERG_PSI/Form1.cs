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
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Windows;

namespace MERG_PSI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private string Title { get; set; }
        private string Url { get; set; }
        private string siteUrl = "https://www.kampas.lt";
        public string[] QueryTerms { get; } = { "Vilnius" };

        private void button1_Click(object sender, EventArgs e)
        {
            ScrapeWebsite();
        }

        internal async void ScrapeWebsite()
        {
            CancellationTokenSource cancellationToken = new CancellationTokenSource();
            HttpClient httpClient = new HttpClient();

            HttpResponseMessage request = await httpClient.GetAsync(siteUrl);
            cancellationToken.Token.ThrowIfCancellationRequested();

            Stream response = await request.Content.ReadAsStreamAsync();
            cancellationToken.Token.ThrowIfCancellationRequested();

            HtmlParser parser = new HtmlParser();
            IHtmlDocument document = parser.ParseDocument(response);

            //Add connection between initial scrape, and parsing of results
            GetScrapeResults(document);
        }

        private void GetScrapeResults(IHtmlDocument document)
        {
            IEnumerable<IElement> articleLink = null;

            foreach (var term in QueryTerms)
            {
                articleLink = document.All.Where(x =>
                    x.ClassName == "card-link text-content" &&
                    (x.ParentElement.InnerHtml.Contains(term) || x.ParentElement.InnerHtml.Contains(term.ToLower()))).Skip(1);

                //Overwriting articleLink above means we have to print it's result for all QueryTerms
                //Appending to a pre-declared IEnumerable (like a List), could mean taking this out of the main loop.
                if (articleLink.Any())
                {
                    PrintResults(articleLink);
                }
            }
        }

        public void PrintResults(IEnumerable<IElement> articleLink)
        {
            //Every element needs to be cleaned and displayed
            foreach (var element in articleLink)
            {
                richTextBox2.AppendText(element.InnerHtml);
                richTextBox2.AppendText("\n\n*\n*\n*\n");
                CleanUpResults(element);

                richTextBox1.AppendText($"{Title} - {Url}{Environment.NewLine}");
            }
        }

        private void CleanUpResults(IElement result)
        {
            string htmlResult = result.InnerHtml.ReplaceFirst("        <span class=\"field-content\"><div><a href=\"", @"https://www.oceannetworks.ca");
            htmlResult = htmlResult.ReplaceFirst("\">", "*");
            htmlResult = htmlResult.ReplaceFirst("</a></div>\n<div class=\"article-title-top\">", "-");
            htmlResult = htmlResult.ReplaceFirst("</div>\n<hr></span>  ", "");

            richTextBox3.AppendText(htmlResult);
            //Seperate the results into our class fields for use in PrintResults()
            SplitResults(htmlResult);
        }

        private void SplitResults(string htmlResult)
        {
            string[] splitResults = htmlResult.Split('*');
            Url = splitResults[0];
            Title = splitResults[1];
        }
    }
}

