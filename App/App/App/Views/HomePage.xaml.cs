using App.Models;
using App.Services;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        RealEstate Mock => DependencyService.Get<RealEstate>();
        public HomePage()
        {
            InitializeComponent();
            GetData();
        }
        public async void GetData()
        {
           
            var newItem = await Mock.GetRealEstates();

            myItem.ItemsSource = newItem;
        }

        private void MyItem_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var myValue = e.CurrentSelection.FirstOrDefault() as RealEstateModel;
            App.Current.MainPage.Navigation.PushAsync(new MapPage(myValue));
        }
    }
}