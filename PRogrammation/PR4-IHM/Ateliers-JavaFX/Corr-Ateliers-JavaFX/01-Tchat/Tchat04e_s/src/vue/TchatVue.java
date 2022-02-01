package vue;

import modele.TchatModele;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Alert;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.ListView;
import javafx.scene.control.PasswordField;
import javafx.scene.control.RadioButton;
import javafx.scene.control.ScrollPane;
import javafx.scene.control.TextField;
import javafx.scene.control.ToggleGroup;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.GridPane;
import javafx.scene.layout.HBox;
import javafx.scene.layout.VBox;
import javafx.scene.paint.Color;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;

public class TchatVue {
	private static final int SCENE_WIDTH = 600;
	private static final int SCENE_HEIGHT = 500;
	
	private Scene scene;
	private TchatModele modele;
	
	// panneau de login
	private GridPane gp_login;
	private Button btn_login_valider;
	private Button btn_login_annuler;
	private Button btn_login_compte;
	private TextField tf_pseudo;
	private PasswordField pf_mdp;
	private Text erreur_login;
	
	//panneau de création de compte
	private GridPane gp_compte;
	private Button btn_compte_valider;
	private Button btn_compte_annuler;
	private TextField tf_pseudo2;
	private PasswordField pf_mdp2;
	private RadioButton rb_sexeM;
	private TextField tf_nom;
	private TextField tf_prenom;
	private TextField tf_naissance;
	
	//panneau des tchatteurs
	private BorderPane bp_tchatteurs;
	private ListView<String> lv_tchatteurs;
	private Button btn_tchatter;
	
