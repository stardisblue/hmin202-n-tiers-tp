using System;
using System.Xml.Serialization;

namespace models
{
    public class Books
    {
        [XmlElement(ElementName = "Book")]
        public Book[] books;

        public Books()
        {
        
        }
        public Books(Book[] books)
        {
            this.books = books;
        }
    }

    public class Book
    { 
        public int ISBN;
        public Author Author;
        public string Title;
        public String Description;
        public String Genre;
        public DateTime DatePublication;

        public Book(int ISBN, Author Author, string Title, string Description, string Genre, DateTime DatePublication)
        {
            this.ISBN = ISBN;
            this.Author = Author;
            this.Title = Title;
            this.Description = Description;
            this.Genre = Genre;
            this.DatePublication = DatePublication;
        }

        public Book()
        {
        }
    }
}