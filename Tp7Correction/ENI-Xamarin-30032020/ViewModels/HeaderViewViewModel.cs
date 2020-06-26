using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using static ENI_Xamarin_30032020.Configurations.ViewModelLocator;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class HeaderViewViewModel : ViewModelBase
    {
        private INavigationService navigation;

        public RelayCommand CreateClicked
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (this.navigation.CurrentPageKey == Pages.TweetsPage.ToString())
                    {
                        this.navigation.NavigateTo(Pages.TweetCreatePage.ToString());
                    }
                    else
                    {
                        Messenger.Default.Send<GenericMessage<String>, ConnectionViewViewModel>(new GenericMessage<String>("Vous devez vous authentifier avant de créer un tweet."));
                    }
                });
            }
        }

        public RelayCommand SearchClicked
        {
            get
            {
                return new RelayCommand(() =>
                {
                    Messenger.Default.Send<GenericMessage<int>, TweetsPageViewModel>(new GenericMessage<int>(1));
                    Messenger.Default.Send<GenericMessage<int>, SearchViewViewModel>(new GenericMessage<int>(1));
                });
            }
        }
        
        public HeaderViewViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }
    }
}
