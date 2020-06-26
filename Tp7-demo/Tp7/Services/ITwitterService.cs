using System;
using System.Collections.Generic;
using System.Text;
using Tp7.Entities;

namespace Tp7.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> Tweets { get; }
    }
}
