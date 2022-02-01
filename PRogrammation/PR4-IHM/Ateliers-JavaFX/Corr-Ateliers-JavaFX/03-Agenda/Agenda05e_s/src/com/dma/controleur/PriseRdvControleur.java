package com.dma.controleur;

import java.time.format.DateTimeFormatter;
import java.util.List;
import javafx.beans.binding.Bindings;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.Label;
import javafx.scene.layout.Pane;
import com.dma.modele.metier.Client;
import com.dma.modele.metier.CreneauMedecinJour;
import com.dma.modele.metier.Rv;
import com.dma.controleur.Mediateur.Contr;

public class PriseRdvControleur extends AbstractControleur {
	
	@FXML private Pane pane;
	@FXML private Label labelMedecin;
	@FXML private Label labelJour;
	@FXML private ChoiceBox<Client> choiceBoxPatients;
	@FXML private Button buttonPrendreRdv;
	@FXML private Button buttonAnnulerRdv;
	@FXML private Button boutonAnnuler;
	
	public PriseRdvControleur(){
		super(Contr.PRISERDV);
	}
	
	@FXML private void initialize() {
		// le nom du médecin est affiché
		labelMedecin.textProperty().bind(getModele().medecinProperty().asString());
	
		// le jour sélectionné est affiché
		DateTimeFormatter dtf = DateTimeFormatter.ofPattern("dd MMM yyyy");
		labelJour.textProperty().bind(Bindings.createStringBinding(() ->
		    dtf.format(getModele().jourProperty().getValue()), getModele().jourProperty())
		);
		
		actualiserPatients();
		
		buttonPrendreRdv.setOnAction(evt -> {
			Client patient = choiceBoxPatients.getValue();
			System.out.println(patient.getId()+" "+patient.getTitre()+" "+patient.getNom()+" "+patient.getPrenom());
			getService().ajouterRv(toDate(getModele().jourProperty().getValue()), getModele().creneauMedecinJourProperty().getValue().getCreneau(), patient);
			super.afficheRdvJour();
		});
		
		buttonAnnulerRdv.setOnAction(evt -> {
			Rv rv = getModele().creneauMedecinJourProperty().getValue().getRv();
			getService().supprimerRv(rv);
			super.afficheRdvJour();
		});
		
		boutonAnnuler.setOnAction(evt -> super.afficheRdvJour());
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
		
		CreneauMedecinJour creneauMedecinJour = getModele().creneauMedecinJourProperty().getValue();
		
		if(creneauMedecinJour.getRv() == null){
			choiceBoxPatients.setDisable(false);
			buttonAnnulerRdv.setDisable(true);
			buttonPrendreRdv.setDisable(false);
			
		}else{
			choiceBoxPatients.setDisable(true);
			buttonAnnulerRdv.setDisable(false);
			buttonPrendreRdv.setDisable(true);
			choiceBoxPatients.setValue(creneauMedecinJour.getRv().getClient());
		}
	}

	public Pane getPane() {
		return pane;
	}

}
