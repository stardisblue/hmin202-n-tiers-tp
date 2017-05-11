using System;
using System.Xml.Serialization;
using System.Collections.Generic;
namespace BibliothequeClass
{
    public class Books
    {
        [XmlElement(ElementName = "Book")]
        public List<Book> books;

        public Books()
        {
            books = new List<Book>();
        }
        public Books(Book[] books)
        {
            this.books = new List<Book>(books);
        }
    }

    public class Book
    { 
        public int ISBN;
        public Author Author;
        public string Title;
        public string Description;
        public string Genre;
        public DateTime DatePublication;
        public List<Comment> Comments;

        public Book(int ISBN, Author Author, string Title, string Description, string Genre, DateTime DatePublication)
        {
            this.ISBN = ISBN;
            this.Author = Author;
            this.Title = Title;
            this.Description = Description;
            this.Genre = Genre;
            this.DatePublication = DatePublication;
            this.Comments = new List<Comment>();
        }

        public Book()
        {
        }
    }
}