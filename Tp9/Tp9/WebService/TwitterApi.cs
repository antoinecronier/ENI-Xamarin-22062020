using Refit;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tp9.Entities;

namespace Tp9.WebService
{
    public interface TwitterApi
    {
        [Get("/api/users/authenticate")]
        Task<User> Authenticate([Query] String login, [Query] String password);

        [Get("/api/tweets")]
        Task<List<Tweet>> GetTweets();

        [Get("/api/tweets/filtered")]
        Task<List<Tweet>> GetTweetsFiltered([Query] string username, [Query] DateTime? dateTime);

        [Post("/api/tweets")]
        Task<Tweet> PostTweet(Tweet tweet);
    }
}
