using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Tp7Correction.Models;

namespace Tp7Correction.ViewModel
{
    public class SearchViewModel : ViewModelBase
    {
        private INavigationService navigation;

        private Boolean visibility;

        public Boolean Visibility
        {
            get { return visibility; }
            set 
            { 
                visibility = value;
                this.RaisePropertyChanged();
            }
        }

        public TweetSearch Search { get; }

        public RelayCommand SearchClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (this.navigation.CurrentPageKey == Configurations.ViewModelLocator.Pages.TweetsPage.ToString())
                    {
                        Messenger.Default.Send<GenericMessage<TweetSearch>, TweetsPageViewModel>(new GenericMessage<TweetSearch>(this.Search));
                    }
                });
            }
        }

        public SearchViewModel(INavigationService navigation)
        {
            this.Search = new TweetSearch();
            this.Search.SearchDate = DateTime.Now;

            this.navigation = navigation;

            Messenger.Default.Register<GenericMessage<Boolean>>(this, this.VisibilityChanged);
        }

        private void VisibilityChanged(GenericMessage<bool> msg)
        {
            this.Visibility = msg.Content;
        }
    }
}
