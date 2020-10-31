using System;

namespace WebScraper
{
    public class ScrapingDomainEventArgs : EventArgs
    {
        public string Domain { get; set; }

        public ScrapingDomainEventArgs(string domain)
        {
            Domain = domain;
        }
    }
}
