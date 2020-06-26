using ENI_Xamarin_30032020.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ENI_Xamarin_30032020.Services
{
    public interface ITwitterService
    {
        string Authenticate(User user);
        List<Tweet> Tweets { get; }
    }
}
