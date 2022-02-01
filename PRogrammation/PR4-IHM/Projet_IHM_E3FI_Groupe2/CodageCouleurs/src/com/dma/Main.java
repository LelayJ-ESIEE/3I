package com.dma;

import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

public class Main extends Application {

	private Pane pane;

	@Override
	public void start(Stage primaryStage) {
		primaryStage.setTitle("Codage des couleurs");
		primaryStage.setOnCloseRequest(evt -> System.out.println("Fermeture fenetre")); 

		pane = loadVue();
		initMain(primaryStage, pane);
	}
	
	@Override
	public void stop() {
	}
	
	public void initMain(Stage primaryStage, Pane pane) {
		Scene scene = new Scene(pane);
		primaryStage.setScene(scene);
		primaryStage.show();
	}

	public static void main(String[] args) {
		launch(args);
	}

	public Pane loadVue() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/CodageCouleursLJ.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
}
