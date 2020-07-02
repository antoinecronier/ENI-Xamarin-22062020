using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tp9.Pages;
using Tp9.Configurations;

namespace Tp9
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
