package com.dma.modele.dao;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.EntityTransaction;
import javax.persistence.Persistence;
import javax.persistence.Query;

import com.dma.modele.metier.Client;
import com.dma.modele.metier.Creneau;
import com.dma.modele.metier.Medecin;
import com.dma.modele.metier.Rv;

public class JpaAgendaDao implements AgendaDao {
	protected EntityManagerFactory factory;

	public JpaAgendaDao() {
		factory = Persistence.createEntityManagerFactory("medecins");
	}
	
	public void close(){
		if(factory != null){
			factory.close();
		}
		factory = null;
	}

	public Creneau ajoutCreneau(Creneau creneau){
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			entityManager.persist(creneau);
					
			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			e.printStackTrace();
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return creneau;		
	}
	
	public Client ajoutClient(Client client){
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			entityManager.persist(client);
					
			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			e.printStackTrace();
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return client;		
	}
	
	@SuppressWarnings("unchecked")
	public boolean suppressionClient(Client client){
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		boolean suppr=false;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();
			
			client = (Client) entityManager.find(Client.class, client.getId());
			if(client != null){
				// recherche des rendez-vous de ce client
				Query query = entityManager.createQuery("select r from Rv r where r.client = :client");
				query.setParameter("client", client);
				List<Rv> rdv = query.getResultList();
				for(Rv rv : rdv){
					System.out.println(rv);
					rv.setClient(null);
					entityManager.remove(rv);
				}	
				entityManager.remove(client);
				suppr = true;
			}
					
			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			e.printStackTrace();
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return suppr;			
	}
	
	public Medecin ajoutMedecin(Medecin medecin){
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			entityManager.persist(medecin);
					
			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return medecin;		
	}

	// liste des clients
	@SuppressWarnings("unchecked")
	public List<Client> getAllClients() {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		List<Client> liste = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			liste = entityManager.createQuery("select rc from Client rc")
					.getResultList();

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return liste;
	}

	// liste des m�decins
	@SuppressWarnings("unchecked")
	public List<Medecin> getAllMedecins() {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		List<Medecin> liste = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			liste = entityManager.createQuery("select rm from Medecin rm")
					.getResultList();

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return liste;
	}

	// liste des cr�neaux horaires d'un m�decin donn�
	// medecin : le m�decin
	@SuppressWarnings("unchecked")
	public List<Creneau> getAllCreneaux(Medecin medecin) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		List<Creneau> liste = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			liste = entityManager
					.createQuery(
							"select rc from Creneau rc join rc.medecin m where m.id=:idMedecin")
					.setParameter("idMedecin", medecin.getId()).getResultList();

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return liste;
	}

	// liste des Rv d'un m�decin donn�, un jour donn�
	// medecin : le m�decin
	// jour : le jour
	@SuppressWarnings("unchecked")
	public List<Rv> getRvMedecinJour(Medecin medecin, Date jour) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		List<Rv> liste = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			liste = entityManager
					.createQuery(
							"select rv from Rv rv join rv.creneau c join c.medecin m where m.id=:idMedecin and rv.jour=:jour")
					.setParameter("idMedecin", medecin.getId())
					.setParameter("jour", jour).getResultList();

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return liste;
	}

	// ajout d'un Rv
	// jour : jour du Rv
	// creneau : cr�neau horaire du Rv
	// client : client pour lequel est pris le Rv
	public Rv ajouterRv(Date jour, Creneau creneau, Client client) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		Rv rv = new Rv(null, jour);
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			rv = new Rv(null, jour);
			rv.setClient(client);
			rv.setCreneau(creneau);
			entityManager.persist(rv);

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return rv;
	}

	// suppression d'un Rv
	// rv : le Rv supprim�
	public void supprimerRv(Rv rv) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			entityManager.remove(entityManager.merge(rv));

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
	}

	// r�cup�rer un client donn�
	public Client getClientById(Long id) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		Client client = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			client = (Client) entityManager.find(Client.class, id);

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return client;
	}

	// r�cup�rer un m�decin donn�
	public Medecin getMedecinById(Long id) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		Medecin medecin = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			medecin = (Medecin) entityManager.find(Medecin.class, id);

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return medecin;
	}

	// r�cup�rer un Rv donn�
	public Rv getRvById(Long id) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		Rv rv = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			rv = (Rv) entityManager.find(Rv.class, id);

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return rv;
	}

	// r�cup�rer un cr�neau donn�
	public Creneau getCreneauById(Long id) {
		EntityManager entityManager = null;
		EntityTransaction tx = null;
		Creneau creneau = null;
		try {
			entityManager = factory.createEntityManager();
			tx = entityManager.getTransaction();
			tx.begin();

			creneau = (Creneau) entityManager.find(Creneau.class, id);

			tx.commit();
		} catch (RuntimeException e) {
			try {
				if (tx != null) {
					tx.rollback();
				}
			} catch (RuntimeException rtex) {
				System.err.println("rollback de la transaction impossible !");
			}
			throw new AgendaException(e.getMessage());
		} finally {
			if (entityManager != null) {
				entityManager.close();
			}
		}
		return creneau;
	}
}
