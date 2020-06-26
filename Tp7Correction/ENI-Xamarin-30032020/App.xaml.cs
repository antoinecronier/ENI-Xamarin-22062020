using ENI_Xamarin_30032020.Configurations;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ENI_Xamarin_30032020
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var firstPage = new NavigationPage(new MainPage());
            NavigationService.Instance.Initialize(firstPage);

            MainPage = firstPage;
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
