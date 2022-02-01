package com.dma.modele.dao;

import java.util.Date;
import java.util.List;
import com.dma.modele.metier.Client;
import com.dma.modele.metier.Creneau;
import com.dma.modele.metier.Medecin;
import com.dma.modele.metier.Rv;

public interface AgendaDao {
  // ajout creneau
  public Creneau ajoutCreneau(Creneau creneau);
  // ajout medecin
  public Client ajoutClient(Client client);
  //suppression client
  public boolean suppressionClient(Client client);
  // ajout medecin
  public Medecin ajoutMedecin(Medecin medecin);
  // liste des clients
  public List<Client> getAllClients();
  // liste des M�decins
  public List<Medecin> getAllMedecins();
  // liste des cr�neaux horaires d'un m�decin
  public List<Creneau> getAllCreneaux(Medecin medecin);
  // liste des Rv d'un m�decin, un jour donn�
  public List<Rv> getRvMedecinJour(Medecin medecin, Date jour);
  // trouver un client identifi� par son id
  public Client getClientById(Long id);
  // trouver un client idenbtifi� par son id
  public Medecin getMedecinById(Long id);
  // trouver un Rv identifi� par son id
  public Rv getRvById(Long id);
  // trouver un cr�neau horaire identifi� par son id
  public Creneau getCreneauById(Long id);
  // ajouter un RV
  public Rv ajouterRv(Date jour, Creneau creneau, Client client);
  // supprimer un RV
  public void supprimerRv(Rv rv);
  // fermeture du dao
  public void close();
}
