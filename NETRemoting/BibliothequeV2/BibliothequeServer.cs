using System;
using System.Collections.Generic;
using System.Text;

namespace BibliothequeV2
{
    public class BibliothequeServer : MarshalByRefObject
    {
        Dictionary<String, Livre> catalogue;
        Dictionary<String, Client> clients;

        public BibliothequeServer()
        {
            this.catalogue = new Dictionary<string, Livre>();
            this.clients = new Dictionary<string, Client>();
        }

        public void AddClient(Client c)
        {
            this.clients.Add(c.GetId(), c);
        }

        public void AddLivre(Livre o)
        {
            this.catalogue.Add(o.GetTitre(), o);
        }

        public void LoadBiblio()
        {
            Livre l1 = new Livre("Harry Potter à l'école des sorciers", "J.K Rowlling", "0123", 2, "Livre de poche");
            Livre l2 = new Livre("Les 101 dalmatiens", "Disney", "0", 0, "Disney");
            Livre l3 = new Livre("Tistou les pouces verts", "Maurice Druon", "01324", 1, "Gallimard");
            Livre l4 = new Livre("C# curse", "Seriai", "12", 3, "pdf");
            Livre l5 = new Livre("Harry Potter et la coupe de feu", "J.K Rowlling", "01234", 4, "Livre de poche");
            this.AddLivre(l1);
            this.AddLivre(l2);
            this.AddLivre(l3);
            this.AddLivre(l4);
            this.AddLivre(l5);

            Client c1 = new Client("maxime","secret",true);
            Client c2 = new Client("mpyz","mdp",false);
            Client c3 = new Client("lol","azerty",false);
            Client c4 = new Client("xd","1234",false);

            this.AddClient(c1);
            this.AddClient(c2);
            this.AddClient(c3);
            this.AddClient(c4);


        }

        public Client ConnexionUtilisateur(string login, string mdp)
        {
            foreach (KeyValuePair<string, Client> entry in this.clients)
            {
                if (login.Equals(entry.Key))
                {
                    if (mdp.Equals(entry.Value.Getmdp()))
                    {
                        return entry.Value;
                    }
                }
            }
            return null;
        }

        public Client InscriptionClient(string login, string mdp)
        {
            foreach (KeyValuePair<string, Client> entry in this.clients)
            {
                if (login.Equals(entry.Key))
                {
                    return null;
                }
            }
            Client nouveauClient = new Client(login, mdp, false);
            this.clients.Add(login, nouveauClient);
            return nouveauClient;
        }

        public void PosterCommentaire(Client c, string commentaire, Livre v)
        {
            catalogue[v.GetTitre()].AddCommentaire(c, commentaire);
        }

        public Livre ChercherParISBN(string str)
        {
            if (catalogue.Count == 0)
            {
                return null;
            }

            foreach (KeyValuePair<string, Livre> entry in this.catalogue)
            {
                if (str.Equals(entry.Value.GetISBN()))
                {
                    return entry.Value;
                }
            }
            return null;
        }

        public List<Livre> ChercherParAuteur(string str)
        {
            if (catalogue.Count == 0)
            {
                return null;
            }

            List<Livre> list = new List<Livre>();
            foreach (KeyValuePair<string, Livre> entry in this.catalogue)
            {
                if (str.Equals(entry.Value.GetAuteur()))
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

        public Dictionary<String, Livre> GetAllLivres()
        {
            return catalogue;
        }

        public override String ToString()
        {
            if (catalogue.Count == 0)
            {
                return "Erreur, pas de livre dans la bibliotheque";
            }

            string str = "";
            foreach (KeyValuePair<string, Livre> entry in this.catalogue)
            {
                str += entry.Value.ToString() + "\n";
            }
            return str;
        }
    }
}
