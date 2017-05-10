using BibliothequeUser.BibliothequeService;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Xml;

namespace BibliothequeUser
{
    class Program
    {
        static void Main(string[] args)
        {
            Bibliotheque bibliotheque = new Bibliotheque();

            Book[] books = bibliotheque.getBooks();

            Author author = books[0].Author;

            Debug.WriteLine("Name :"+ author.FirstName + " " + author.LastName);
            Debug.WriteLine("Date de naissance : " + author.DateOfBirth.ToShortDateString());

            Debug.WriteLine("Livres de l'auteur ===");
            foreach (Book book in bibliotheque.findBooksByAuthor(author.FirstName, author.LastName))
            {
                Debug.WriteLine("Titre : " + book.Title + ", Parution : " + book.DatePublication.ToShortDateString() + ", Description : "+ book.Description);
            }


            // Recherche d'un livre :)

            foreach (Book book in bibliotheque.findBooks(books[0].Title))
            {
                Debug.WriteLine("Titre : " + book.Title + ", Parution : " + book.DatePublication.ToShortDateString() + ", Description : " + book.Description);
            }

            // Recherche pas isbn
            Book bookisbn = bibliotheque.getBook(books[2].ISBN);
            Debug.WriteLine("Recherche ISBN =======");
            Debug.WriteLine("Titre : " + bookisbn.Title + ", Parution : " + bookisbn.DatePublication.ToShortDateString() + ", Description : " + bookisbn.Description);

        }
    }
}
