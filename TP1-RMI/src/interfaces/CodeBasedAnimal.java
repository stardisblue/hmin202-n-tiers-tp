package interfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface CodeBasedAnimal extends Remote {
    String getNom() throws RemoteException;

    void setNom(String name) throws RemoteException;

    String getMaitre() throws RemoteException;

    void setMaitre(String maitre) throws RemoteException;

    String getEspece() throws RemoteException;

    void setEspece(String espece) throws RemoteException;

    String getContenuDossier() throws RemoteException;

    void setContenuDossier(String info) throws RemoteException;

    String getRace() throws RemoteException;

    void setRace(String race) throws RemoteException;

    DossierSuivi getDossier() throws RemoteException;

    String display() throws RemoteException;
}
