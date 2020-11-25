using MERG_BackEnd;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
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


        }

    }
    
}