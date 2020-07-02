using System;
using System.Collections.Generic;
using System.Text;
using Tp8.Entities;

namespace Tp8.Models
{
    public class TweetSearch : BaseNotyfied
    {
        private DateTime searchDate;

        public DateTime SearchDate
        {
            get { return searchDate; }
            set 
            { 
                searchDate = value;
                this.OnPropertyChanged("SearchDate");
            }
        }

        private bool searchDateChecked;

        public bool SearchDateChecked
        {
            get { return searchDateChecked; }
            set 
            { 
                searchDateChecked = value;
                this.OnPropertyChanged("SearchDateChecked");
            }
        }

        private String username;

        public String Username
        {
            get { return username; }
            set 
            { 
                username = value;
                this.OnPropertyChanged("Username");
            }
        }

        private bool usernameChecked;

        public bool UsernameChecked
        {
            get { return usernameChecked; }
            set
            {
                usernameChecked = value;
                this.OnPropertyChanged("UsernameChecked");
            }
        }
        public TweetSearch()
        {

        }
    }
}
