using System;
using Tp7Correction.Configurations;
using Tp7Correction.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tp7Correction
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
