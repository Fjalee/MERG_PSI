using MERG_BackEnd;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly Lazy<List<RealEstate>> _listOfRealEstates;
        private List<RealEstate> _filteredList;

        private ObservableCollection<string> _municipalityList;
        //private readonly Lazy<ObservableCollection<IList>> _microdistrictList;
        //private readonly Lazy<ObservableCollection<IList>> _streetList;
        private readonly Lazy<HttpClient> _httpClient;

        private const string _webApiLink = @"https://mergwebapi20201216191928.azurewebsites.net/";
        private const string _realEstateContrGetUri = @"api/RealEstate";
        private const string _municipalityUri = @"api/Municipality";

        public HomePage()
        {
            InitializeComponent();

            //_municipalityList = new Lazy<ObservableCollection<string>>(() => new MunicipalityList().GetList());
            //_microdistrictList = new Lazy<ObservableCollection<IList>>(() => new MicrodistrictList().GetList());
            //_streetList = new Lazy<ObservableCollection<IList>>(() => new StreetList().GetList());
            
            _httpClient = new Lazy<HttpClient>(() => new HttpClient());


            List<RealEstate> getSampleData() => new Data(GetScrapedDataStream()).SampleData;
            _listOfRealEstates = new Lazy<List<RealEstate>>(getSampleData);
        }

        private async void SetMunicipalitiesAsync()
        {

            var uri = new Uri($"{_webApiLink}{_municipalityUri}");
            try
            {
                var response = await _httpClient.Value.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (content != null)
                    {
                        var municipalities = JsonConvert.DeserializeObject<List<string>>(content);
                        _municipalityList = new ObservableCollection<string>(municipalities);
                    }
                }
            }
            catch (Exception)
            {
            }
        }


        private Stream GetScrapedDataStream()
        {
            var assembly = typeof(HomePage).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream("Xamarin_UI.Resources.scrapedData.txt");
        }

        private void MyItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myValue = e.CurrentSelection.FirstOrDefault() as RealEstate;
            Application.Current.MainPage.Navigation.PushAsync(new MapPage(myValue));
        }

        private async void Button_Clicked_SearchAsync(object sender, EventArgs e)
        {
            var filtersValue = GetFiltersValue();

            var uri = new Uri($"{_webApiLink}/{_realEstateContrGetUri}/{filtersValue}");

            try
            {
                var response = await _httpClient.Value.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    if (content != null)
                    {
                        _filteredList = JsonConvert.DeserializeObject<List<RealEstate>>(content);
                        myItem.ItemsSource = _filteredList;
                    }
                    else
                    {
                        await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
                    }
                }
                else
                {
                    await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
                }
            }
            catch (Exception)
            {
                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
            }
        }

        private async void Button_Clicked_GoToMapAsync(object sender, EventArgs e)
        {
            try
            {
                var list = _filteredList ?? _listOfRealEstates.Value;
                await Application.Current.MainPage.Navigation.PushAsync(new FullMapPage(list));
            }
            catch (Exception)
            {

                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
            }
        }

        private FiltersValue GetFiltersValue()
        {
            var filtersValue = new FiltersValue(priceFrom: priceFrom.Text.ConvertToInt(), priceTo: priceTo.Text.ConvertToInt(),
              areaFrom: areaFrom.Text.ConvertToInt(), areaTo: areaTo.Text.ConvertToInt(),
              buildYearFrom: buildYearFrom.Text.ConvertToInt(), buildYearTo: buildYearTo.Text.ConvertToInt(),
              numberOfRoomsFrom: numberOfRoomsFrom.Text.ConvertToInt(), numberOfRoomsTo: numberOfRoomsTo.Text.ConvertToInt(),
              pricePerSqMFrom: pricePerSqMFrom.Text.ConvertToInt(), pricePerSqMTo: pricePerSqMTo.Text.ConvertToInt(),
              noBuildYearInfo: noInfoBuildYear.IsChecked, noNumberOfRoomsInfo: noInfoRoomNumber.IsChecked);

              

            filtersValue.Municipality = municipality.Text ?? "noMunicipality";
            filtersValue.Microdistrict = microdistrict.Text ?? "noMicrodistrict";
            filtersValue.Street = street.Text ?? "noStreet";

            return filtersValue;
        }

        private void Button_Clicked_Expand(object sender, EventArgs e)
        {
            if (filtersDisplay.IsVisible)
            {
                filtersDisplay.IsVisible = false;
                buttonExpand.Text = "Išskleisti";
                return;
            }
            filtersDisplay.IsVisible = true;
            buttonExpand.Text = "Suskleisti";
        }


        private void MunicipalitySearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            if (_municipalityList == null)
            {
                SetMunicipalitiesAsync();
            }
            OnTextChanged(e.NewTextValue, municipalityListView, _municipalityList);
        }

        private void MicrodistrictSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            //OnTextChanged(e.NewTextValue, microdistrictListView, _microdistrictList.Value);
        }

        private void StreetSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            //OnTextChanged(e.NewTextValue, streetListView, _streetList.Value);
        }

        private void MunicipalityListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            OnItemTapped(sender, e, municipalityListView, municipality);
        }

        private void MicrodistrictListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
           // OnItemTapped(sender, e, microdistrictListView, microdistrict);
        }

        private void StreetListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
                //OnItemTapped(sender, e, streetListView, street);
        }

        private void OnTextChanged(string text, ListView viewlist, ObservableCollection<string> dataList)
        {
            viewlist.IsVisible = true;
            viewlist.BeginRefresh();

            try
            {
                var data = dataList.Where(i => i.ToLower().Contains(text.ToLower()));
                if (string.IsNullOrWhiteSpace(text))
                {
                    viewlist.IsVisible = false;
                }
                else
                {
                    viewlist.ItemsSource = data;
                }
            }
            catch (Exception)
            {
                viewlist.IsVisible = false;
            }
            viewlist.EndRefresh();
        }

        private void OnItemTapped(Object sender, ItemTappedEventArgs e, ListView viewlist, Entry name)
        {
            var mun = e.Item as string;
            name.Text = mun;
            viewlist.IsVisible = false;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
