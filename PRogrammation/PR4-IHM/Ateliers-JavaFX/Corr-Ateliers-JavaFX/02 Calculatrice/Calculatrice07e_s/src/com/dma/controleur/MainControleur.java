package com.dma.controleur;

import com.dma.controleur.Mediateur.Contr;
import javafx.fxml.FXML;
import javafx.scene.control.MenuItem;
import javafx.scene.layout.BorderPane;

public class MainControleur extends AbstractControleur {
		
		@FXML private BorderPane mainBorderPane;
		
		// Menu Format
		@FXML private MenuItem m_standard;
		@FXML private MenuItem m_scientifique;
		@FXML private MenuItem m_quitter;
		
		// Menu Aide
		@FXML private MenuItem m_aidecalculatrice;
		@FXML private MenuItem m_apropos;				
		
		public MainControleur(){
			super(Contr.MAIN);
		}
		
		@FXML private void initialize() {
			// Menus
			m_standard.setOnAction(evt -> afficheCalculatriceStandard()); // A FAIRE ULTERIEUREMENT
			m_scientifique.setOnAction(evt -> afficheCalculatriceScientifique());// A FAIRE ULTERIEUREMENT
			m_quitter.setOnAction(evt -> System.exit(0));
			m_aidecalculatrice.setOnAction(evt -> {});// A FAIRE ULTERIEUREMENT
			m_apropos.setOnAction(evt -> {});// A FAIRE ULTERIEUREMENT
	    }

		public BorderPane getMainBorderPane() {
			return mainBorderPane;
		}

		public void setMainBorderPane(BorderPane mainBorderPane) {
			this.mainBorderPane = mainBorderPane;
		}
}
