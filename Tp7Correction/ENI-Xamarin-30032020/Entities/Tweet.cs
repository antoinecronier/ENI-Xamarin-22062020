using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ENI_Xamarin_30032020.Entities
{
    public class Tweet : SQLiteEntity, INotifyPropertyChanged
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

		private String identifier;
		private DateTime creationDate;
		private User user;
		private String content;

		public String Identifier
		{
			get { return identifier; }
			set 
			{ 
				identifier = value;
				OnPropertyChanged("Identifier");
			}
		}
		public DateTime CreationDate
		{
			get { return creationDate; }
			set 
			{ 
				creationDate = value;
				OnPropertyChanged("CreationDate");
			}
		}
		public String Content
		{
			get { return content; }
			set 
			{ 
				content = value;
				OnPropertyChanged("Content");
			}
		}

		public virtual User User
		{
			get { return user; }
			set 
			{ 
				user = value;
				OnPropertyChanged("User");
			}
		}

		public Tweet()
		{
			this.user = new User();
		}
	}
}
