package application;

import vue.TchatVue;
import javafx.application.Application;
import javafx.stage.Stage;

public class Tchat extends Application {
	private TchatVue vue;

	@Override
	public void init() {
	}

	@Override
	public void start(Stage primaryStage) {
		vue = new TchatVue();

		primaryStage.setTitle("Tchat JavaFX");
		primaryStage.setScene(vue.getScene());
		primaryStage.show();
		
        
        /********************************************************/
        /***************** Gestion d'évènements *****************/
        /********************************************************/
       
        vue.getBtn_login_compte().setOnAction(event -> vue.showCompte());
        
        vue.getBtn_compte_valider().setOnAction(event -> vue.showLogin());
        
        vue.getBtn_compte_annuler().setOnAction(event -> vue.showLogin());

	}

	public static void main(String[] args) {
		launch(args);
	}
}
