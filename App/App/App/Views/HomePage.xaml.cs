using App.Models;
using App.Services;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        RealEstate Mock => DependencyService.Get<RealEstate>();
        const string NumberRegex = @"^[a-zA-Z]+$";
        public System.Collections.Generic.List<RealEstateModel> FilteredList = new System.Collections.Generic.List<RealEstateModel>();
        public HomePage()
        {
            InitializeComponent();
            GetData();
        }
        public async void GetData()
        {
           
            var newItem = await Mock.GetRealEstates();
            FilteredList = newItem;
            myItem.ItemsSource = newItem;
        }

        private void MyItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myValue = e.CurrentSelection.FirstOrDefault() as RealEstateModel;
            App.Current.MainPage.Navigation.PushAsync(new MapPage(myValue));
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var inspection = new Inspection();
            var filtersValues = GetFiltersValue();
            var items = GetReal().Result;
            items = inspection.GetFilteredListOFRealEstate(items, filtersValues);
            FilteredList = items;
            myItem.ItemsSource = items;
           
        }
        public async System.Threading.Tasks.Task<System.Collections.Generic.List<RealEstateModel>> GetReal()
        {
            return await Mock.GetRealEstates();
        }

        private void Municipality_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            
                if (!string.IsNullOrWhiteSpace(e.NewTextValue))
                {
                    var IsValid = (Regex.IsMatch(e.NewTextValue, NumberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                    ((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
                }
            
        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                var IsValid = (Regex.IsMatch(e.NewTextValue, NumberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                ((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }
        }
        private FiltersValue GetFiltersValue()
        {
            return new FiltersValue(
              municipality: municipality.Text, street: street.Text, microdistrict: microdistrict.Text,
              priceFrom: ConvertToInt(priceFrom.Text), priceTo: ConvertToInt(priceTo.Text),
              areaFrom: ConvertToInt(areaFrom.Text), areaTo: ConvertToInt(areaTo.Text),
              buildYearFrom: ConvertToInt(buildYearFrom.Text), buildYearTo: ConvertToInt(buildYearTo.Text),
              numberOfRoomsFrom: ConvertToInt(numberOfRoomsFrom.Text), numberOfRoomsTo: ConvertToInt(numberOfRoomsTo.Text),
              pricePerSqMFrom: ConvertToInt(pricePerSqMFrom.Text), pricePerSqMTo: ConvertToInt(pricePerSqMTo.Text),
              noBuildYearInfo: noInfoBuildYear.IsChecked, noNumberOfRoomsInfo: noInfoRoomNumber.IsChecked);
        }
        private Tuple<bool, int> ConvertToInt(string text)
        {

            var succes = int.TryParse(text, out var number);
            if (succes)
            {
                return new Tuple<bool, int>(succes, number);
            }
            return new Tuple<bool, int>(succes, 0);

        }

        private void Microdistrict_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.NewTextValue))
            {
                var IsValid = (Regex.IsMatch(e.NewTextValue, NumberRegex, RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250)));
                ((Entry)sender).Text = IsValid ? e.NewTextValue : e.NewTextValue.Remove(e.NewTextValue.Length - 1);
            }
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new FullMapPage(FilteredList));
        }
    }
}