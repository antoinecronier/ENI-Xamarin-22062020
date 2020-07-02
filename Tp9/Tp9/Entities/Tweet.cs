using System;
using System.Collections.Generic;
using System.Text;

namespace Tp9.Entities
{
    public class Tweet : BaseNotyfied, BaseDbEntity
    {
        private int id;
        private User user;
        private String data;
        private DateTime createdAt;

        public User User
        {
            get { return user; }
            set 
            { 
                user = value;
                this.OnPropertyChanged("User");
            }
        }
        public String Data
        {
            get { return data; }
            set 
            { 
                data = value;
                this.OnPropertyChanged("Data");
            }
        }
        public DateTime CreatedAt
        {
            get { return createdAt; }
            set 
            { 
                createdAt = value;
                this.OnPropertyChanged("CreatedAt");
            }
        }

        public int Id { get => this.id; set => this.id = value; }
    }
}
