using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Xml.Serialization;
using BibliothequeClass;

[WebService(Namespace = "http://stardis.blue/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Bibliotheque : WebService
{
    private static Books books;
    private static List<User> users = new List<User>();
    private static Dictionary<string, User> connectedUsers = new Dictionary<string, User>();

    public Bibliotheque()
    {
    }

    static Bibliotheque()
    {
        Author jkrowlings = new Author("J. K.", "Rowling", new DateTime(1965, 07, 31));
        Book harryPotter1 = new Book(2070518426, jkrowlings, "Harry Potter 1", "Harry Potter and the Philosopher's Stone", "Fantasy", new DateTime(1997, 06, 26));
        Book harryPotter2 = new Book(0747538492, jkrowlings, "Harry Potter 2", "Harry Potter and the Chamber of Secrets", "Fantasy", new DateTime(1998, 07, 2));
        Book harryPotter3 = new Book(0747542155, jkrowlings, "Harry Potter 3", "Harry Potter and the Prisoner of Azkaban", "Fantasy", new DateTime(1999, 07, 8));
        Book harryPotter4 = new Book(074754624, jkrowlings, "Harry Potter 4", "Harry Potter and the Goblet of Fire", "Fantasy", new DateTime(2000, 07, 8));
        Book harryPotter5 = new Book(0747551006, jkrowlings, "Harry Potter 5", "Harry Potter and the Order of the Phoenix", "Fantasy", new DateTime(2003, 06, 21));
        Book harryPotter6 = new Book(0747581088, jkrowlings, "Harry Potter 6", "Harry Potter and the Half-Blood Prince", "Fantasy", new DateTime(2005, 07, 16));
        Book harryPotter7 = new Book(0545010225, jkrowlings, "Harry Potter 7", "Harry Potter and the Deathly Hallows", "Fantasy", new DateTime(2007, 07, 21));
        books = new Books(new Book[7] { harryPotter1, harryPotter2, harryPotter3, harryPotter4, harryPotter5, harryPotter6, harryPotter7 });

        users.Add(new User("admin", "admin", true));
        users.Add(new User("user", "user"));

    }

    [WebMethod(Description = "Permet de se connecter au service")]
    public string connect(string Username, string Password)
    {
        foreach (User user in users)
        {
            if (user.Username == Username && user.Password == Password)
            {
                string token = Username + ":" + Password;
                if (!connectedUsers.ContainsKey(token))
                {
                    connectedUsers.Add(token, user);
                }
                return token;
            }
        }

        return null;
    }

    [WebMethod(Description = "Permet de se deconnecter du service")]
    public bool disconnect(string token)
    {
        return connectedUsers.Remove(token);
    }

    private bool isConnected(string token)
    {
        return connectedUsers.ContainsKey(token);
    }

    private bool isAdmin(string token)
    {
        if (!isConnected(token))
            return false;

        User user = connectedUsers[token];

        return user.Admin;
    }


    [WebMethod(Description = "Permet d'ajouter un commentaire")]
    public bool addComment(int ISBN, string content, string token)
    {
        if (!isConnected(token))
            return false;


        Book book = getBook(ISBN);
        if (book == null)
            return false;

        User user = connectedUsers[token];
        book.Comments.Add(new Comment(user.Username, content));

        return true;
    }

    public bool addUser(string Username, string Password, string token)
    {
        if (!isAdmin(token)) return false;

        foreach (User user in users)
            if (Username == user.Username)
                return false;

        users.Add(new User(Username, Password));
        return true;

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
            if (ISBN == item.ISBN)
                return item;

        return null;
    }

    [WebMethod(Description = "Ajouter un livre")]
    public Book addBook(int ISBN, string AuthorFirstName, string AuthorLastName, DateTime DateOfBirth, string Title, string Description, string Genre, DateTime DatePublication, string token)
    {
        if (!isAdmin(token))
            return null;

        if (getBook(ISBN) != null)
            return null;

        Author auth = new Author(AuthorFirstName, AuthorLastName, DateOfBirth);
        Book book = new Book(ISBN, auth, Title, Description, Genre, DatePublication);
        books.books.Add(book);
        return book;

    }

    [WebMethod(Description = "Supprimer un livre")]
    public Book deleteBook(int ISBN, string token)
    {
        if (!isAdmin(token)) return null;

        Book book = null;
        foreach (Book item in books.books)
            if (ISBN == item.ISBN)
            {
                book = item;
                break;
            }

        if (book == null) return null;
        books.books.Remove(book);

        return book;

    }

    [WebMethod(Description = "Trouve tous les livres ayant ce nom")]
    public Books findBooks(String name)
    {
        Books foundBooks = new Books();
        foreach (Book book in books.books)
            if (book.Title.Contains(name))
                foundBooks.books.Add(book);

        return foundBooks;
    }

    [WebMethod(Description = "Trouve tous les livres de cet autheur")]
    public Books findBooksByAuthor(string FirstName, string LastName)
    {
        Books tempBooks = new Books();
        foreach (Book book in books.books)
            if (book.Author.FirstName.Contains(FirstName) && book.Author.LastName.Contains(LastName))
                tempBooks.books.Add(book);

        return tempBooks;
    }
}