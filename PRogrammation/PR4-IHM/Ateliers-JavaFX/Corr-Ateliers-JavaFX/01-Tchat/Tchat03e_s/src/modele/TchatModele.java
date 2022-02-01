package modele;

import java.util.HashMap;
import java.util.Map;

public class TchatModele {
	private Map<String, User> utilisateurs = new HashMap<String, User>();
	
	private User tchatteur;

	
	public TchatModele(){
		init();
	}
	
	private void init(){
		User[] users = {
			new User("Romeo75", "Romeo75", true, "LEMAIRE", "Julien", "23/04/1992"),
			new User("Julie987", "Julie987", false, "MARTIN", "Julie", "04/11/1985"),
			new User("Gaston34", "Gaston34", true, "DUPONT", "Nicolas", "16/05/1991"),
			new User("Marion62", "Marion62", false, "LEGOFF", "Marion", "20/08/1989"),
			new User("Sophie17", "Sophie17", false, "LEGALL", "Sophie", "06/06/1993")
		};
		for(User user: users) {
			utilisateurs.put(user.getPseudo(), user);
		}
	}
	
	public User authentifier(String pseudo, String motDePasse) {
		System.out.println("authentifier "+pseudo+" "+ motDePasse);
		User user = utilisateurs.get(pseudo);
		if (user != null && user.getMotDePasse().equals(motDePasse.trim())) {
			return user;
		} else {
			return null;
		}
	}
	
	public boolean ajout(User user){
		if(utilisateurs.get(user.getPseudo()) != null){
			System.out.println("pseudo " + user.getPseudo() + " déjà utilisé");
			return false;
		}else {
			utilisateurs.put(user.getPseudo(), user);
			System.out.println("user " + user + " ajouté");
			return true;
		}
	}

	public Map<String, User> getUtilisateurs() {
		return utilisateurs;
	}

	public void setUtilisateurs(Map<String, User> utilisateurs) {
		this.utilisateurs = utilisateurs;
	}

	public User getTchatteur() {
		return tchatteur;
	}

	public void setTchatteur(User tchatteur) {
		this.tchatteur = tchatteur;
	}

}
