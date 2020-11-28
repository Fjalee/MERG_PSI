using Autofac;
using System;
using System.Reflection;
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
            var container = BuildContainer();
            var scope = container.BeginLifetimeScope();

            await scope.Resolve<AllScrapers>().ScrapeAllWebsites();

            TextBox1.AppendText("Done\n");
        }

        public void OnScrapingDomain(object source, ScrapingDomainEventArgs e)
        {
            TextBox1.AppendText("\n" + "Scraping domain...  " + e.Domain + "\n");
        }

        private IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FormsLog>().As<ILog>().SingleInstance();
            builder.RegisterType<AllScrapers>().AsSelf().WithParameter(new NamedParameter("myUI", this));
            return builder.Build();
        }
    }
}

