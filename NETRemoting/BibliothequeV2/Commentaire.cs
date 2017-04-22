using System;
using System.Collections.Generic;
using System.Text;

namespace BibliothequeV2 
{
    class Commentaire : MarshalByRefObject
    {
        Client client;
        string commentaire;

        public Commentaire(Client c, string com)
        {
            this.client = c;
            this.commentaire = com;
        }

        public override string ToString()
        {
            return client.GetId() + " : " + commentaire;
        }

    }
}
