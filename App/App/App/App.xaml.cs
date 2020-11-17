﻿using App.Services;
using Xamarin.Forms;

namespace App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            DependencyService.Register<RealEstate>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}