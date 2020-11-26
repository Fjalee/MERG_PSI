using MERG_BackEnd;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        const string NumberRegex = @"^[a-zA-Z]+$";
        private readonly List<RealEstate> _listOfRealEstates = new List<RealEstate>();
        private List<RealEstate> _filteredList { get; set; }

        public HomePage()
        {
            InitializeComponent();

            var assembly = typeof(HomePage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Xamarin_UI.Resources.scrapedData.txt");
            _listOfRealEstates = new Data(stream).SampleData;
            _filteredList = _listOfRealEstates;
            Populate(_listOfRealEstates);

        }

        public void Populate (List<RealEstate> listOfRealEstates)
        {
            myItem.ItemsSource = listOfRealEstates;
        }

        private void MyItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myValue = e.CurrentSelection.FirstOrDefault() as RealEstate;
            App.Current.MainPage.Navigation.PushAsync(new MapPage(myValue));
        }

        private void Municipality_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validate(sender, e);

        }

        private void Microdistrict_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validate(sender, e);
        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            Validate(sender, e);
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var inspection = new Inspection();
            var filtersValues = GetFiltersValue();
            _filteredList = inspection.GetFilteredListOFRealEstate(_listOfRealEstates, filtersValues);
            myItem.ItemsSource = _filteredList;
        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new FullMapPage(_filteredList));
        }
        private void Validate(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                var IsValid = (Regex.IsMatch(e.NewTextValue, NumberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                ((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
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
    }
    
}