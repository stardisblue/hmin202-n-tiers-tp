using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace share
{
    [DataContract]
    public class Ingredient
    {
        String nom;

        [DataMember]
        public String Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
