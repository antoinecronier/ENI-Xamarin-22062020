using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tp8.ViewModel
{
    public class HeaderViewModel
    {
        private INavigationService navigation;

        public RelayCommand SearchClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (this.navigation.CurrentPageKey == Configurations.ViewModelLocator.Pages.TweetsPage.ToString())
                    {
                        Messenger.Default.Send<GenericMessage<int>, TweetsPageViewModel>(new GenericMessage<int>(1));
                    }
                });
            }
        }

        public HeaderViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }
    }
}
