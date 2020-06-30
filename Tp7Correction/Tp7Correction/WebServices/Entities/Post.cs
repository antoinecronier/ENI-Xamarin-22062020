﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tp7Correction.WebServices.Entities
{
    public class Post
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

        private String body;

        public String Body
        {
            get { return body; }
            set { body = value; }
        }

    }
}
