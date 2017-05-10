using models;
using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml.Serialization;

[WebService(Namespace = "http://stardis.blue/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Bibliotheque : WebService
{
    private Books books;

    public Bibliotheque()
    {
        Author jkrowlings = new Author("J. K.", "Rowling",new DateTime(1965,07,31));
        Book harryPotter1 = new Book(2070518426,jkrowlings, "Harry Potter 1", "Harry Potter and the Philosopher's Stone","Fantasy",new DateTime(1997,06,26));
        Book harryPotter2 = new Book(0747538492, jkrowlings, "Harry Potter 2", "Harry Potter and the Chamber of Secrets", "Fantasy",new DateTime(1998,07,2));
        Book harryPotter3 = new Book(0747542155, jkrowlings, "Harry Potter 3", "Harry Potter and the Prisoner of Azkaban", "Fantasy",new DateTime(1999,07,8));
        Book harryPotter4 = new Book(074754624, jkrowlings, "Harry Potter 4", "Harry Potter and the Goblet of Fire", "Fantasy",new DateTime(2000,07,8));
        Book harryPotter5 = new Book(0747551006, jkrowlings, "Harry Potter 5", "Harry Potter and the Order of the Phoenix", "Fantasy",new DateTime(2003,06,21));
        Book harryPotter6 = new Book(0747581088, jkrowlings, "Harry Potter 6", "Harry Potter and the Half-Blood Prince", "Fantasy",new DateTime(2005,07,16));
        Book harryPotter7 = new Book(0545010225, jkrowlings, "Harry Potter 7", "Harry Potter and the Deathly Hallows", "Fantasy",new DateTime(2007,07,21));
        books = new Books(new Book[7] { harryPotter1, harryPotter2, harryPotter3, harryPotter4, harryPotter5, harryPotter6, harryPotter7 });
    }
    
    [WebMethod(Description = "Récupère la liste des livres de la bibliothèque")]
    public Books getBooks()
    {
        return books;
    }

    [WebMethod(Description = "Récupere un livre grâce à l'isbn")]
    public Book getBook(int ISBN)
    {
        foreach (Book item in books.books)
        {
            if(ISBN == item.ISBN)
            {
                return item;
            }
        }
        return null;
    }

    [WebMethod(Description = "Trouve tous les livres ayant ce nom")]
    public Books findBooks(String name)
    {
        List<Book> tempBooks = new List<Book>();
        foreach (Book book in this.books.books)
        {
            if (book.Title.Contains(name))
            {
                tempBooks.Add(book);
            }
        }
        Books Books = new Books(tempBooks.ToArray());

        return Books;
    }

    [WebMethod(Description = "Trouve tous les livres de cet autheur")]
    public Books findBooksByAuthor(string FirstName, string LastName)
    {
        List<Book> tempBooks = new List<Book>();
        foreach (Book book in this.books.books)
        {
            if(book.Author.FirstName == FirstName && book.Author.LastName == LastName)
            {
                tempBooks.Add(book);
            }
        }
        Books Books = new Books(tempBooks.ToArray());

        return Books;
    }
}