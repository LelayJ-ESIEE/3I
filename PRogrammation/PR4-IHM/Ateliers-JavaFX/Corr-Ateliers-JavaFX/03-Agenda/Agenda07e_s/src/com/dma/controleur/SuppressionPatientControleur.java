package com.dma.controleur;

import java.util.List;
import java.util.Optional;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Alert.AlertType;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.layout.Pane;
import com.dma.modele.metier.Client;
import com.dma.controleur.Mediateur.Contr;
import javafx.scene.control.Alert;
import javafx.scene.control.ButtonType;

public class SuppressionPatientControleur extends AbstractControleur {
	
	@FXML private Pane pane;
	@FXML private ChoiceBox<Client> choiceBoxPatients;
	@FXML private Button boutonSupprimer;
	@FXML private Button boutonAnnuler;
	
	public SuppressionPatientControleur(){
		super(Contr.SUPPRESSIONPATIENT);
	}
	
	@FXML private void initialize() {
		actualiserPatients();
		
		boutonSupprimer.setOnAction(evt -> {
			Client patient = choiceBoxPatients.getValue();
			Alert alert = new Alert(AlertType.CONFIRMATION);
			alert.setResizable(true);
			alert.getDialogPane().setPrefSize(500, 200);
			alert.setTitle("Suppression d'un patient");
			alert.setHeaderText("Suppression d'un patient");
			alert.setContentText("Confirmez-vous la suppression de " + patient.getTitre()+" "+patient.getNom()+" "+patient.getPrenom() + " ?");

			Optional<ButtonType> result = alert.showAndWait();
			if ((result.isPresent()) && (result.get() == ButtonType.OK)){
				getService().suppressionClient(patient);
				super.afficheAgenda();
			} else {
				super.afficheAgenda();
			}
			
		});
		
		boutonAnnuler.setOnAction(evt -> super.afficheAgenda());
	}
	
	private void actualiserPatients(){
		List<Client> patients = getService().getAllClients();
		ObservableList<Client> ol_patients = FXCollections.observableArrayList(patients);
		choiceBoxPatients.setItems(ol_patients);
		choiceBoxPatients.setValue(ol_patients.get(0));
	}
	
	@Override
	public void actualiser(){	
		actualiserPatients();	
	}

	public Pane getPane() {
		return pane;
	}

}
