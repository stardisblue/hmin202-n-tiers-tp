package server;

import interfaces.Animal;
import interfaces.DossierSuivi;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class DefaultDossierSuivi extends UnicastRemoteObject implements DossierSuivi {
    private String infoDossier;

    public DefaultDossierSuivi(Animal animal) throws RemoteException {
        infoDossier = animal.toString();
    }

    public String getInfo() throws RemoteException {
        return infoDossier;
    }

    public void setInfo(String info) throws RemoteException {
        infoDossier += info;
    }

    public String toString() {
        return infoDossier;
    }

}
