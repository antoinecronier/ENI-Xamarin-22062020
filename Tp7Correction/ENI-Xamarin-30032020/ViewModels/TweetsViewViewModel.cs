using ENI_Xamarin_30032020.Data;
using ENI_Xamarin_30032020.Entities;
using ENI_Xamarin_30032020.Models;
using ENI_Xamarin_30032020.Services;
using ENI_Xamarin_30032020.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class TweetsViewViewModel : ViewModelBase
    {
        private ITwitterService twitterService;

        private ObservableCollection<Tweet> tweets;

        public ObservableCollection<Tweet> Tweets
        {
            get { return tweets; }
            set { tweets = value; }
        }

        public TweetsViewViewModel(ITwitterService twitterService)
        {
            Messenger.Default.Register<GenericMessage<int>>(this, PageLoaded);
            Messenger.Default.Register<GenericMessage<List<SearchListItem>>>(this, RequestedTweets);
            this.twitterService = twitterService;
            this.tweets = new ObservableCollection<Tweet>();
        }

        private void RequestedTweets(GenericMessage<List<SearchListItem>> items)
        {
            this.Tweets.Clear();
            List<Tweet> tweets = new List<Tweet>();

            using (var db = new AppDbContext())
            {
                foreach (var item in items.Content)
                {
                    if (item.Choice == SearchChoices.Date.ToString())
                    {
                        tweets.AddRange(db.Tweets.Include(x => x.User).Where(x => x.CreationDate == DateTime.Parse(item.Value)).OrderByDescending(x => x.CreationDate).ToList());
                    }
                    else if (item.Choice == SearchChoices.Identifiant.ToString())
                    {
                        tweets.AddRange(db.Tweets.Include(x => x.User).Where(x => x.Identifier == item.Value).OrderByDescending(x => x.CreationDate).ToList());
                    }
                    else if (item.Choice == SearchChoices.NomUtilisateur.ToString())
                    {
                        tweets.AddRange(db.Tweets.Include(x => x.User).Where(x => x.User.Login == item.Value).OrderByDescending(x => x.CreationDate).ToList());
                    }
                }

                if (items.Content.Count == 0)
                {
                    tweets = this.twitterService.Tweets;
                }
            }

            foreach (var item in tweets)
            {
                this.Tweets.Add(item);
            }
        }

        public void PageLoaded(GenericMessage<int> msg)
        {
            if (msg.Content == 1)
            {
                this.Tweets.Clear();
                var tweets = this.twitterService.Tweets.OrderByDescending(x => x.CreationDate);
                foreach (var item in tweets)
                {
                    this.Tweets.Add(item);
                }
            }
        }
    }
}
