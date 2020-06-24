using System;
using System.Collections.Generic;
using System.Text;
using Tp4.Entities;

namespace Tp4.Services
{
    public interface ITwitterService
    {
        Boolean Authenticate(User user);
        List<Tweet> Tweets { get; }
    }
}
