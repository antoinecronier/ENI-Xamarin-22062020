using System;
using Tp8.Configurations;
using Tp8.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tp8
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
