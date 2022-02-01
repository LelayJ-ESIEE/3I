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
  // liste des Médecins
  public List<Medecin> getAllMedecins();
  // liste des créneaux horaires d'un médecin
  public List<Creneau> getAllCreneaux(Medecin medecin);
  // liste des Rv d'un médecin, un jour donné
  public List<Rv> getRvMedecinJour(Medecin medecin, Date jour);
  // trouver un client identifié par son id
  public Client getClientById(Long id);
  // trouver un client idenbtifié par son id
  public Medecin getMedecinById(Long id);
  // trouver un Rv identifié par son id
  public Rv getRvById(Long id);
  // trouver un créneau horaire identifié par son id
  public Creneau getCreneauById(Long id);
  // ajouter un RV
  public Rv ajouterRv(Date jour, Creneau creneau, Client client);
  // supprimer un RV
  public void supprimerRv(Rv rv);
  // fermeture du dao
  public void close();
}
