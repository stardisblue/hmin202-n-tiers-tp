using System;
using System.Collections.Generic;
using System.Text;

namespace BibliothequeClass
{
    public class Comment
    {
        public string Content;
        public string Username;

        public Comment(string Username, string Content) {
            this.Username = Username;
            this.Content = Content;
        }

        public Comment()
        {
        }
    }
}
