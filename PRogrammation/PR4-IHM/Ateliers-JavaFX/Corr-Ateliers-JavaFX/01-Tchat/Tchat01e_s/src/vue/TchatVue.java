package vue;

import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.PasswordField;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;

public class TchatVue {
	private static final int SCENE_WIDTH = 600;
	private static final int SCENE_HEIGHT = 500;
	
	private Scene scene;
	
	private GridPane gp_login;

	private Button btn_login_valider;
	private Button btn_login_annuler;
	private Button btn_login_compte;
	
	public TchatVue() {
	
		try {
			creerPanneauLogin();	
			creerScene();                    
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
	
	/********************************************************/
	/******************* Panneau de login *******************/
	/********************************************************/	
	private void creerPanneauLogin(){

		gp_login = new GridPane();		
		gp_login.setGridLinesVisible(true); // pour faire apparaître les contours des cellules
        
		gp_login.setAlignment(Pos.CENTER);
        gp_login.setHgap(10);
        gp_login.setVgap(10);
        gp_login.setPadding(new Insets(15, 15, 15, 15));

		Text titre = new Text("Bienvenue sur le Tchat JavaFX");
		titre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
		gp_login.add(titre, 0, 0, 2, 1);

		Label label_pseudo = new Label("Pseudo:");
		gp_login.add(label_pseudo, 0, 2);

		TextField tf_pseudo = new TextField();
		gp_login.add(tf_pseudo, 1, 2);

		Label label_mdp = new Label("Mot de passe:");
		gp_login.add(label_mdp, 0, 3);

		PasswordField pf_mdp = new PasswordField();
		gp_login.add(pf_mdp, 1, 3);

		btn_login_valider = new Button("Valider");

		btn_login_annuler = new Button("Annuler Login");

		HBox hb_btn = new HBox(10);
		hb_btn.setAlignment(Pos.BOTTOM_CENTER);
		hb_btn.getChildren().add(btn_login_valider);
		hb_btn.getChildren().add(btn_login_annuler);
		gp_login.add(hb_btn, 1, 5);

		final Text compte = new Text("Je n'ai pas de compte");
		compte.setFont(Font.font("Tahoma", FontWeight.NORMAL, 16));

		btn_login_compte = new Button("Créer compte");

		VBox hb_compte = new VBox(10);
		hb_compte.setAlignment(Pos.BOTTOM_CENTER);
		hb_compte.getChildren().add(compte);
		hb_compte.getChildren().add(btn_login_compte);
		gp_login.add(hb_compte, 0, 7);
		
	}
	
	/********************************************************/
    /**************** Création de la Scene *****************/
    /********************************************************/  
	private void creerScene(){ 
		scene = new Scene(gp_login, SCENE_WIDTH, SCENE_HEIGHT); 
	    scene.getStylesheets().add
			(getClass().getResource("application.css").toExternalForm());
	}
	
	public Scene getScene(){
		return scene;
	}

}
