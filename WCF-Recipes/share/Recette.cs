using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace share
{
    public class Recette
    {
        string nom;
        List<Ingredient> listeingredients = new List<Ingredient>();

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

        [DataMember]
        public List<Ingredient> Listeingredients
        {
            get { return listeingredients; }
            set { listeingredients = value; }
        }

    }
}
