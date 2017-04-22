using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using BibliothequeV2;


namespace Bibiliotheque
{
    class Client
    {
        public bool init = false;
        BibliothequeV2.Client client;
        BibliothequeServer bs;

        public static int Main(string[] args)
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan, true);
            BibliothequeServer obj = (BibliothequeServer)Activator.GetObject(typeof(BibliothequeServer), "tcp://localhost:8089/Bibliotheque");
            
            Console.WriteLine("Bienvenue sur l'application cliente !");

            int entry = 0;
            Client c = new Client();
            c.SetClient(null);
            c.SetBiblioObject(obj);
            string str;
            while(entry != 5)
            {
                
                entry = c.GenerationMenu();

                switch (entry){
                    //Cas de la connexion
                    case 1:
                        c.CasConnexion();                        
                        break;
                    case 2:
                        //Cas Commentaire
                        if (c.IsConnected())
                        {
                            c.CasCommentaire();
                        }
                        //Cas Inscription
                        else { c.CasInscription(); }
                        break;
                    //Cas de la recherche par Auteur
                    case 3:
                        c.CasRechercheAuteur();
                        break;
                    //Cas de la recherche par ISBN
                    case 4:
                        Console.WriteLine("Entrez le numéro ISBN : ");
                        str = Console.ReadLine();
                        Console.WriteLine(obj.ChercherParISBN(str));

                        break;
                    //Cas de la fermeture d'application
                    case 5:
                        Console.WriteLine("Bonne journée :)");
                        break;
                    default:
                        Console.WriteLine("Vous avez rentré un numéro invalide, reessayez ...");
                        break;
                }
            }

            Console.WriteLine("Appuyez sur <Entré> pour quitter");
            Console.ReadLine();
            return 0;

        }
        

        public bool IsConnected()
        {
            return client != null;
        }

        public bool IsAdmin()
        {
            return client.isAdmin();
        }

        public void SetClient(BibliothequeV2.Client c)
        {
            client = c;
        }

        public BibliothequeV2.Client GetClient()
        {
            return client;
        }

        public void SetBiblioObject(BibliothequeServer o)
        {
            bs = o;
        }

        public int GenerationMenu()
        {
            string menu = "Menu :\n";
            if (!this.IsConnected())
            {
                menu += "1) Se connecter\n2) S'inscrire \n";
            }
            else
            {
                menu += "1) Se Déconnecter\n2) Ecrire un commentaire\n";
            }
            Console.WriteLine(menu + "3) Chercher par auteur\n4) Chercher par ISBN\n5) Sortir");
            string str = Console.ReadLine();
            int retour;
            try
            {
                retour = Int32.Parse(str);
            }
            catch (Exception e)
            {
                retour = 0;
            }
            
            return retour;
        }

        public void CasCommentaire()
        {   
            Console.WriteLine("Veuillez rentrer le numéro ISBN du livre que vous souhaitez commenter :");
            String idISBN = Console.ReadLine();
            Livre l = bs.ChercherParISBN(idISBN);
            if(l == null)
            {
                Console.WriteLine("Vous avez rentré un mauvais numéro ISBN ...");
                return;
            }
            Console.WriteLine("Veuillez écrire le commentaire :");
            String commentaire = Console.ReadLine();
            bs.PosterCommentaire(client, commentaire, l);
        }

        public void CasInscription()
        {
            Console.WriteLine("Veuillez entrer le pseudo voulu : ");
            string login = Console.ReadLine();
            Console.WriteLine("Veuillez entrer le mot de passe voulu : ");
            string mdp = Console.ReadLine();
            this.client = bs.InscriptionClient(login, mdp);
            if(this.client == null)
            {
                Console.WriteLine("Il y a eu un erreur lors de l'inscription veuillez reessayer (login déjà existant)");
                return;
            }
            Console.WriteLine("Inscription réussie avec succès !");
        }

        public void CasConnexion()
        {
            if (this.IsConnected())
            {
                client = null;
                return;
            }

            Console.WriteLine("Entrez votre login :");
            String login = Console.ReadLine();

            Console.WriteLine("Entrez votre mot de passe :");
            String mdp = Console.ReadLine();

            client = bs.ConnexionUtilisateur(login, mdp);
            if (client == null)
            {
                Console.WriteLine("Mauvais Login/Mot de passe");
            }
            else
            {
                string phraseConnexion = "Bienvenue ";
                if (client.isAdmin())
                {
                    phraseConnexion += " maitre ";
                }
                Console.WriteLine(phraseConnexion + login);
            }
        }

        public void CasRechercheAuteur()
        {
            Console.WriteLine("Entrez le nom de l'auteur : ");
            string str = Console.ReadLine();

            List<Livre> l = bs.ChercherParAuteur(str);
            if (l != null)
            {
                for (int i = 0; i < l.Count; i++)
                {
                    Console.WriteLine(l[i].ToString());
                }
            }
        }
    }
}