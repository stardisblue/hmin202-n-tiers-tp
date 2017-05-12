package server;

import interfaces.AlertManager;
import interfaces.CabinetVeterinaire;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.util.ArrayList;

public class DefaultCabinetVeterinaire extends UnicastRemoteObject implements CabinetVeterinaire {
    private ArrayList<interfaces.Animal> animals;
    private ArrayList<AlertManager> alertManagers = new ArrayList<>();

    public DefaultCabinetVeterinaire() throws RemoteException {
        super();
    }

    public DefaultCabinetVeterinaire(ArrayList<interfaces.Animal> animals) throws RemoteException {
        this.animals = animals;
    }

    public ArrayList<interfaces.Animal> getAnimals() throws RemoteException {
        return animals;
    }

    public void setAnimals(ArrayList<interfaces.Animal> animals) throws RemoteException {
        this.animals = animals;
    }

    public void addAnimal(String nom) throws RemoteException {
        Animal animal = new Animal(nom);
        animals.add(animal);
        for (AlertManager alert : alertManagers) {
            alert.printPositif(animal.getNom(), animals.size());
        }
    }

    public void removeAnimal(String nom) throws RemoteException {
        animals.remove(this.searchAnimalByName(nom));
    }

    public interfaces.Animal searchAnimalByName(String nom) throws RemoteException {
        interfaces.Animal animalTrouve = null;
        System.out.println(nom);

        for (interfaces.Animal a : animals) {
            if (a.getNom().equals(nom)) {
                animalTrouve = a;
            }
        }

        return animalTrouve;
    }

    public void removeAlertManager(AlertManager alert) throws RemoteException {
        this.alertManagers.remove(alert);
    }

    public void addAlertManager(AlertManager alert) throws RemoteException {
        this.alertManagers.add(alert);
    }
}
