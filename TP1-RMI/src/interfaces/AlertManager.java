package interfaces;

import java.rmi.Remote;
import java.rmi.RemoteException;

public interface AlertManager extends Remote{
	
	void printPositif(String nom, int nombrePatients)throws RemoteException;

	void printNegatif(String nom, int nombrePatients) throws RemoteException;  
}
