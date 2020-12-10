using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly Lazy<List<RealEstate>> _listOfRealEstates;
        private List<RealEstate> _filteredList;

        private readonly Lazy<ObservableCollection<IList>> _municipalityList;
        private readonly Lazy<ObservableCollection<IList>> _microdistrictList;
        private readonly Lazy<ObservableCollection<IList>> _streetList;

        public HomePage()
        {
            InitializeComponent();

            _municipalityList = new Lazy<ObservableCollection<IList>>(() => new MunicipalityList().GetList());
            _microdistrictList = new Lazy<ObservableCollection<IList>>(() => new MicrodistrictList().GetList());
            _streetList = new Lazy<ObservableCollection<IList>>(() => new StreetList().GetList());

            //fix
            //List<RealEstate> getSampleData() => ReqToAPIMethod(GetScrapedDataStream()).SampleData;
            List<RealEstate> getSampleData() => new Data(GetScrapedDataStream()).SampleData;
            _listOfRealEstates = new Lazy<List<RealEstate>>(getSampleData);
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
            var inspection = new Inspection();
            var filtersValues = GetFiltersValue();
            try
            {
                _filteredList = inspection.GetFilteredListOFRealEstate(_listOfRealEstates.Value, filtersValues);
            }
            catch (Exception)
            {
                await DisplayAlert("Dėmesio", "Nepavyko pasiekti duomenis, prašome kreiptis į administraciją", "OK");
            }
            myItem.ItemsSource = _filteredList;
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
            return new FiltersValue(municipality: municipality.Text, microdistrict: microdistrict.Text, street: street.Text,
               priceFrom: priceFrom.Text.ConvertToInt(), priceTo: priceTo.Text.ConvertToInt(),
              areaFrom: areaFrom.Text.ConvertToInt(), areaTo: areaTo.Text.ConvertToInt(),
              buildYearFrom: buildYearFrom.Text.ConvertToInt(), buildYearTo: buildYearTo.Text.ConvertToInt(),
              numberOfRoomsFrom: numberOfRoomsFrom.Text.ConvertToInt(), numberOfRoomsTo: numberOfRoomsTo.Text.ConvertToInt(),
              pricePerSqMFrom: pricePerSqMFrom.Text.ConvertToInt(), pricePerSqMTo: pricePerSqMTo.Text.ConvertToInt(),
              noBuildYearInfo: noInfoBuildYear.IsChecked, noNumberOfRoomsInfo: noInfoRoomNumber.IsChecked);
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
            OnTextChanged(e.NewTextValue, municipalityListView, _municipalityList.Value);
        }

        private void MicrodistrictSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, microdistrictListView, _microdistrictList.Value);
        }

        private void StreetSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, streetListView, _streetList.Value);
        }

        private void MunicipalityListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            OnItemTapped(sender, e, municipalityListView, municipality);
        }

        private void MicrodistrictListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            OnItemTapped(sender, e, microdistrictListView, microdistrict);
        }

        private void StreetListView_OnItemTapped(Object sender, ItemTappedEventArgs e)
        {
            OnItemTapped(sender, e, streetListView, street);
        }

        private void OnTextChanged(string text, ListView viewlist, ObservableCollection<IList> dataList)
        {
            viewlist.IsVisible = true;
            viewlist.BeginRefresh();

            try
            {
                var data = dataList.Where(i => i.Address.ToLower().Contains(text.ToLower()));
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
            var mun = e.Item as IList;
            name.Text = mun.Address;
            viewlist.IsVisible = false;
            ((ListView)sender).SelectedItem = null;
        }
    }
}
