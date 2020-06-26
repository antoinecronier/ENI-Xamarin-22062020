using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ENI_Xamarin_30032020.Entities
{
    public class User : SQLiteEntity, INotifyPropertyChanged
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

		private String login;
		private String password;
		private String pseudo;

		public String Login
		{
			get { return login; }
			set 
			{ 
				login = value;
				OnPropertyChanged("Login");
			}
		}

		public String Password
		{
			get { return password; }
			set 
			{ 
				password = value;
				OnPropertyChanged("Password");
			}
		}

		public String Pseudo
		{
			get { return pseudo; }
			set 
			{ 
				pseudo = value;
				OnPropertyChanged("Pseudo");
			}
		}

	}
}
