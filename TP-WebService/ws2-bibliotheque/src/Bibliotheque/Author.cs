using System;

namespace BibliothequeClass
{
    public class Author
    {
        public string FirstName;
        public string LastName;
        public DateTime DateOfBirth;

        public Author()
        {

        }

        public Author(string FirstName, string LastName, DateTime DateOfBirth)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.DateOfBirth = DateOfBirth;
        }

    }
}
