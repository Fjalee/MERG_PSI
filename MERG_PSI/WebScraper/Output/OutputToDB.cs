using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebScraper
{
    class OutputToDB : IOutput
    {
        public async Task DoOutput(string jsonToOutput)
        {
            var _webApiLink = ConfigurationManager.AppSettings.Get("WEB_API_LINK");
            var _realEstateContrUri = ConfigurationManager.AppSettings.Get("REALESTATE_CONTR_URI");

            var uri = new Uri($"{_webApiLink}/{_realEstateContrUri}");

            var content = new StringContent(jsonToOutput, Encoding.UTF8, "application/json");

            var _httpClient = new HttpClient();
            await _httpClient.PutAsync(uri, content);
        }
    }
}
