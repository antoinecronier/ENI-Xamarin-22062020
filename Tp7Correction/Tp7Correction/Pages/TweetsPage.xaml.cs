﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tp7Correction.Services;
using GalaSoft.MvvmLight.Messaging;
using Tp7Correction.ViewModel;

namespace Tp7Correction.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetsPage : ContentPage
    {
        public TweetsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Messenger.Default.Send<MessageBase, TweetsPageViewModel>(new MessageBase());
            base.OnAppearing();
        }
    }
}