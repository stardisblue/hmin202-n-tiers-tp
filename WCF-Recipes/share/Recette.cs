using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace share
{
    public class Recette
    {
        String nom;
        List<Ingredient> listeingredients = new List<Ingredient>();

        [DataMember]
        public String Nom
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
