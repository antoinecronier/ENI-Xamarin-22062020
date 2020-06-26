using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class TweetsPageViewModel : ViewModelBase
    {
        private INavigationService navigation;

        private Boolean searchVisibility;

        public Boolean SearchVisibility
        {
            get { return searchVisibility; }
            set { searchVisibility = value; }
        }


        public TweetsPageViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
            this.SearchVisibility = false;
            Messenger.Default.Register<GenericMessage<int>>(this, NotifyMe);
        }

        private void NotifyMe(GenericMessage<int> value)
        {
            switch (value.Content)
            {
                case 0:
                    this.SearchVisibility = false;
                    break;
                case 1:
                    this.SearchVisibility = true;
                    break;
                default:
                    break;
            }
        }
    }
}
