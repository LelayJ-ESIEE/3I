package com.dma.controleur;

import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextArea;
import javafx.scene.layout.Pane;
import com.dma.controleur.Mediateur.Contr;

public class NotesControleur extends AbstractControleur {
	
	@FXML private Pane pane;
	@FXML private Button boutonAccueil;
	@FXML private TextArea textAreaNotes;
	
	public NotesControleur(){
		super(Contr.NOTE);
	}
	
	@FXML private void initialize() {
		textAreaNotes.textProperty().bindBidirectional(getModele().notesProperty());
	
		boutonAccueil.setOnAction(evt -> {
			super.afficheAgenda();
		});
	}
	
	@Override
	public void actualiser(){	
	}

	public Pane getPane() {
		return pane;
	}

}
