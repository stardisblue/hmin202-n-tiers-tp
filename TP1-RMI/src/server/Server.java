package server;

import interfaces.Animal;
import codebase.CodeBasedChien;

import java.rmi.RemoteException;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
import java.util.ArrayList;

public class Server {

    public static void main(String args[]) throws RemoteException {

        DefaultCabinetVeterinaire cabinet = new DefaultCabinetVeterinaire();

        try {
            //Gestionnaire de sécurité
            /*SecurityManager security = System.getSecurityManager();
            if (security != null) {
		         security.checkPermission(null);
		         System.setProperty( "java.rmi.server.codebase", "http://mycomputer/arch.jar" );
		    }*/
            System.setProperty("java.rmi.server.codebase", "file://./bin/");

            System.setProperty("java.security.policy", "security.policy");
            System.out.println("Mise en place du SecurityManager");
            if (System.getSecurityManager() == null) {
                System.setSecurityManager(new SecurityManager());
                System.out.println("SecurityManager établi.");
            }

            ArrayList<Animal> animals = new ArrayList<>();
            Chien chien1 = new Chien("Pif", "Jeffou", "Rottweiller");
            Chien chien2 = new Chien("Paf", "lebonpseudo", "Caniche");
            animals.add(chien1);
            animals.add(chien2);
            cabinet.setAnimals(animals); //Remplissage du cabinet

			/*
             * CreateRegistry = sans ligne de commande pour lancer Rmiregistry
			 * GetRegistry = lancement de rmiregistry en ligne de commande
			 */
            Registry registry = LocateRegistry.createRegistry(1099);
            //Registry registry = LocateRegistry.getRegistry();

            registry.bind("CabinetVet", cabinet);
            registry.bind("codebase", new CodeBasedChien("medor"));
            System.err.println("Server ready");
        } catch (Exception e) {
            System.err.println("Server exception: " + e.toString());
            e.printStackTrace();
        }
    }
}