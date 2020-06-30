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
            ExamplePage,
            ExamplePage2,
            MainPage,
        }

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<INavigationService>(() =>
            {
                var navigationService = NavigationService.Instance;
                navigationService.Configure(Pages.ExamplePage.ToString(), typeof(ExamplePage));
                navigationService.Configure(Pages.ExamplePage2.ToString(), typeof(ExamplePage2));
                navigationService.Configure(Pages.MainPage.ToString(), typeof(MainPage));
                return navigationService;
            });

            SimpleIoc.Default.Register<ITwitterService>(() =>
            {
                return new TwitterService();
            });

            SimpleIoc.Default.Register<ExampleViewModel>();
            SimpleIoc.Default.Register<ExampleViewModel2>();
        }

        public ExampleViewModel ExampleViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ExampleViewModel>();
            }
        }
        public ExampleViewModel2 ExampleViewModel2
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ExampleViewModel2>();
            }
        }
    }
}
