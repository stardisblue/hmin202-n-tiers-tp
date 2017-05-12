package interfaces;
import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.ArrayList;

public interface CabinetVeterinaire extends Remote {
	
	ArrayList<Animal> getAnimals() throws RemoteException;
	void setAnimals(ArrayList<Animal> lA) throws RemoteException;
	Animal searchAnimalByName(String nomAni) throws RemoteException;
	void addAnimal(String nom) throws RemoteException;
	void removeAnimal(String nom) throws RemoteException;
	void removeAlertManager(AlertManager alerte) throws RemoteException;
	void addAlertManager(AlertManager alerte) throws RemoteException;
}
