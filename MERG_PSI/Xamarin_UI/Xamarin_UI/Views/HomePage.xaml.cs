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

        ObservableCollection<string> municipalityList = new ObservableCollection<string>();

        public HomePage()
        {
            InitializeComponent();

            var stream = GetScrapedDataStream();
            _listOfRealEstates = new Data(stream).SampleData;
            _filteredList = _listOfRealEstates;
            Populate(_listOfRealEstates);

            ListOfStore();
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

        public async void ListOfStore() //List of Countries  
        {
            try
            {
                municipalityList.Add("Akmenės r. sav.");
                municipalityList.Add("Alytaus m. sav.");
                municipalityList.Add("Alytaus r. sav.");
                municipalityList.Add("Anykščių r. sav.");
                municipalityList.Add("Birštono sav.");
                municipalityList.Add("Biržų r. sav.");
                municipalityList.Add("Druskininkų sav.");
                municipalityList.Add("Elektrėnų sav.");
                municipalityList.Add("Ignalinos r. sav.");
                municipalityList.Add("Jonavos r. sav.");
                municipalityList.Add("Joniškio r. sav.");
                municipalityList.Add("Jurbarko r. sav.");
                municipalityList.Add("Kaišiadorių r. sav.");
                municipalityList.Add("Kalvarijos sav.");
                municipalityList.Add("Kauno m. sav.");
                municipalityList.Add("Kauno r. sav.");
                municipalityList.Add("Kazlų Rūdos sav.");
                municipalityList.Add("Kėdainių r. sav.");
                municipalityList.Add("Kelmės r. sav.");
                municipalityList.Add("Klaipėdos m. sav.");
                municipalityList.Add("Klaipėdos r. sav.");
                municipalityList.Add("Kretingos r. sav.");
                municipalityList.Add("Kupiškio r. sav.");
                municipalityList.Add("Lazdijų r. sav.");
                municipalityList.Add("Marijampolės sav.");
                municipalityList.Add("Mažeikių r. sav.");
                municipalityList.Add("Molėtų r. sav.");
                municipalityList.Add("Neringos sav.");
                municipalityList.Add("Pagėgių sav.");
                municipalityList.Add("Pakruojo r. sav.");
                municipalityList.Add("Palangos m. sav.");
                municipalityList.Add("Panevėžio m. sav.");
                municipalityList.Add("Panevėžio r. sav.");
                municipalityList.Add("Pasvalio r. sav.");
                municipalityList.Add("Plungės r. sav.");
                municipalityList.Add("Prienų r. sav.");
                municipalityList.Add("Radviliškio r. sav.");
                municipalityList.Add("Raseinių r. sav.");
                municipalityList.Add("Rietavo sav.");
                municipalityList.Add("Rokiškio r. sav.");
                municipalityList.Add("Skuodo r. sav.");
                municipalityList.Add("Šakių r. sav.");
                municipalityList.Add("Šalčininkų r. sav.");
                municipalityList.Add("Šiaulių miesto sav.");
                municipalityList.Add("Šiaulių r. sav.");
                municipalityList.Add("Šilalės r. sav.");
                municipalityList.Add("Šilutės r. sav.");
                municipalityList.Add("Širvintų r. sav.");
                municipalityList.Add("Švenčionių r. sav.");
                municipalityList.Add("Tauragės r. sav.");
                municipalityList.Add("Telšių r. sav.");
                municipalityList.Add("Trakų r. sav.");
                municipalityList.Add("Ukmergės r. sav.");
                municipalityList.Add("Utenos r. sav.");
                municipalityList.Add("Varėnos r. sav.");
                municipalityList.Add("Vilkaviškio r. sav.");
                municipalityList.Add("Vilniaus m. sav.");
                municipalityList.Add("Vilniaus r. sav.");
                municipalityList.Add("Visagino sav.");
                municipalityList.Add("Zarasų r. sav.");
            }
            catch (Exception ex)
            {
                await DisplayAlert("", "" + ex, "Ok");
            }
        }
        private void MunicipalitySearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, municipalityListView, municipalityList);
        }
        private void MicrodistrictSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, microdistrictListView, municipalityList);
        }
        private void StreetSearchBar_OnTextChanged(Object sender, TextChangedEventArgs e)
        {
            OnTextChanged(e.NewTextValue, streetListView, municipalityList);
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

        private void OnTextChanged(string text, ListView viewlist, ObservableCollection<string> dataList)
        {
            viewlist.IsVisible = true;
            viewlist.BeginRefresh();

            try
            {
                var data = dataList.Where(i => i.ToLower().Contains(text.ToLower()));

                if (string.IsNullOrWhiteSpace(text) || data.Max().Length == 0)
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
            name.Text = e.Item as string;
            viewlist.IsVisible = false;
            ((ListView)sender).SelectedItem = null;
        }
    }
    
}
