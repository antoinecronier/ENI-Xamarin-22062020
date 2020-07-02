using System;
using System.Collections.Generic;
using System.Text;
using Tp9.Entities;
using Xamarin.Forms;

namespace Tp9.Models
{
    public class ErrorForm : BaseNotyfied
    {
        private String data;

        public String Data
        {
            get { return data; }
            set 
            { 
                data = value;
                this.OnPropertyChanged("Data");
            }
        }

        private Color testColor;

        public Color TextColor
        {
            get { return testColor; }
            set 
            {
                testColor = value;
                this.OnPropertyChanged("TextColor");
            }
        }

        private Color backgroundColor;

        public Color BackgroundColor
        {
            get { return backgroundColor; }
            set 
            {
                backgroundColor = value;
                this.OnPropertyChanged("BackgroundColor");
            }
        }

        private LayoutOptions horizontalOptions;

        public LayoutOptions HorizontalOptions
        {
            get { return horizontalOptions; }
            set 
            { 
                horizontalOptions = value;
                this.OnPropertyChanged("HorizontalOptions");
            }
        }

        private Boolean isVisible;

        public Boolean IsVisible
        {
            get { return isVisible; }
            set 
            { 
                isVisible = value;
                this.OnPropertyChanged("IsVisible");
            }
        }


        public ErrorForm()
        {
            this.Data = "";
            this.SetupErrorLabel();
        }

        private void SetupErrorLabel()
        {
            this.TextColor = Color.Black;
            this.BackgroundColor = Color.Red;
            this.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Hide();
        }

        public void Display()
        {
            this.IsVisible = true;
        }

        public void Hide()
        {
            this.IsVisible = false;
        }
    }
}
