package server;

import java.rmi.RemoteException;

public class Chien extends Animal {

    public Chien(String nom, String maitre, String race) throws RemoteException {
        super(nom, maitre, race);
        this.setEspece("Chien");
        this.setDureeVie(20);
    }

    public Chien(String nom) throws RemoteException {
        super(nom);
        this.setEspece("Chien");
        this.setDureeVie(20);
    }
}
