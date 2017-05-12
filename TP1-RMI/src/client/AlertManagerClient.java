package client;

import interfaces.AlertManager;
import interfaces.CabinetVeterinaire;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;

public class AlertManagerClient extends UnicastRemoteObject implements AlertManager {

    //private static final long serialVersionUID = 1L;
    private CabinetVeterinaire cabinetVeterinaire;

    public AlertManagerClient(CabinetVeterinaire cabinet) throws RemoteException {
        this.cabinetVeterinaire = cabinet;
    }

    public void printPositif(String nom, int nombrePatients) throws RemoteException {
        String printed = "Vous venez d'ajouter le";
        printed += comptage(nombrePatients);
        printed += " animal de nom : " + nom;
        System.out.println(printed);

    }

    private String comptage(int nombrePatients) {
        switch (nombrePatients) {
            case 1:
                return "premier";
            case 2:
                return "deuxieme";
            default:
                return nombrePatients + "ieme";
        }
    }

    public void printNegatif(String nom, int nombrePatients) throws RemoteException {
        String printed = "Vous venez de perdre le";
        printed = printed + comptage(nombrePatients);
        printed += " animal de nom : " + nom;
        System.out.println(printed);
    }

}