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
using Tp7.WebServices;
using Tp7.WebServices.Entities;

namespace Tp7.ViewModel
{
    public class ExampleViewModel : ViewModelBase
    {
        private INavigationService navigation;
        private String textToPrint;

        public String TextToPrint
        {
            get { return textToPrint; }
            set
            {
                textToPrint = value;
                this.RaisePropertyChanged();
            }
        }
        public RelayCommand BtnNavigateExample2Command
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (this.navigation.CurrentPageKey == Configurations.ViewModelLocator.Pages.ExamplePage.ToString())
                    {
                        this.navigation.NavigateTo(Configurations.ViewModelLocator.Pages.ExamplePage2.ToString());
                    }
                });
            }
        }

        public RelayCommand BtnNavigateMainPageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    if (this.navigation.CurrentPageKey == Configurations.ViewModelLocator.Pages.ExamplePage.ToString())
                    {
                        this.navigation.NavigateTo(Configurations.ViewModelLocator.Pages.MainPage.ToString());
                    }
                });
            }
        }

        public ExampleViewModel(INavigationService navigation)
        {
            this.TextToPrint = "Bonjour";
            this.navigation = navigation;
            Messenger.Default.Register<GenericMessage<String>>(this, NotifyMe);

            Task.Factory.StartNew(() =>
            {
                for (int i = 0; i < 20; i++)
                {
                    Task.Delay(TimeSpan.FromSeconds(2)).Wait();
                    Messenger.Default.Send<GenericMessage<String>, ExampleViewModel>(new GenericMessage<String>(this.TextToPrint += " vous"));
                }
            });
        }
        private async void NotifyMe(GenericMessage<String> value)
        {
            TextToPrint = value.Content;

            var jsonPlaceholderApi = RestService.For<JsonPlaceholderApi>("https://jsonplaceholder.typicode.com");

            List<Album> albums = await jsonPlaceholderApi.GetAlbums();
            foreach (var item in albums)
            {
                Debug.WriteLine(item.Title);
            }

            Album oneAlbum = await jsonPlaceholderApi.GetAlbum(1);
            Debug.WriteLine(oneAlbum.Title);

            Post newPost = new Post() { Title = "test", Body = "my anwesome body", UserId = 1 };
            Post settedPost = await jsonPlaceholderApi.PostPost(newPost);

            Debug.WriteLine(settedPost.Title);
        }
    }
}
