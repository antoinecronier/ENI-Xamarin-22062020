using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Tp6.Services;

namespace Tp6
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TweetsPage : ContentPage
    {
        public TweetsPage()
        {
            InitializeComponent();
            this.listView.ItemsSource = new TwitterService().Tweets;
        }
    }
}