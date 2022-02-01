package com.dma.controleur;

import com.dma.modele.metier.Client;
import com.dma.controleur.Mediateur.Contr;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.RadioButton;
import javafx.scene.control.TextField;
import javafx.scene.control.ToggleGroup;
import javafx.scene.layout.Pane;

public class AjoutPatientControleur extends AbstractControleur {

	@FXML private Pane pane;
	@FXML private RadioButton radioButtonMme;
	@FXML private RadioButton radioButtonM;
	@FXML private TextField textfieldNom;
	@FXML private TextField textfieldPrenom;
	@FXML private Button boutonAjouter;
	@FXML private Button boutonAnnuler;

	public AjoutPatientControleur() {
		super(Contr.AJOUTPATIENT);
	}

	@FXML private void initialize() {
		ToggleGroup group = new ToggleGroup();
		radioButtonMme.setToggleGroup(group);
		radioButtonM.setToggleGroup(group);
		radioButtonMme.setSelected(true);
		
		// gestion d'évènements
		boutonAjouter.setOnAction(evt -> {			
			Client client = getModele().creerClient(radioButtonMme.isSelected(), textfieldNom.getText().trim(),textfieldPrenom.getText().trim());
			getService().ajoutClient(client);
			super.afficheAgenda();
		});
		boutonAnnuler.setOnAction(evt -> super.afficheAgenda());
	}
	
	@Override
	public void actualiser(){}

	public Pane getPane() {
		return pane;
	}

}
