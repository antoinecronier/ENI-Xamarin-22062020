using System;
using Tp7.Configurations;
using Tp7.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tp7
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var firstPage = new NavigationPage(new ExamplePage());
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
