using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private String accueil = "Test VM";
        private INavigationService navigation;

        public String Accueil
        {
            get { return accueil; }
            set { accueil = value; }
        }

        public MainPageViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }
    }
}
