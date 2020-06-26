using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ENI_Xamarin_30032020.Models
{
    public class SearchListItem : INotifyPropertyChanged
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

        private ObservableCollection<SearchListItem> searchListItems;

        private String choice;
        private String value;


        public String Choice
        {
            get { return choice; }
            set 
            { 
                choice = value;
                OnPropertyChanged("Choice");
            }
        }

        public String Value
        {
            get { return value; }
            set 
            { 
                this.value = value;
                OnPropertyChanged("Value");
            }
        }

        public RelayCommand Delete
        {
            get 
            { 
                return new RelayCommand(()=>
                {
                    this.searchListItems.Remove(this);
                }); 
            }
        }

        public SearchListItem(ObservableCollection<SearchListItem> searchListItems)
        {
            this.searchListItems = searchListItems;
        }
    }
}
