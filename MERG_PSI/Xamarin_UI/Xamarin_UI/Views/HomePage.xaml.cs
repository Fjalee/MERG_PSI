using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin_UI.Services;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly Lazy<List<RealEstate>> _listOfRealEstates;
        private List<RealEstate> _filteredList;

        private ObservableCollection<string> _municipalityList;
        private ObservableCollection<string> _microdistrictList;
        private ObservableCollection<string> _streetList;
        private readonly Lazy<HttpRequest> _httpRequest;

        public HomePage()
        {
            InitializeComponent();
            _httpRequest = new Lazy<HttpRequest>(() => new HttpRequest());

            List<RealEstate> getSampleData() => new Data(GetScrapedDataStream()).SampleData;
            _listOfRealEstates = new Lazy<List<RealEstate>>(getSampleData);
            myItem.ItemsSource = _listOfRealEstates.Value;
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
            var inspection = new Inspection();

            try
            {
                //_filteredList = await _httpRequest.Value.GetRealEstates(filtersValue);
                _filteredList = inspection.GetFilteredListOFRealEstate(_listOfRealEstates.Value, filtersValue);
                myItem.ItemsSource = _filteredList;
            }
            catch (Exception)
            {
                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenų, prašome kreiptis į administraciją", "OK");
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

                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenų, prašome kreiptis į administraciją", "OK");
            }
        }

        private FiltersValue GetFiltersValue()
        {
            var filtersValue = new FiltersValue(priceFrom: priceFrom.Text.ConvertToInt(), priceTo: priceTo.Text.ConvertToInt(),
              areaFrom: areaFrom.Text.ConvertToInt(), areaTo: areaTo.Text.ConvertToInt(),
              buildYearFrom: buildYearFrom.Text.ConvertToInt(), buildYearTo: buildYearTo.Text.ConvertToInt(),
              numberOfRoomsFrom: numberOfRoomsFrom.Text.ConvertToInt(), numberOfRoomsTo: numberOfRoomsTo.Text.ConvertToInt(),
              pricePerSqMFrom: pricePerSqMFrom.Text.ConvertToInt(), pricePerSqMTo: pricePerSqMTo.Text.ConvertToInt(),
              noBuildYearInfo: noInfoBuildYear.IsToggled, noNumberOfRoomsInfo: noInfoRoomNumber.IsToggled);

            filtersValue.Municipality = municipality.Text;
            filtersValue.Microdistrict = microdistrict.Text;
            filtersValue.Street = street.Text;

            return filtersValue;
        }

        private void Button_Clicked_Expand(object sender, EventArgs e)
        {
            if (filtersDisplay.IsVisible)
            {
                filtersDisplay.IsVisible = false;
                return;
            }
            filtersDisplay.IsVisible = true;
        }


        private async void MunicipalitySearchBar_OnTextChangedAsync(Object sender, TextChangedEventArgs e)
        {
            if (_municipalityList == null)
            {
                _municipalityList = await _httpRequest.Value.GetMunicipalities();
            }
            OnTextChanged(e.NewTextValue, municipalityListView, _municipalityList);
        }

        private async void MicrodistrictSearchBar_OnTextChangedAsync(Object sender, TextChangedEventArgs e)
        {
            if (_microdistrictList == null)
            {
                _microdistrictList = await _httpRequest.Value.GetMicrodistricts();
            }
            OnTextChanged(e.NewTextValue, microdistrictListView, _microdistrictList);
        }

        private async void StreetSearchBar_OnTextChangedAsync(Object sender, TextChangedEventArgs e)
        {
            if (_streetList == null)
            {
                _streetList = await _httpRequest.Value.GetStreets();
            }
            OnTextChanged(e.NewTextValue, streetListView, _streetList);
        }

        private void MunicipalityListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            OnItemTappedSearch(sender, e, municipalityListView, municipality);
        }

        private void MicrodistrictListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            OnItemTapped(sender, e, microdistrictListView, microdistrict);
        }

        private void StreetListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
                OnItemTapped(sender, e, streetListView, street);
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

        private void OnItemTappedSearch(Object sender, ItemTappedEventArgs e, ListView viewlist, SearchBar name)
        {
            var mun = e.Item as string;
            name.Text = mun;
            viewlist.IsVisible = false;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
