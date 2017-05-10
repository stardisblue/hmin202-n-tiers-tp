using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BibliothequeV2;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;
using System.Collections;

namespace Bibliotheque
{
    class Server
    {
        static void Main(string[] args)
        {

            BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
            provider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            // Creating the IDictionary to set the port on the channel instance.
            IDictionary props = new Hashtable();
            props["port"] = 8089;
            // Pass the properties for the port setting and the server provider in the server chain argument. (Client remains null here.)
            TcpChannel chan1 = new TcpChannel(props, null, provider);
            
            //Lancement du serveur
            ChannelServices.RegisterChannel(chan1, true);
            
            //TcpChannel chan1 = new TcpChannel(8089);
            //ChannelServices.RegisterChannel(chan1, true);
            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(BibliothequeServer), "Bibliotheque", WellKnownObjectMode.Singleton);
            BibliothequeServer obj = (BibliothequeServer)Activator.GetObject(typeof(BibliothequeServer), "tcp://localhost:8089/Bibliotheque");
            // Chargement de la bibliotheque
            obj.LoadBiblio();
            Console.WriteLine("Biblio Chargée");

            System.Console.WriteLine("Appuyez sur <entre> pour sortir...");
            System.Console.ReadLine();
        }
    }

}
