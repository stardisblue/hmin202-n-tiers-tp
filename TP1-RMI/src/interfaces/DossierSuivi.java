package interfaces;

import java.rmi.RemoteException;

public interface DossierSuivi {
    String getInfo() throws RemoteException;

    void setInfo(String info) throws RemoteException;
}
