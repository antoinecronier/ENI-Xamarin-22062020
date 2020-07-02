using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tp9.Entities;
using Tp9.WebService;

namespace Tp9.Services
{
    public class TwitterService : ITwitterService
    {
        private User user;
        private readonly TwitterApi twitterApi;

        public User ConnectedUser { get => this.user; set => this.user = value; }

        public TwitterService()
        {
            this.user = new User();
            this.twitterApi = RestService.For<TwitterApi>("http://localhost:24618");
        }
        public List<Tweet> GetTweets()
        {
            List<Tweet> result = new List<Tweet>();

            Task< List < Tweet >> task = this.twitterApi.GetTweets();
            task.Wait(TimeSpan.FromSeconds(5));
            result = task.Result;

            return result;
        }

        public List<Tweet> GetTweets(String username, DateTime? dateTime)
        {
            List<Tweet> result = new List<Tweet>();

            Task<List<Tweet>> task = this.twitterApi.GetTweetsFiltered(username, dateTime);
            task.Wait(TimeSpan.FromSeconds(5));
            result = task.Result;

            return result;
        }

        public Tweet SendTweet(Tweet tweet)
        {
            Tweet result = new Tweet();

            Task<Tweet> task = this.twitterApi.PostTweet(tweet);
            task.Wait(TimeSpan.FromSeconds(2));
            result = task.Result;

            return result;
        }

        public Boolean Authenticate(User user)
        {
            Boolean result = false;

            Task<User> task = this.twitterApi.Authenticate(user.Login, user.Password);
            task.Wait(TimeSpan.FromSeconds(2));
            user = task.Result;

            if (user != null)
            {
                result = true;
            }

            return result;
        }
    }
}
