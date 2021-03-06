﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebScraper
{
    public abstract class SiteScraper
    {
        public List<RealEstate> ScrapedRealEstate { get; } = new List<RealEstate>();
        protected string WebsiteLink { get; }
        protected string Subdirectory { get; }
        protected string PageString { get; }
        protected string Symbol { get; }
        protected bool ReachedPageNoAds { get; set; } = false;
        protected ILog Logger { get; }

        public SiteScraper(string websiteLink, string subdirectory, string pageString, string symbol, ILog logger)
        {
            WebsiteLink = websiteLink;
            Subdirectory = subdirectory;
            PageString = pageString;
            Symbol = symbol;
            Logger = logger;
        }

        public event EventHandler<ScrapingDomainEventArgs> ScrapingDomain;

        public async Task ScrapeWebsite(Form1 myUI)
        {
            ScrapingDomain += myUI.OnScrapingDomain;
            var websitePage = 1;
            while (!ReachedPageNoAds)
            //while (websitePage < 5) //Temporary, for testing purpose
            {
                var linkWithPage = WebsiteLink + Subdirectory + Symbol + PageString + websitePage.ToString();

                ScrapingDomain?.Invoke(this, new ScrapingDomainEventArgs(linkWithPage));

                var adCardLinkScraper = InstanciateAdCardLinkScraperObject();
                adCardLinkScraper.Document = await adCardLinkScraper.GetIHtmlDoc(linkWithPage);
                adCardLinkScraper.Scrape();
                if (adCardLinkScraper.Links.Any())
                {
                    foreach (var link in adCardLinkScraper.Links)
                    {
                        var ias = InstanciateInsideAdScraperObject(link);
                        ias.Document = await ias.GetIHtmlDoc(link);
                        ias.Scrape();

                        var adress = new RevGeocoding(ias.Latitude, ias.Longitude);
                        var municipality = adress.Municipality;
                        var microdistrict = adress.Microdistrict;
                        var street = adress.Street;

                        if (IsAdHasAllNeededData(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.Latitude, ias.Longitude, municipality, microdistrict, street))
                        {
                            ScrapedRealEstate.Add(new RealEstate(logger: Logger, link: link, area: ias.Area, pricePerSqM: ias.PricePerSqM, numberOfRooms: ias.NumberOfRooms,
                            floor: ias.Floor, scrapedPrice: ias.Price, mapLink: ias.MapLink, buildYear: ias.BuildYear, image: ias.Image, latitude: ias.Latitude, longitude: ias.Longitude, municipality: municipality, microdistrict: microdistrict, street: street));
                        }

                        else
                        {
                            Logger.AdInvalid(link, ias.MapLink, ias.NumberOfRooms, ias.Price, ias.PricePerSqM, ias.Area, ias.Latitude, ias.Longitude, municipality, microdistrict, street);
                        }
                    }
                    websitePage++;
                }
                else { ReachedPageNoAds = true; }
            }
        }

        protected abstract AdCardLinkScraper InstanciateAdCardLinkScraperObject();

        protected abstract InsideAdScraper InstanciateInsideAdScraperObject(string link);

        private bool IsAdHasAllNeededData(string link, string mapLink, int numberOfRooms, double scrapedPrice, double pricePerSqM, double area, double latitude, double longitude, string municipality, string microdistrict, string street)
        {
            var calculatedPrice = pricePerSqM * area;
            if (
                    latitude == 0 ||
                    longitude == 0 ||
                    link == "" ||
                    mapLink == "" ||
                    numberOfRooms == 0 ||
                    (calculatedPrice == 0 && scrapedPrice == 0) ||
                    !IsValuesClose(calculatedPrice, scrapedPrice, 1000) ||
                    municipality == "" ||
                    street == "" ||
                    microdistrict == ""
                )
            {
                return false;
            }
            else { return true; }
        }

        private bool IsValuesClose(double value1, double value2, int roundErr)
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