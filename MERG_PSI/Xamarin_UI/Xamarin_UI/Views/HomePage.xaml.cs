using MERG_BackEnd;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_UI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            var assembly = typeof(HomePage).GetTypeInfo().Assembly;
            var stream = assembly.GetManifestResourceStream("Xamarin_UI.Resources.scrapedData.txt");
            var listOfRealEstates = new Data(stream).SampleData;
            Populate(listOfRealEstates);

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

        }

        private void Microdistrict_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Street_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {

        }

        private void Button_Clicked_1(object sender, System.EventArgs e)
        {

        }
    }
    
}