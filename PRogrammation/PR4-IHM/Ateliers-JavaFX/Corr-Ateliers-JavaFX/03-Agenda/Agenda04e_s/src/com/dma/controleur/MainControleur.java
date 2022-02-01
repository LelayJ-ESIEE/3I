package com.dma.controleur;

import com.dma.controleur.Mediateur.Contr;

import javafx.fxml.FXML;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.Pane;

public class MainControleur extends AbstractControleur {
		
		@FXML private BorderPane mainBorderPane;
				
		public MainControleur(){
			super(Contr.MAIN);
		}
		
		@FXML private void initialize() {
	    }

		public BorderPane getMainBorderPane() {
			return mainBorderPane;
		}

		public void setMainBorderPane(BorderPane mainBorderPane) {
			this.mainBorderPane = mainBorderPane;
		}
		
		@Override
		public Pane getPane() {
			return mainBorderPane;
		}

		@Override
		public void actualiser() {
			
		}
}
