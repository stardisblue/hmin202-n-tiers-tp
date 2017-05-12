package server;

import java.rmi.RemoteException;

public class Chat extends Animal {
    public Chat(String nom, String maitre, String race) throws RemoteException {
        super(nom, maitre, race);
        this.setEspece("Chat");
        this.setDureeVie(15);

    }

    public Chat(String nom) throws RemoteException {
        super(nom);
        this.setEspece("Chat");
        this.setDureeVie(20);
    }
}
