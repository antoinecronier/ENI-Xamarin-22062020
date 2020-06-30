using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Refit;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Tp7Correction.Entities;
using Tp7Correction.Models;
using Tp7Correction.Services;
using Xamarin.Essentials;

namespace Tp7Correction.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private ITwitterService twitterService;

        public User User { get; }

        public ErrorForm Error { get; }

        public RelayCommand TweetsPageNavigate
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (this.controlsAreOk())
                    {
                        if (this.navigation.CurrentPageKey == Configurations.ViewModelLocator.Pages.MainPage.ToString())
                        {
                            this.navigation.NavigateTo(Configurations.ViewModelLocator.Pages.TweetsPage.ToString());
                        }
                    }
                    
                });
            }
        }

        public MainPageViewModel(INavigationService navigation, ITwitterService twitterService)
        {
            this.User = new User();
            this.Error = new ErrorForm();
            this.navigation = navigation;
            this.twitterService = twitterService;
            Messenger.Default.Register<MessageBase>(this, PageLoaded);
        }

        private void PageLoaded(MessageBase msg)
        {
            this.User.Login = "";
            this.User.Password = "";
        }

        private bool controlsAreOk()
        {
            Boolean result = true;

            Debug.WriteLine("btn clicked");

            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                if (this.IsValid())
                {
                    if (twitterService.Authenticate(this.User))
                    {
                        this.Error.Hide();
                    }
                    else
                    {
                        result = false;
                        this.Error.Data = "Utilisateur non trouvé";
                        this.Error.Display();
                    }
                }
                else
                {
                    result = false;
                    this.Error.Display();
                }
            }
            else
            {
                result = false;
                this.Error.Data = "Aucune connexion internet";
                this.Error.Display();
            }

            return result;
        }

        public Boolean IsValid()
        {
            Boolean result = true;

            User user = new User();
            user.Login = this.User.Login;
            user.Password = this.User.Password;

            bool haveError = false;
            StringBuilder stringBuilder = new StringBuilder();

            if (String.IsNullOrEmpty(user.Login) || user.Login.Length < 3)
            {
                haveError = true;
                stringBuilder.Append("L'identifiant ne peut pas être null et doit posséder au moins 3 caractères.");
            }

            if (String.IsNullOrEmpty(user.Password) || user.Password.Length < 6)
            {
                if (haveError)
                {
                    stringBuilder.Append("\n");
                }
                haveError = true;
                stringBuilder.Append("Le mot de passe ne peut pas être null et doit posséder au moins 6 caractères.");
            }

            if (haveError)
            {
                this.Error.Data = stringBuilder.ToString();
            }

            result = !haveError;

            return result;
        }
    }
}
