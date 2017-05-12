using share;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Client
{

    public static class Program
    {
        private static IServiceRecette recetteProxy;

        private static void initialisationRecettes()
        {
        }


        //LISTE DE L'ENSEMBLE DES RECETTES DISPONIBLE
        private static void listRecettes()
        {
            Console.WriteLine("Liste des recettes déjà disponible (sélection courante) : ");
            foreach (Recette rec in recetteProxy.listeBase().Values)
            {
                Console.WriteLine(rec.Nom);
            }
        }




        //CREATION D'UNE RECETTE PAR L'UTILISATEUR
        private static void creerRecette()
        {
            Console.WriteLine("\nQuel est le nom de la recette que vous souhaitez créer?");
            String nomRecette = Console.ReadLine();
            // récupérer la recette
            Recette recette = recetteProxy.createRecette(nomRecette);
            Console.WriteLine("\nDonnez l'ensemble des ingredients separées par des espaces");

            String listeIngredients = Console.ReadLine();
            String[] ingredients = listeIngredients.Split(' ');

            Console.WriteLine("\n"+recette.Nom+" : ");

            if (ingredients.Length > 0)
            {
                foreach (string ingredientName in ingredients)
                {
                    Ingredient ingred = recetteProxy.newIngredient(ingredientName);
                    recette.Listeingredients.Add(ingred);
                    Console.WriteLine("\t" + ingred.Nom);
                }
            }

            //Ajout de la recette à la base
            Console.WriteLine(recetteProxy.saveRecette(recette));
        }




        // RECUPERATION DE LA LISTE DES RECETTES POUR UN INGREDIENT DONNE
        private static void getRecetteForIngr()
        {
            Console.WriteLine("\nSaisir l'aliment pour lequel on désire connaitre les recettes  : ");
            String rechercheIng = Console.ReadLine();
            Ingredient ingredientcherch = null;

            Boolean test = false;
            // Voir si ingrédient existe dans une des recettes
            foreach (Recette rec in recetteProxy.listeBase().Values)
            {
                foreach (Ingredient ingr in rec.Listeingredients)
                {

                    if (ingr.Nom.Equals(rechercheIng))
                    {
                        ingredientcherch = ingr;
                        test = true;
                    }

                }
                if (test == false)
                {
                    Console.WriteLine("L'ingrédient donné n'existe pas actuellement");
                }
            }

            List<Recette> listerecette = new List<Recette>();

            if (ingredientcherch != null)
            {
                // Rechercher par ingrédient
                listerecette = recetteProxy.searchRecette(ingredientcherch);
            }

            Console.WriteLine("Nombre de recettes trouvées avec l'ingrédient : " + Convert.ToString(listerecette.Count));

            Console.WriteLine("Liste des recettes contenant cet ingrédient");
            foreach (Recette rec in listerecette)
            {
                // Afficher toutes les recettes retrouvées
                Console.WriteLine("\t" + rec.Nom);
            }

            selectionCourante();
        }


        //LISTE DE LA SELECTION COURANTE
        private static void selectionCourante()
        {
            Console.WriteLine("Liste des recettes dans la selection courante :");
            foreach (Recette rec in recetteProxy.getInfoCourante())
            {
                Console.WriteLine("\t" + rec.Nom);
            }

            if (recetteProxy.getInfoCourante().Count == 0)
            {
                Console.WriteLine("\t--vide--");
            }
        }


        //SUPPRESSION D'UNE RECETTE DE LA SELECTION COURANTE
        private static void delFromCourantSelection()
        {

            Console.WriteLine("Nom de la recette à supprimer de la sélection courante?");
            String supprimcourante = Console.ReadLine();
            Console.WriteLine(recetteProxy.deletecourante(supprimcourante));
        }



        static void Main(string[] args)
        {
            recetteProxy = new ChannelFactory<IServiceRecette>("RecetteClient").CreateChannel();
            Console.WriteLine("proxy initialisé");

            // Ajout de 3 recettes dans la base
            if (recetteProxy.isEmpty())
            {
                initialisationRecettes();
            }
            int choix = 1;
            while (choix != 0)
            {
                Console.WriteLine("\n\nQuelle action voulez-vous effectuer ?");
                Console.WriteLine("1-Liste de l'ensemble des recettes");
                Console.WriteLine("2-Ingredients de chaque recette");
                Console.WriteLine("3-Création d'une recette");
                Console.WriteLine("4-Liste des recettes pour un ingrédient donné");
                Console.WriteLine("5-Recette dans la selection courante");
                Console.WriteLine("6-Suppression d'une recette dans la selection courante");
                Console.WriteLine("7-Rechercher une recette et la definir en tant que selection courante");
                Console.WriteLine("0-Quitter");

                Console.WriteLine("\nVeuillez saisir le numéro de votre choix en appuyer sur entrer");
                choix = Convert.ToInt32(Console.ReadLine());

                switch (choix)
                {
                    case 0:
                        Console.WriteLine("Vous quittez le programme, au revoir");
                        break;
                    case 1:
                        listRecettes();
                        break;
                    case 2:
                        detailsListeCourante();
                        break;
                    case 3:
                        creerRecette();
                        break;
                    case 4:
                        getRecetteForIngr();
                        break;
                    case 5:
                        selectionCourante();
                        break;
                    case 6:
                        delFromCourantSelection();
                        break;
                    case 7:
                        getRecette();
                        break;
                }

            }
            Console.WriteLine("Fin du client");
            Console.ReadLine();
        }

        private static void getRecette()
        {
            Console.WriteLine("\nNom de la recette");
            String nom = Console.ReadLine();
            Recette recette = recetteProxy.getRecette(nom);
            if(recette == null)
            {
                Console.WriteLine("La recette n'existe pas");
            }
            else
            {
                Console.WriteLine("Definie en tant que selection courante");
            }
        }

        private static void detailsListeCourante()
        {
            Console.WriteLine("Details de la liste courante:");
            foreach (var item in recetteProxy.getInfoCourante())
            {
                Console.WriteLine(item.Nom + ":");
                foreach (var ingredient in item.Listeingredients)
                {
                    Console.WriteLine("\t" + ingredient.Nom);
                }

            }
        }
    }
}
