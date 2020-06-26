using ENI_Xamarin_30032020.Entities;
using ENI_Xamarin_30032020.Models;
using ENI_Xamarin_30032020.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Text.Json.Serialization;
using Xamarin.Essentials;
using Xamarin.Forms;
using static ENI_Xamarin_30032020.Configurations.ViewModelLocator;

namespace ENI_Xamarin_30032020.ViewModels
{
    public class ConnectionViewViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        private INavigationService navigation;
        private ITwitterService twitterService;
        private Boolean savingValues = false;

        public User User { get; } = new User();
        public ErrorSwitch ErrorSwitch { get; } = new ErrorSwitch() { ErrorColor = "Red" };

        public Boolean SavingValues
        {
            get { return savingValues; }
            set 
            { 
                savingValues = value;
                OnPropertyChanged("SavingValues");
            }
        }

        public RelayCommand ConnectionClicked
        {
            get
            {
                return new RelayCommand(() =>
                {
                    String errors = this.twitterService.Authenticate(User);
                    ManageErrors(errors);
                });
            }
        }

        public ConnectionViewViewModel(INavigationService navigation, ITwitterService twitterService)
        {
            this.navigation = navigation;
            this.twitterService = twitterService;
            Messenger.Default.Register<GenericMessage<String>>(this,ExternalErrors);
            ManageAppPropertiesLoad();
        }

        private void ExternalErrors(GenericMessage<string> error)
        {
            ManageErrors(error.Content);
        }

        private void ManageErrors(string errors)
        {
            if (String.IsNullOrEmpty(errors))
            {
                ManageAppPropertiesSave();

                this.ErrorSwitch.ErrorText = "";
                this.ErrorSwitch.IsErrorVisible = false;

                this.navigation.NavigateTo(Pages.TweetsPage.ToString());
            }
            else
            {
                this.ErrorSwitch.ErrorText = errors;
                this.ErrorSwitch.IsErrorVisible = true;
            }
        }

        private async void ManageAppPropertiesLoad()
        {
            Boolean haveSaved;
            if (Boolean.TryParse(await SecureStorage.GetAsync("have_saved_auth"), out haveSaved))
            {
                if (haveSaved == true)
                {
                    var user = JsonConvert.DeserializeObject<User>(await SecureStorage.GetAsync("saved_user"));
                    this.User.Login = user.Login;
                    this.User.Password = user.Password;
                    this.SavingValues = true;
                }
            }
        }

        private async void ManageAppPropertiesSave()
        {
            if (SavingValues)
            {
                await SecureStorage.SetAsync("have_saved_auth", Boolean.TrueString);
                await SecureStorage.SetAsync("saved_user", JsonConvert.SerializeObject(User));
            }
            else
            {
                await SecureStorage.SetAsync("have_saved_auth", Boolean.FalseString);
                SecureStorage.Remove("saved_user");
            }
        }
    }
}
