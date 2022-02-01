package application;

import modele.TchatModele;
import modele.User;
import vue.TchatVue;
import javafx.application.Application;
import javafx.stage.Stage;

public class Tchat extends Application {
	private TchatVue vue;
	private TchatModele modele;

	@Override
	public void init() {
		modele = new TchatModele();
	}

	@Override
	public void start(Stage primaryStage) {
		vue = new TchatVue(modele);

		primaryStage.setTitle("Tchat JavaFX");
		primaryStage.setScene(vue.getScene());
		primaryStage.show();
		
        
        /********************************************************/
        /***************** Gestion d'évènements *****************/
        /********************************************************/
        // pour effacer le message éventuel "Echec de l'authentification"
        vue.getTf_pseudo().setOnKeyTyped(event -> vue.getErreur_login().setVisible(false));
        
        vue.getBtn_login_valider().setOnAction(event -> 
					{ User tchatteur = modele.authentifier(
							vue.getTf_pseudo().getText(), 
							new String(vue.getPf_mdp().getText()));
					System.out.println();
		              if(tchatteur != null){
		                    System.out.println(tchatteur);
		               }else{
		        			// afficher message "echec de l'authentification"
							vue.showErreurAuth();
		                }
		            }
		);
		
		vue.getBtn_login_annuler().setOnAction(event -> vue.showLogin());
			
		vue.getBtn_login_compte().setOnAction(event -> vue.showCompte());
        
        vue.getBtn_compte_valider().setOnAction(event -> {
        	User user = new User(
        			vue.getTf_pseudo2().getText(),
        			vue.getPf_mdp2().getText(),
        			vue.getRb_sexeM().isSelected(),
        			vue.getTf_nom().getText(),
        			vue.getTf_prenom().getText(),
        			vue.getTf_naissance().getText());
        	if(user.valide()){
        		if(!modele.ajout(user)) {
        			// afficher message "pseudo déjà utilisé"
					vue.showErreurCompte();
        		}
        	}
        	vue.showLogin();
        });
        
        vue.getBtn_compte_annuler().setOnAction(event -> vue.showLogin());

	}

	public static void main(String[] args) {
		launch(args);
	}
}
