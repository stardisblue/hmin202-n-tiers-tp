using System;
using System.Collections.Generic;
using System.Text;

namespace BibliothequeV2
{
    public class Client : MarshalByRefObject
    {
        string id;
        string mdp;
        bool admin;
        
        public Client(string id, string mdp, bool a)
        {
            this.id = id;
            this.mdp = mdp;
            admin = a;
        }

        public string GetId()
        {
            return this.id;
        }

        public string Getmdp()
        {
            return mdp;
        }

        public bool isAdmin()
        {
            return admin;
        }
    }
}
