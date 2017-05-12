package server;

import java.rmi.RemoteException;

public class Hamster extends Animal {
    public Hamster(String nom, String maitre, String race) throws RemoteException {
        super(nom, maitre, race);
        this.setEspece("Hamster");
    }

    public Hamster(String nom) throws RemoteException {
        super(nom);
        this.setEspece("Hamster");
    }
}
