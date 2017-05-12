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
        string nom;

        [DataMember]
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }

    }
}
