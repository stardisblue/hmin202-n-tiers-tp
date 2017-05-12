package client;

import interfaces.CodeBasedAnimal;
import interfaces.AlertManager;
import interfaces.Animal;
import interfaces.CabinetVeterinaire;

import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;

public class Client {
    private Client() {
    }

    public static void main(String[] args) {

        String host = (args.length < 1) ? null : args[0];
        try {
            //Gestionnaire de sécurité
            System.setProperty("java.rmi.server.codebase", "file://./bin/");
            System.setProperty("java.security.policy", "security.policy");
            System.out.println("Mise en place du SecurityManager");
            if (System.getSecurityManager() == null) {
                System.setSecurityManager(new SecurityManager());
                System.out.println("SecurityManager établi.");
            }
            Registry registry = LocateRegistry.getRegistry(host);

            //Version 1
            /*Animal stub = (Animal) registry.lookup("Animal");
            DossierSuivi response = stub.getDossier();
			System.out.println("response: " + response.getInfo());
			stub.toAnimal();
			stub.setContenuDossier(" OKTAMER");
			System.out.println("nouveau dossier :" + stub.getContenuDossier());
			*/

            //Version 2
            CabinetVeterinaire stub = (CabinetVeterinaire) registry.lookup("CabinetVet");
            System.out.println("A la recherche de Pif ...");
            Animal a = stub.searchAnimalByName("Pif");
            System.out.println(a.display());

            CodeBasedAnimal test = (CodeBasedAnimal) registry.lookup("codebase");
            System.out.println(test.display());
            //Version 3
            //CabinetVeterinaire stub = (CabinetVeterinaire) registry.lookup("CabinetVet");

            //.1
            //ClassLoader classLoader = RMIClassLoader.getClassLoader("file:///auto_home/jramos/public_html/ProjetWebL3/-");
            //Class loadedClass = classLoader.loadClass("codebase.class");
            //System.out.println("loadedCLass : " + loadedClass.getName());

            //.2
            AlertManager alert = new AlertManagerClient(stub);
            stub.addAlertManager(alert);
            stub.addAnimal("Splaf");
            stub.addAnimal("Splouf");
            stub.removeAnimal("Paf");
            stub.removeAlertManager(alert);

        } catch (Exception e) {
            System.err.println("Client exception: " + e.toString());
            e.printStackTrace();
        }
    }
}
