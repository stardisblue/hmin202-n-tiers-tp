using share;
using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ServiceRecettes
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class ServiceRecette : IServiceRecette
    {

        Dictionary<string, Recette> baseRecettes = new Dictionary<string, Recette>();

        //List of all reciped in the current session
        public List<Recette> selectionCour = new List<Recette>();
        //List of all ingredients in the service
        public Dictionary<string, Ingredient> ingredients = new Dictionary<string, Ingredient>();

        public ServiceRecette()
        {
            Recette recette = createRecette("Pate carbonara");

            Ingredient ingr1 = newIngredient("pates");
            Ingredient ingr2 = newIngredient("creme fraiche");
            Ingredient ingr3 = newIngredient("lardon");
            Ingredient ingr4 = newIngredient("oeuf");
            Ingredient ingr5 = newIngredient("oignon");

            recette.Listeingredients.Add(ingr1);
            recette.Listeingredients.Add(ingr2);
            recette.Listeingredients.Add(ingr3);
            recette.Listeingredients.Add(ingr4);
            recette.Listeingredients.Add(ingr5);

            saveRecette(recette);


            Recette recettespagh = createRecette("Salade composé");

            Ingredient ingr6 = newIngredient("salade");
            Ingredient ingr7 = newIngredient("tomate");
            Ingredient ingr8 = newIngredient("oeuf");
            Ingredient ingr9 = newIngredient("oignon");
            Ingredient ingr10 = newIngredient("mais");

            recettespagh.Listeingredients.Add(ingr6);
            recettespagh.Listeingredients.Add(ingr7);
            recettespagh.Listeingredients.Add(ingr8);
            recettespagh.Listeingredients.Add(ingr9);
            recettespagh.Listeingredients.Add(ingr10);

            saveRecette(recettespagh);


            Recette recettecouscous = createRecette("tomate au sel");

            Ingredient ingr11 = newIngredient("tomate");
            Ingredient ingr12 = newIngredient("sel");

            recettecouscous.Listeingredients.Add(ingr11);
            recettecouscous.Listeingredients.Add(ingr12);

            saveRecette(recettecouscous);
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

        public Recette createRecette(string nom)
        {
            if (baseRecettes.ContainsKey(nom))
            {
                return baseRecettes[nom];
            }

            Recette recette = new Recette();
            recette.Nom = nom;
            recette.Listeingredients = new List<Ingredient>();
            baseRecettes.Add(nom, recette);

            Console.WriteLine("Recette| New> " + nom);
            return recette;
        }

        public string addRecette(Recette recette)
        {
            if (baseRecettes.ContainsKey(recette.Nom))
            {
                Console.WriteLine("Recette| Add> !Already exist! " + recette.Nom);
                return "Recette avec même nom existe déjà : " + recette.Nom;
            }

            baseRecettes.Add(recette.Nom, recette);
            foreach (Ingredient ingredient in recette.Listeingredients)
            {
                newIngredient(ingredient.Nom);
            }

            Console.WriteLine("Recette| Add> " + recette.Nom);
            return "Ajout de la recette " + recette.Nom + " réussi";
        }

        public Recette getRecette(string Nom)
        {
            if (baseRecettes.ContainsKey(Nom))
            {
                selectionCour = new List<Recette>();
                selectionCour.Add(baseRecettes[Nom]);
                return baseRecettes[Nom];
            }
                

            return null;
        }

        public string saveRecette(Recette recette)
        {
            if (baseRecettes.ContainsKey(recette.Nom))
            {
                baseRecettes[recette.Nom].Listeingredients = recette.Listeingredients;
                Console.WriteLine("Recette| Updated> " + recette.Nom);
                return "Recette" + recette.Nom + " mise à jour";
            }

            baseRecettes.Add(recette.Nom, recette);
            Console.WriteLine("Recette| Created> " + recette.Nom);
            return "Recette" + recette.Nom + " ajoutée";
        }

        public Ingredient newIngredient(string nom)
        {
            if (ingredients.ContainsKey(nom))
                return ingredients[nom];

            Ingredient newIngredient = new Ingredient();
            newIngredient.Nom = nom;
            ingredients.Add(nom, newIngredient);

            Console.WriteLine("Ingredient| New> " + nom);
            return newIngredient;
        }

        public Ingredient getIngredient(string Nom)
        {
            if (ingredients.ContainsKey(Nom))
                return ingredients[Nom];

            return null;
        }

        public string addIngredient(string Recette, string Ingredient)
        {
            if (baseRecettes.ContainsKey(Recette))
            {
                bool existant = false;
                foreach (var item in baseRecettes[Recette].Listeingredients)
                {
                    if (item.Nom == Ingredient)
                    {
                        existant = true;
                    }
                }
                if (!existant)
                {
                    baseRecettes[Recette].Listeingredients.Add(newIngredient(Ingredient));

                    Console.WriteLine("Service| Add> Recette= " + Recette + ", Ingredient= " + Ingredient);
                    return "Ingredient " + Ingredient + "ajouté à la recette" + Recette;
                }
                return "L'ingredient" + Ingredient + " est déjà present dans la recette" + Recette;
            }
            return "La recette " + Recette + " n'existe pas";
        }

        public List<Recette> searchRecette(Ingredient ingr)
        {
            List<Recette> liste = new List<Recette>();


            foreach (Recette rec in baseRecettes.Values)
            {
                foreach (Ingredient ingred in rec.Listeingredients)
                {
                    if (ingred.Nom.Equals(ingr.Nom) && !liste.Contains(rec))
                    {
                        Console.WriteLine("La recette " + rec.Nom + " fait partie des recettes contenant l'ingrédient " + ingr.Nom);
                        liste.Add(rec);
                        selectionCour.Add(rec);
                    }
                }
            }

            return liste;
        }

        public bool isEmpty()
        {
            if (this.baseRecettes.Count != 0)
                return false;


            return true;
        }

        public string deletecourante(string nom)
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

        public Dictionary<string, Recette> listeBase()
        {
            return baseRecettes;
        }

    }
}
