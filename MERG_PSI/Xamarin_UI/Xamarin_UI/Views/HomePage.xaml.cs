using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Collections.ObjectModel;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly List<RealEstate> _listOfRealEstates = new List<RealEstate>();
        private List<RealEstate> _filteredList;

        private ObservableCollection<MunicipalityList> _municipalityList = new ObservableCollection<MunicipalityList>();

        public HomePage()
        {
            InitializeComponent();

            var stream = GetScrapedDataStream();
            _listOfRealEstates = new Data(stream).SampleData;
            _filteredList = _listOfRealEstates;
            Populate(_listOfRealEstates);
            var munic = new MunicipalityList();
            _municipalityList = munic.ListOfStore().Result;
        }

        private Stream GetScrapedDataStream()
        {
            var assembly = typeof(HomePage).GetTypeInfo().Assembly;
            return assembly.GetManifestResourceStream("Xamarin_UI.Resources.scrapedData.txt");
        }

        private void Populate (List<RealEstate> listOfRealEstates)
        {
            myItem.ItemsSource = listOfRealEstates;
        }

        private void MyItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myValue = e.CurrentSelection.FirstOrDefault() as RealEstate;
            Application.Current.MainPage.Navigation.PushAsync(new MapPage(myValue));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var inspection = new Inspection();
            var filtersValues = GetFiltersValue();
            _filteredList = inspection.GetFilteredListOFRealEstate(_listOfRealEstates, filtersValues);
            myItem.ItemsSource = _filteredList;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new FullMapPage(_filteredList));
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

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            if(filtersDisplay.IsVisible)
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
            OnTextChanged(e.NewTextValue, municipalityListView, _municipalityList);
        }
        private void MicrodistrictSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, microdistrictListView, _municipalityList);
        }
        private void StreetSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, streetListView, _municipalityList);
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

        private void OnTextChanged(string text, ListView viewlist, ObservableCollection<MunicipalityList> dataList)
        {
            viewlist.IsVisible = true;
            viewlist.BeginRefresh();

            try
            {
                var data = dataList.Where(i => i.Municipality.ToLower().Contains(text.ToLower()));
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
            var mun = e.Item as MunicipalityList;
            name.Text = mun.Municipality;
            viewlist.IsVisible = false;
            ((ListView)sender).SelectedItem = null;
        }
    }
    
}
