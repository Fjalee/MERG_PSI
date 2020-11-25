using MERG_BackEnd;
using System.Collections.Generic;
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

        }
    }
    
}