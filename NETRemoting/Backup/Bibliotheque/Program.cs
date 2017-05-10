using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bibliotheque
{
    public class BibliothequeServer : MarshalByRefObject
    {
        Dictionary<String, Livre> catalogue;

        public BibliothequeServer()
        {
            this.catalogue = new Dictionary<string, Livre>();
        }

        public void addLivre(Livre o)
        {
            this.catalogue.Add(o.getTitre(), o);
        }

        public void loadBiblio()
        {
            Livre l1 = new Livre("Harry Potter à l'école des sorciers", "J.K Rowlling", "0123", 2, "Livre de poche");
            Livre l2 = new Livre("Les 101 dalmatiens", "Disney", "0", 0, "Disney");
            Livre l3 = new Livre("Tistou les pouces verts", "Maurice Druon", "01324", 1, "Gallimard");
            Livre l4 = new Livre("C# curse", "Seriai", "12", 3, "pdf");
            Livre l5 = new Livre("Harry Potter et la coupe de feu", "J.K Rowlling", "01234", 4, "Livre de poche");
            this.addLivre(l1);
            this.addLivre(l2);
            this.addLivre(l3);
            this.addLivre(l4);
            this.addLivre(l5);
        }

        public Livre chercherParISBN(string str)
        {

            if (catalogue.Count == 0)
            {
                return null;
            }

            foreach (KeyValuePair<string, Livre> entry in this.catalogue)
            {
                if(str.Equals(entry.Value.getISBN())){
                    return entry.Value;
                }
            }
            return null;
        }

        public List<Livre> chercherParAuteur(string str)
        {
            if (catalogue.Count == 0)
            {
                return null;
            }

            List<Livre> list = new List<Livre>();
            foreach (KeyValuePair<string, Livre> entry in this.catalogue)
            {
                if (str.Equals(entry.Value.getAuteur()))
                {
                    list.Add(entry.Value);
                }
            }

            if (list.Count == 0)
            {
                return null;
            }
            return list;
        }

        public String toString()
        {
            if (catalogue.Count == 0)
            {
                return "Erreur, pas de livre dans la bibliotheque";
            }

            string str = "";
            foreach (KeyValuePair<string, Livre> entry in this.catalogue)
            {
                str += entry.Value.toString() + "\n";
            }
            return str;
        }
    }

    public class Livre : MarshalByRefObject
    {
        String titre;
        String auteur;
        String ISBN;
        uint nb_exemplaire;
        String editeur;
        Dictionary<String, String> commentaire;

        public Livre(String t, String a, String i, uint nb, String e)
        {
            this.titre = t;
            this.auteur = a;
            this.ISBN = i;
            this.nb_exemplaire = nb;
            this.editeur = e;
            // Dictionary<titre, contenu>
            this.commentaire = new Dictionary<string, string>();
        }

        public String getTitre()
        {
            return this.titre;
        }

        public String getISBN()
        {
            return this.ISBN;
        }

        public string getAuteur()
        {
            return this.auteur;
        }

        public void addCommentaire(String titre, String contenu)
        {
            this.commentaire.Add(titre, contenu);
        }

        public String toString()
        {
            string str = this.titre + " - " + this.auteur + " - " + this.ISBN + " - " + this.editeur;

            if (commentaire.Count > 0)
            {
                str += "\nListe des commentaires : ";

                foreach (KeyValuePair<string, string> entry in this.commentaire)
                {
                    str += "\n" + entry.Key + "\n\t" + entry.Value;
                }
            }
            return str;
        }

    }
}
