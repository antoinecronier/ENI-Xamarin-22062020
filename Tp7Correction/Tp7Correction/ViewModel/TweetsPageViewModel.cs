using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Tp7Correction.Entities;
using Tp7Correction.Utils;

namespace Tp7Correction.ViewModel
{
    public class TweetsPageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private User user;

        public User User
        {
            get { return user; }
            set
            {
                user = value;
                //this.RaisePropertyChanged();
            }
        }

        public TweetsPageViewModel(INavigationService navigation)
        {
            this.user = new User();
            this.navigation = navigation;
            Messenger.Default.Register<GenericMessage<User>>(this, NotifyMe);

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Task.Delay(TimeSpan.FromSeconds(2)).Wait();
                    User changedUser = new User();
                    changedUser.Login = RandomUtil.GetString();
                    changedUser.Password = RandomUtil.GetString();

                    Messenger.Default.Send<GenericMessage<User>, TweetsPageViewModel>(new GenericMessage<User>(changedUser));
                }
            });
        }
        private void NotifyMe(GenericMessage<User> value)
        {
            this.user.Login = value.Content.Login;
            this.user.Password = value.Content.Password;
        }
    }
}
