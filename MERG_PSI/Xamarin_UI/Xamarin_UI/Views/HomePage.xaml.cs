using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        private readonly List<RealEstate> _listOfRealEstates = new List<RealEstate>();
        private Lazy<List<RealEstate>> _filteredList;

        public HomePage()
        {
            InitializeComponent();

            var stream = GetScrapedDataStream();
            _listOfRealEstates = new Data(stream).SampleData;
            _filteredList = new Lazy<List<RealEstate>>(() => _listOfRealEstates);
            Populate(_listOfRealEstates);
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

        private void Municipality_TextChanged(object sender, TextChangedEventArgs e)
        {

            ((Entry)sender).Text = e.NewTextValue.Validate();
        }

        private void Microdistrict_TextChanged(object sender, TextChangedEventArgs e)
        {
 
            ((Entry)sender).Text = e.NewTextValue.Validate();
        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            ((Entry)sender).Text = e.NewTextValue.Validate();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var inspection = new Inspection();
            var filtersValues = GetFiltersValue();
            var newfilteredList = inspection.GetFilteredListOFRealEstate(_listOfRealEstates, filtersValues);
            _filteredList = new Lazy<List<RealEstate>>(() => newfilteredList);
            myItem.ItemsSource = _filteredList.Value;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushAsync(new FullMapPage(_filteredList.Value));
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
    }
    
}
