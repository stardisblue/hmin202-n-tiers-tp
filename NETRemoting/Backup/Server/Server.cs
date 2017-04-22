using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

namespace Bibliotheque
{
    class Server
    {
        static void Main(string[] args)
        {           

            //Lancement du serveur
            TcpChannel chan1 = new TcpChannel(8089);
            ChannelServices.RegisterChannel(chan1, true);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(BibliothequeServer), "Bibliotheque", WellKnownObjectMode.Singleton);
            System.Console.WriteLine("Appuyez sur <entre> pour sortir...");

            

            System.Console.ReadLine();
        }
    }

}
