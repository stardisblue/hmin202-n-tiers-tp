using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using share;
using ServiceRecettes;
using System.ServiceModel;

namespace HebergementService
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost serviceHost = new ServiceHost(typeof(ServiceRecette)))
            {
                try
                {
                    // ouverture de service host et début de l'attente d'appel .
                    serviceHost.Open();
                    Console.WriteLine("Le service est opérationnel.");
                    Console.WriteLine("Appuyer sur <ENTER> afin de mettre fin au service.");

                    Console.ReadLine();
                    // fermeture de service host
                    serviceHost.Close();
                }
                catch (TimeoutException timeProblem)
                {
                    Console.WriteLine(timeProblem.Message);
                    Console.ReadLine();
                }
                catch (CommunicationException commProblem)
                {
                    Console.WriteLine(commProblem.Message);
                    Console.ReadLine();
                }
            }
        }
    }
}
