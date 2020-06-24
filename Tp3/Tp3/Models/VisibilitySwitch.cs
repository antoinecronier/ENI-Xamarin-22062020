using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tp3.Models
{
    public class VisibilitySwitch
    {
        public View InitialVisible { get; }
        public View NextVisible { get; }

        public VisibilitySwitch(View initialVisible, View nextVisible)
        {
            this.InitialVisible = initialVisible;
            this.NextVisible = nextVisible;
        }

        public void Switch()
        {
            if (this.InitialVisible.IsVisible)
            {
                this.InitialVisible.IsVisible = false;
                this.NextVisible.IsVisible = true;
            }
            else
            {
                this.InitialVisible.IsVisible = true;
                this.NextVisible.IsVisible = false;
            }
        }
    }
}
