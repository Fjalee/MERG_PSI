using App.Models;
using App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        RealEstate mock => DependencyService.Get<RealEstate>();
        public HomePage()
        {
            InitializeComponent();
            GetData();
        }
        public async void GetData()
        {
            var newItem = new List<RealEstateModel>();
            newItem = await mock.GetRealEstates();

            myItem.ItemsSource = newItem;
        }
    }
}