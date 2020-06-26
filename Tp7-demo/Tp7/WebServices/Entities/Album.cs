using System;
using System.Collections.Generic;
using System.Text;

namespace Tp7.WebServices.Entities
{
    public class Album
    {
        private int userId;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String title;

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
    }
}
