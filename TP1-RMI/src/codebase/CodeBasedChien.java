package codebase;

import interfaces.CodeBasedAnimal;
import interfaces.DossierSuivi;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class CodeBasedChien extends UnicastRemoteObject implements CodeBasedAnimal {
    private int dureeVie = -1;
    private String nom = "";
    private String maitre = "";
    private String espece = "";
    private String race = "";
    private DossierSuivi dossier;

    public CodeBasedChien(String nom, String maitre, String race) throws RemoteException {
        this.nom = nom;
        this.maitre = maitre;
        this.race = race;
        this.espece = "Chien";
        this.dureeVie = 20;
        dossier = new CodeBaseDossierSuivi(this);
    }

    public CodeBasedChien(String nom) throws RemoteException {
        this.nom = nom;
        this.espece = "Chien";
        this.dureeVie = 20;
        dossier = new CodeBaseDossierSuivi(this);
    }

    public String getNom() throws RemoteException {
        return nom;
    }

    public void setNom(String name) throws RemoteException {
        this.nom = name;
    }

    public String getMaitre() throws RemoteException {
        return maitre;
    }

    public void setMaitre(String maitre) throws RemoteException {
        this.maitre = maitre;
    }

    public String getEspece() throws RemoteException {
        return espece;
    }

    public void setEspece(String espece) throws RemoteException {
        this.espece = espece;
    }

    public String getRace() throws RemoteException {
        return race;
    }

    public void setRace(String race) throws RemoteException {
        this.race = race;
    }

    public DossierSuivi getDossier() throws RemoteException {
        return dossier;
    }

    public String getContenuDossier() throws RemoteException {
        return dossier.getInfo();
    }

    public void setContenuDossier(String newInfo) throws RemoteException {
        dossier.setInfo(newInfo);
    }

    public String display() throws RemoteException {
        return "[" + espece + "]" + nom + "(" + race + ")[" + maitre + "](" + dureeVie + "pv)";
    }

}
