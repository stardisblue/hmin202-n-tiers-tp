using System;

namespace models
{
    public class Author
    {
        public string FirstName;
        public String LastName;
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
