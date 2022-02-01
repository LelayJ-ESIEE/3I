package com.dma;
	
import java.io.IOException;
import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.stage.Stage;
import javafx.scene.Parent;
import javafx.scene.Scene;
import javafx.scene.layout.BorderPane;

public class Main extends Application {

	private Parent parentMain;
	private Parent parentStandard;
	private Parent parentScientifique;
	
	@Override
	public void start(Stage primaryStage) {
		primaryStage.setTitle("Calculatrice");

		parentMain = loadMain();
		parentStandard = loadCalculatriceStandard();
		parentScientifique = loadCalculatriceScientifique();
		
		initMain(primaryStage, parentMain);
		showCalculatrice();
	}
	
	public void initMain(Stage primaryStage, Parent parent) {
		Scene scene = new Scene(parent);
		scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		primaryStage.setScene(scene);
		primaryStage.show();
	}
	
	private void showCalculatrice(){
		((BorderPane)parentMain).setCenter(parentStandard);
	}
	
	public Parent loadMain() {
		Parent p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/Main.fxml"));
			p = (Parent) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public Parent loadCalculatriceStandard() {
		Parent p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/CalculatriceStandard.fxml"));
			p = (Parent) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public Parent loadCalculatriceScientifique() {
		Parent p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/CalculatriceScientifique.fxml"));
			p = (Parent) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public static void main(String[] args) {
		launch(args);
	}
}
