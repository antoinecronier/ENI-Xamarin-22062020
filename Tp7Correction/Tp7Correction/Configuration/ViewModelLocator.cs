using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Tp7Correction.Pages;
using Tp7Correction.Services;
using Tp7Correction.ViewModel;

namespace Tp7Correction.Configurations
{
    public class ViewModelLocator
    {
        public enum Pages
        {
            MainPage,
            TweetsPage,
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = NavigationService.Instance;
                navigationService.Configure(Pages.TweetsPage.ToString(), typeof(TweetsPage));
                navigationService.Configure(Pages.MainPage.ToString(), typeof(MainPage));
                return navigationService;
            });

            SimpleIoc.Default.Register<ITwitterService>(() =>
            {
                return new TwitterService();
            });

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<TweetsPageViewModel>();
            SimpleIoc.Default.Register<HeaderViewModel>();
            SimpleIoc.Default.Register<SearchViewModel>();
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }
        public TweetsPageViewModel TweetsPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<TweetsPageViewModel>();
            }
        }

        public HeaderViewModel HeaderViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<HeaderViewModel>();
            }
        }

        public SearchViewModel SearchViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SearchViewModel>();
            }
        }
    }
}
