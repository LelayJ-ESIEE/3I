package com.dma;

import java.io.IOException;

import com.dma.controleur.MinuteurControleurXX;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

public class Main extends Application {

	private Pane pane;
	private MinuteurControleurXX minuteurControleur;

	@Override
	public void start(Stage primaryStage) {
		primaryStage.setTitle("Minuteur");
		primaryStage.setOnCloseRequest(evt -> System.out.println("Fermeture fenetre")); 

		pane = loadMinuteur();
		initMain(primaryStage, pane);
	}
	
	@Override
	public void stop() {
		//libération des ressources
		minuteurControleur.reinit();
	}
	
	public void initMain(Stage primaryStage, Pane pane) {
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();
	}

	public static void main(String[] args) {
		launch(args);
	}

	public Pane loadMinuteur() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/Minuteur.fxml"));
			p = (Pane) loader.load();
			minuteurControleur = (MinuteurControleurXX) loader.getController();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
}
