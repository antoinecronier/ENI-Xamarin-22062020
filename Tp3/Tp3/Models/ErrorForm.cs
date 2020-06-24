using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Tp3.Models
{
    public class ErrorForm
    {
        public Label ErrorLabel { get; }
        public String Error { get; set; }

        public ErrorForm(Label errorLabel)
        {
            this.ErrorLabel = errorLabel;
            this.SetupErrorLabel();
        }

        private void SetupErrorLabel()
        {
            this.ErrorLabel.BackgroundColor = Color.Red;
            this.ErrorLabel.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Hide();
        }

        public void Display()
        {
            this.ErrorLabel.Text = this.Error;
            this.ErrorLabel.IsVisible = true;
        }

        public void Hide()
        {
            this.ErrorLabel.IsVisible = false;
        }
    }
}
