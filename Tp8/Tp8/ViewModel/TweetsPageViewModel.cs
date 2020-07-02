using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp8.Database;
using Tp8.Entities;
using Tp8.Models;
using Tp8.Services;
using Tp8.Utils;

namespace Tp8.ViewModel
{
    public class TweetsPageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private ITwitterService twitterService;
        private bool searchVisibility;
        private bool createVisibility;
        private String tweetText;

        public ObservableCollection<Tweet> Tweets { get; }

        public bool SearchVisibility
        {
            get { return this.searchVisibility; }
            set 
            { 
                this.searchVisibility = value;
                this.RaisePropertyChanged();
            }
        }

        public bool CreateVisibility
        {
            get { return createVisibility; }
            set 
            { 
                createVisibility = value;
                this.RaisePropertyChanged();
            }
        }

        public String TweetText
        {
            get { return tweetText; }
            set 
            { 
                tweetText = value;
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
                        this.Tweets.Clear();

                        bool usernameSearch = this.Search.UsernameChecked;
                        bool dateSearch = this.Search.SearchDateChecked;
                        String username = this.Search.Username;
                        DateTime dateTime = this.Search.SearchDate;
                        List<Tweet> tweets = new List<Tweet>();

                        if (usernameSearch && dateSearch)
                        {
                            tweets = this.twitterService.Tweets.Where(x => x.User.Login.Equals(username) && DateTime.Compare(x.CreatedAt, dateTime) < 1).ToList();
                        }
                        else if (usernameSearch)
                        {
                            tweets = this.twitterService.Tweets.Where(x => x.User.Login.Equals(username)).ToList();
                        }
                        else if (dateSearch)
                        {
                            tweets = this.twitterService.Tweets.Where(x => DateTime.Compare(x.CreatedAt, dateTime) < 1).ToList();
                        }
                        else
                        {
                            tweets = this.twitterService.Tweets;
                        }

                        foreach (var tweet in tweets.OrderByDescending(x => x.CreatedAt))
                        {
                            this.Tweets.Add(tweet);
                        }
                    }
                });
            }
        }

        public RelayCommand TweetCreateClick
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (!String.IsNullOrWhiteSpace(this.TweetText))
                    {
                        User currentUser = this.twitterService.ConnectedUser;
                        Tweet tweet = new Tweet() { User = currentUser, CreatedAt = DateTime.Now, Data = this.TweetText };

                        using (var db = new AppDbContext())
                        {
                            db.Users.Find(currentUser.Id);
                            db.Tweets.Add(tweet);
                            db.SaveChanges();
                        }

                        this.Tweets.Add(tweet);
                        this.Tweets.Move(this.Tweets.Count - 1, 0);
                        this.CreateCliked();
                    }
                });
            }
        }

        public TweetsPageViewModel(INavigationService navigation, ITwitterService twitterService)
        {
            this.Tweets = new ObservableCollection<Tweet>();
            this.SearchVisibility = false;
            this.Search = new TweetSearch();
            this.Search.SearchDate = DateTime.Now;

            this.navigation = navigation;
            this.twitterService = twitterService;

            Messenger.Default.Register<MessageBase>(this, PageLoaded);
            Messenger.Default.Register<GenericMessage<int>>(this, Notifyed);
        }

        private void Notifyed(GenericMessage<int> msg)
        {
            switch (msg.Content)
            {
                case 1:
                    this.SearchCliked();
                    break;
                case 2:
                    this.CreateCliked();
                    break;
                default:
                    break;
            }
        }

        private void CreateCliked()
        {
            this.TweetText = "";
            this.CreateVisibility = !this.CreateVisibility;
        }

        private void SearchCliked()
        {
            this.SearchVisibility = !this.SearchVisibility;
        }

        private void PageLoaded(MessageBase obj)
        {
            foreach (var tweet in this.twitterService.Tweets.OrderByDescending(x => x.CreatedAt))
            {
                this.Tweets.Add(tweet);
            }
        }
    }
}
