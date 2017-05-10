using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using Bibliotheque;


namespace Bibiliotheque
{
    class Client
    {
        public bool init = false;
        public static Thread thread1 = null;
        public static Thread thread2 = null;

        public static int Main(string[] args)
        {
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan, true);

            Console.WriteLine("Je suis un client");
            BibliothequeServer obj = (BibliothequeServer)Activator.GetObject(typeof(BibliothequeServer), "tcp://localhost:8089/Bibliotheque");
            obj.loadBiblio();
            Console.WriteLine(obj.chercherParAuteur("J.K Rowlling"));


            /*
            Client c = new Client();
            thread1 = new Thread(new ThreadStart(c.RunMe));
            thread2 = new Thread(new ThreadStart(c.RunMe));
            thread1.Start();
            thread2.Start();
            */
            Console.Read();
            return 0;
        }


        public void RunMe()
        {

            if (Thread.CurrentThread == thread1)
            {

                Console.WriteLine("Ceci est le thread un");
                BibliothequeServer obj = (BibliothequeServer)Activator.GetObject(typeof(BibliothequeServer), "tcp://localhost:8089/Bibliotheque");
                    Console.WriteLine(obj.toString() + " -  partir du thread 1 ");
                    Thread.Sleep(0);
            }
            else if (Thread.CurrentThread == thread2)
            {
                // TcpChannel chan = new TcpChannel();
                //ChannelServices.RegisterChannel(chan, true);
                Console.WriteLine("Ceci est le thread deux");
                BibliothequeServer obj = (BibliothequeServer)Activator.GetObject(typeof(BibliothequeServer), "tcp://localhost:8089/Bibliotheque");

                Console.WriteLine(obj.toString() + " -  partir du thread 2 ");
                    Thread.Sleep(0);
            }
        }
    }
}