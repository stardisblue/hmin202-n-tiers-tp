using System;
using System.Collections.Generic;
using System.Text;

namespace BibliothequeV2
{
    public class Livre : MarshalByRefObject
    {
        String titre;
        String auteur;
        String ISBN;
        uint nb_exemplaire;
        String editeur;
        List<Commentaire> commentaire;

        public Livre(String t, String a, String i, uint nb, String e)
        {
            this.titre = t;
            this.auteur = a;
            this.ISBN = i;
            this.nb_exemplaire = nb;
            this.editeur = e;
            // Dictionary<titre, contenu>
            this.commentaire = new List<Commentaire>();
        }

        public String GetTitre()
        {
            return this.titre;
        }

        public String GetISBN()
        {
            return this.ISBN;
        }

        public string GetAuteur()
        {
            return this.auteur;
        }

        public void AddCommentaire(Client c, String contenu)
        {
            this.commentaire.Add(new Commentaire(c, contenu));
        }

        public override String ToString()
        {
            string str = this.titre + " - " + this.auteur + " - " + this.ISBN + " - " + this.editeur;

            if (commentaire.Count > 0)
            {
                str += "\nListe des commentaires : ";
                
                for(int i = 0; i < commentaire.Count; i++)
                {
                    str += "\n" + commentaire[i].ToString();
                }
                
            }
            return str;
        }

    }
}