	public TchatVue(TchatModele modele) {
		this.modele=modele;
		try {
			creerPanneauLogin();
			creerPanneauCompte();
			creerPanneauTchatteurs();
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
        gp_login.setAlignment(Pos.CENTER);
        gp_login.setHgap(10);
        gp_login.setVgap(10);
        gp_login.setPadding(new Insets(15, 15, 15, 15));

		Text titre = new Text("Bienvenue sur le Tchat JavaFX");
		titre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
		gp_login.add(titre, 0, 0, 2, 1);

		Label label_pseudo = new Label("Pseudo:");
		gp_login.add(label_pseudo, 0, 2);

		tf_pseudo = new TextField();
		gp_login.add(tf_pseudo, 1, 2);

		Label label_mdp = new Label("Mot de passe:");
		gp_login.add(label_mdp, 0, 3);

		pf_mdp = new PasswordField();
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
		
        erreur_login = new Text("Echec de l'authentification");
        erreur_login.setFont(Font.font("Tahoma", FontWeight.NORMAL, 16));
        erreur_login.setFill(Color.RED);
        gp_login.add(erreur_login, 0, 4, 2, 1);
        erreur_login.setVisible(false);
		
	}
	
	/********************************************************/
	/************* Panneau de création de compte ************/
	/********************************************************/	
	private void creerPanneauCompte(){

		gp_compte = new GridPane();
		gp_compte.setAlignment(Pos.CENTER);
		gp_compte.setHgap(10);
		gp_compte.setVgap(10);
		gp_compte.setPadding(new Insets(25, 25, 25, 25));
	
		Text titre = new Text("Création d'un compte");
		titre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
		gp_compte.add(titre, 0, 0, 2, 1);
	
		Label label_pseudo = new Label("Pseudo:");
		gp_compte.add(label_pseudo, 0, 2);
	
		tf_pseudo2 = new TextField();
		gp_compte.add(tf_pseudo2, 1, 2);
	
		Label label_mdp = new Label("Mot de passe:");
		gp_compte.add(label_mdp, 0, 3);
	
		pf_mdp2 = new PasswordField();
		gp_compte.add(pf_mdp2, 1, 3);
	
		Label label_sexe = new Label("Sexe:");
		gp_compte.add(label_sexe, 0, 4);
	
		ToggleGroup sexe_group = new ToggleGroup();
		rb_sexeM = new RadioButton("M");
		rb_sexeM.setToggleGroup(sexe_group);
		rb_sexeM.setSelected(true);
		RadioButton rb_sexeF = new RadioButton("F");
		rb_sexeF.setToggleGroup(sexe_group);
	
		HBox hb_compte_rb = new HBox(10);
		hb_compte_rb.setAlignment(Pos.BOTTOM_LEFT);
		hb_compte_rb.getChildren().add(rb_sexeM);
		hb_compte_rb.getChildren().add(rb_sexeF);
		gp_compte.add(hb_compte_rb, 1, 4);
	
		Label label_nom = new Label("Nom:");
		gp_compte.add(label_nom, 0, 5);
	
		tf_nom = new TextField();
		gp_compte.add(tf_nom, 1, 5);
	
		Label label_prenom = new Label("Prénom:");
		gp_compte.add(label_prenom, 0, 6);
	
		tf_prenom = new TextField();
		gp_compte.add(tf_prenom, 1, 6);
	
		Label label_naissance = new Label("Date de naissance (dd/MM/AAAA):");
		gp_compte.add(label_naissance, 0, 7);
	
		tf_naissance = new TextField();
		gp_compte.add(tf_naissance, 1, 7);
	
		btn_compte_valider = new Button("Valider");
	
		btn_compte_annuler = new Button("Annuler");
	
		HBox hb_compte_btn = new HBox(10);
		hb_compte_btn.setAlignment(Pos.BOTTOM_CENTER);
		hb_compte_btn.getChildren().add(btn_compte_valider);
		hb_compte_btn.getChildren().add(btn_compte_annuler);
		gp_compte.add(hb_compte_btn, 1, 8);
		
	}
	

	/********************************************************/
	/********** Panneau d'affichage des tchatteurs **********/
	/********************************************************/	
	private void creerPanneauTchatteurs(){

		bp_tchatteurs = new BorderPane();
	
		Text bp_titre = new Text("Tchatteurs connectés");
		bp_titre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		bp_tchatteurs.setTop(bp_titre);
		
		lv_tchatteurs = new ListView<>(modele.getConnectes());
		lv_tchatteurs.getSelectionModel().select(0);
	
		ScrollPane sp_tchatteurs = new ScrollPane();
		sp_tchatteurs.setContent(lv_tchatteurs);
		bp_tchatteurs.setLeft(sp_tchatteurs);
	
		btn_tchatter = new Button("Tchatter");
		bp_tchatteurs.setCenter(btn_tchatter);
		
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
	
    public void showLogin(){
    	tf_pseudo.setText("");
    	pf_mdp.setText("");
    	erreur_login.setVisible(false);
    	scene.setRoot(gp_login);
    }
    
    public void showCompte(){
    	scene.setRoot(gp_compte);
    }
    
	public void showErreurAuth(){
		getTf_pseudo().setText("");
		getPf_mdp().setText("");
		erreur_login.setVisible(true);
	}
	
	public void showErreurCompte(){
		new Alert(AlertType.ERROR,"pseudo déjà utilisé !").showAndWait();
	}
	
	public void showTchatteurs(){
		scene.setRoot(bp_tchatteurs);
	}
    
	public Button getBtn_login_valider(){
		return btn_login_valider;
	}
	
	public Button getBtn_login_annuler(){
		return btn_login_annuler;
	}
	
	public Text getErreur_login(){
		return erreur_login;
	}
	
	public Button getBtn_login_compte(){	
		return btn_login_compte;
	}
	
	public TextField getTf_pseudo2() {
		return tf_pseudo2;
	}

	public PasswordField getPf_mdp2() {
		return pf_mdp2;
	}

	public RadioButton getRb_sexeM() {
		return rb_sexeM;
	}

	public TextField getTf_nom() {
		return tf_nom;
	}

	public TextField getTf_prenom() {
		return tf_prenom;
	}

	public TextField getTf_naissance() {
		return tf_naissance;
	}
	
	public Button getBtn_compte_valider(){
		return btn_compte_valider;
	}
	
	public Button getBtn_compte_annuler(){
		return btn_compte_annuler;
	}
	
	public TextField getTf_pseudo(){		
		return tf_pseudo;
	}
	
	public PasswordField getPf_mdp(){		
		return pf_mdp;
	}
	
	public ListView<String> getLv_tchatteurs(){
		return lv_tchatteurs;
	}
	
	public Button getBtn_tchatter(){
		return btn_tchatter;
	}
}


