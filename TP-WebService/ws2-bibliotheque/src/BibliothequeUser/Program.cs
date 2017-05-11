using BibliothequeUser.BibliothequeService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace BibliothequeUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibliotheque = new Bibliotheque();

            Book[] books = bibliotheque.getBooks();

            Author author = books[0].Author;
            Debug.WriteLine("Get Autheur");
            Debug.Indent();
            Debug.WriteLine("Name :" + author.FirstName + " " + author.LastName);
            Debug.WriteLine("Date de naissance : " + author.DateOfBirth.ToShortDateString());
            Debug.Unindent();
            Debug.WriteLine("Livres de l'auteur");
            Debug.Indent();
            foreach (Book book in bibliotheque.findBooksByAuthor(author.FirstName, author.LastName))
            {
                Debug.WriteLine("Titre : " + book.Title + ", Parution : " + book.DatePublication.ToShortDateString() + ", Description : " + book.Description);
            }
            Debug.Unindent();


            // Recherche d'un livre :)
            Debug.WriteLine("Recherche Livre");
            Debug.Indent();
            foreach (Book book in bibliotheque.findBooks(books[0].Title))
            {
                Debug.WriteLine("Titre : " + book.Title + ", Parution : " + book.DatePublication.ToShortDateString() + ", Description : " + book.Description);
            }
            Debug.Unindent();

            // Recherche pas isbn
            Book bookisbn = bibliotheque.getBook(books[2].ISBN);
            Debug.WriteLine("Recherche ISBN");
            Debug.Indent();
            Debug.WriteLine("Titre: " + bookisbn.Title + ", Parution : " + bookisbn.DatePublication.ToShortDateString() + ", Description : " + bookisbn.Description);
            Debug.Unindent();

            Debug.WriteLine("Connexion et ajout commentaire");
            Debug.Indent();
            string token = bibliotheque.connect("user", "user");
            bibliotheque.addComment(bookisbn.ISBN, "this is a comment", token);
            Book update = bibliotheque.getBook(bookisbn.ISBN);
            Debug.WriteLine("Title: " + update.Title + ", Parution: " + update.DatePublication.ToShortDateString() + ", Description: " + bookisbn.Description);
            Debug.WriteLine("Comments: ");
            Debug.Indent(); 
            foreach (Comment comm in update.Comments)
            {
                Debug.WriteLine(comm.Username + " \"" + comm.Content + "\"");
            }
            Debug.Unindent();
            Debug.Unindent();

            bibliotheque.disconnect(token);

        }
    }
}
