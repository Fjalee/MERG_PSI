using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;

namespace Xamarin_UI.Services
{
    public class HttpRequest
    {
        private readonly HttpClient _httpClient;
        private const string _webApiLink = @"https://mergwebapi20201216191928.azurewebsites.net/";
        private const string _municipalityUri = @"api/Municipality";
        private const string _microdistrictUri = @"api/Microdistrict";


        public HttpRequest()
        {
            _httpClient = new HttpClient();
        }
        public async Task<ObservableCollection<string>> GetMunicipalities()
        {
            var municipalities = new List<string>();
            var uri = new Uri($"{_webApiLink}{_municipalityUri}");
            try
            {
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (content != null)
                    {
                        municipalities = JsonConvert.DeserializeObject<List<string>>(content);
                        
                    }
                }
            }
            catch (Exception)
            {
            }
            var municipalityList = new ObservableCollection<string>(municipalities);
            return municipalityList;
        }

        public async Task<ObservableCollection<string>> GetMicrodistricts()
        {
            var microdistricts = new List<string>();
            var uri = new Uri($"{_webApiLink}{_microdistrictUri}");
            try
            {
                var response = await _httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (content != null)
                    {
                        microdistricts = JsonConvert.DeserializeObject<List<string>>(content);
                    }
                }
            }
            catch (Exception)
            {
            }
            var microdistrictList = new ObservableCollection<string>(microdistricts);
            return microdistrictList;
        }
    }

}
