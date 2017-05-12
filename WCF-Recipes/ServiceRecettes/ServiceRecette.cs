using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using share;

namespace ServiceRecettes
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceRecette : IServiceRecette
    {

        List<Recette> baseRecettes;

        //List of all reciped in the current session
        public List<Recette> selectionCour = new List<Recette>();
        //List of all ingredients in the service
        public List<Ingredient> ingredients = new List<Ingredient>();


        public Recette recet = new Recette();

        public ServiceRecette()
        {
            baseRecettes = new List<Recette>();
            Recette recette = new Recette();
            Ingredient ingredient = new Ingredient();
            ingredient.Nom = "yolo";
            recette.Listeingredients.Add(ingredient);
            recette.Nom = "test";
            baseRecettes.Add(recette);
        }


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }


        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


        public bool containsIngredient(String nameIngredient)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient.Nom.Equals(nameIngredient))
                {
                    return true;
                }
            }
            return false;
        }


        public List<Recette> rechercheParNomIngredient(String nom)
        {
            List<Recette> listeRecettes = new List<Recette>();

            return listeRecettes;

        }

        public Recette newRecette(String nom)
        {
            Recette recette = new Recette();
            recette.Nom = nom;
            recette.Listeingredients = new List<Ingredient>();
            baseRecettes.Add(recette);

            return recette;
        }

        public Ingredient newIngredient(String nom)
        {
            foreach (Ingredient ingredient in ingredients)
            {
                if (ingredient.Nom.Equals(nom)) return ingredient;
            }
            Ingredient newIngredient = new Ingredient();
            newIngredient.Nom = nom;
            return newIngredient;
        }



        public List<Recette> searchRecette(Ingredient ingr)
        {
            List<Recette> liste = new List<Recette>();


            foreach (Recette rec in baseRecettes)
            {
                foreach (Ingredient ingred in rec.Listeingredients)
                {

                    if (ingred.Nom.Equals(ingr.Nom))
                    {
                        if (!liste.Contains(rec))
                        {
                            Console.WriteLine("La recette " + rec.Nom + " fait partie des recettes contenant l'ingrédient " + ingr.Nom);
                            liste.Add(rec);
                            selectionCour.Add(rec);
                        }
                    }
                }
            }

            return liste;
        }


        public String getNomIngre(Ingredient ing)
        {
            return ing.Nom;
        }


        public String getNomRecette(Recette rec)
        {
            return rec.Nom;
        }

        public Boolean isEmpty()
        {
            Boolean empty = true;
            if (this.baseRecettes.Count() != 0)
            {
                empty = false;
            }

            return empty;
        }


        public string deletecourante(String nom)
        {
            foreach (Recette rec in selectionCour)
            {
                if (rec.Nom.Equals(nom))
                {
                    selectionCour.Remove(rec);
                    Console.WriteLine("Suppression de la sélection courante effectuée");
                    return "Suppression de la sélection courante ok";
                }
            }

            return "Suppression impossible";
        }

        public List<Recette> getInfoCourante()
        {
            return selectionCour;
        }


        public string addRecette(Recette recettes)
        {
            this.recet = recettes;
            Boolean test = false;

            foreach (Recette rec in baseRecettes)
            {
                if (rec.Nom.Equals(recettes.Nom))
                {
                    test = true;
                }
            }

            if (test == false)
            {
                baseRecettes.Add(recet);
                Console.WriteLine("Ajout de la recette " + recet.Nom + " réussi");
                return "Ajout de la recette " + recet.Nom + " réussi";

            }
            else
            {
                Console.WriteLine("Recette avec même nom existe déjà : " + recet.Nom);
                return "Recette avec même nom existe déjà : " + recet.Nom;
            }
        }


        public void initializebase()
        {
            baseRecettes = new List<Recette>();
        }


        public List<Recette> listeBase()
        {
            return baseRecettes;
        }
    }
}
