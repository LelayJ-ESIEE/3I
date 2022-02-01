package com.dma.controleur;

import java.time.LocalDate;
import java.util.List;
import com.dma.modele.metier.Medecin;
import com.dma.controleur.Mediateur.Contr;
import javafx.collections.FXCollections;
import javafx.collections.ObservableList;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.ChoiceBox;
import javafx.scene.control.DatePicker;
import javafx.scene.layout.Pane;

public class AgendaControleur extends AbstractControleur {

	@FXML private Pane pane;
	@FXML private ChoiceBox<Medecin> choiceBoxMedecins;
	@FXML private DatePicker datePicker;
	@FXML private Button buttonAgenda;

	public AgendaControleur() {
		super(Contr.AGENDA);
	}

	@FXML private void initialize() {
		List<Medecin> medecins = getService().getAllMedecins();
		ObservableList<Medecin> ol_medecins = FXCollections
				.observableArrayList(medecins);
		choiceBoxMedecins.setItems(ol_medecins);
		choiceBoxMedecins.setValue(ol_medecins.get(0));
		datePicker.setValue(LocalDate.now());

		// bindings
		getModele().medecinProperty().bind(
				choiceBoxMedecins.getSelectionModel().selectedItemProperty());
		getModele().jourProperty().bind(datePicker.valueProperty());

		// gestion d'évènements
		buttonAgenda.setOnAction(evt -> super.afficheRdvJour());
	}
	
	@Override
	public void actualiser(){
	}

	public Pane getPane() {
		return pane;
	}

}






