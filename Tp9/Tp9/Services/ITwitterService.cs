using System;
using System.Collections.Generic;
using System.Text;
using Tp9.Entities;

namespace Tp9.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> Tweets { get; }
        User ConnectedUser { get; set; }
    }
}
