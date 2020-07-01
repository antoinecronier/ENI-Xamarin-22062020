using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp7Correction.Entities;
using Tp7Correction.Models;
using Tp7Correction.Services;
using Tp7Correction.Utils;

namespace Tp7Correction.ViewModel
{
    public class TweetsPageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private ITwitterService twitterService;
        private bool searchVisibility;

        public ObservableCollection<Tweet> Tweets { get; }

        public bool SearchVisibility
        {
            get { return this.searchVisibility; }
            set 
            { 
                this.searchVisibility = value;
                this.RaisePropertyChanged();
                Messenger.Default.Send<GenericMessage<Boolean>, SearchViewModel>(new GenericMessage<bool>(this.searchVisibility));
            }
        }

        public TweetsPageViewModel(INavigationService navigation, ITwitterService twitterService)
        {
            this.Tweets = new ObservableCollection<Tweet>();
            this.SearchVisibility = false;

            this.navigation = navigation;
            this.twitterService = twitterService;

            Messenger.Default.Register<MessageBase>(this, PageLoaded);
            Messenger.Default.Register<GenericMessage<int>>(this, Notifyed);
            Messenger.Default.Register<GenericMessage<TweetSearch>>(this, SearchNeeded);
        }

        private void SearchNeeded(GenericMessage<TweetSearch> msg)
        {
            this.Tweets.Clear();

            bool usernameSearch = msg.Content.UsernameChecked;
            bool dateSearch = msg.Content.SearchDateChecked;
            String username = msg.Content.Username;
            DateTime dateTime = msg.Content.SearchDate;

            if (usernameSearch && dateSearch)
            {
                foreach (var tweet in this.twitterService.Tweets.Where(x => x.User.Login.Equals(username) && DateTime.Compare(x.CreatedAt, dateTime) < 1))
                {
                    this.Tweets.Add(tweet);
                }
            }
            else if (usernameSearch)
            {
                foreach (var tweet in this.twitterService.Tweets.Where(x => x.User.Login.Equals(username)))
                {
                    this.Tweets.Add(tweet);
                }
            }
            else if (dateSearch)
            {
                foreach (var tweet in this.twitterService.Tweets.Where(x => DateTime.Compare(x.CreatedAt, dateTime) < 1))
                {
                    this.Tweets.Add(tweet);
                }
            }
            else
            {
                foreach (var tweet in this.twitterService.Tweets)
                {
                    this.Tweets.Add(tweet);
                }
            }
        }

        private void Notifyed(GenericMessage<int> msg)
        {
            switch (msg.Content)
            {
                case 1:
                    this.SearchCliked();
                    break;
                default:
                    break;
            }
        }

        private void SearchCliked()
        {
            this.SearchVisibility = !this.SearchVisibility;
        }

        private void PageLoaded(MessageBase obj)
        {
            foreach (var tweet in this.twitterService.Tweets)
            {
                this.Tweets.Add(tweet);
            }
        }
    }
}
