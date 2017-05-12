package codebase;

import interfaces.CodeBasedAnimal;
import interfaces.DossierSuivi;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class CodeBaseDossierSuivi extends UnicastRemoteObject implements DossierSuivi {
    private String infoDossier;

    public CodeBaseDossierSuivi(CodeBasedAnimal animal) throws RemoteException {
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
