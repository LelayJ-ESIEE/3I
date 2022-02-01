package com.dma;

import java.io.IOException;

import com.dma.controleur.AbstractControleur;

import javafx.application.Application;
import javafx.fxml.FXMLLoader;
import javafx.scene.Scene;
import javafx.scene.layout.BorderPane;
import javafx.scene.layout.Pane;
import javafx.stage.Stage;

public class Main extends Application {

	private Pane mainParent;
	private Pane agendaParent;
	private AbstractControleur mainControleur;

	@Override
	public void start(Stage primaryStage) {
		primaryStage.setTitle("Agenda");
		primaryStage.setOnCloseRequest(evt -> System.out.println("Stage is closing")); 

		mainParent = loadMain();
		agendaParent = loadAgenda();
		initMain(primaryStage, mainParent);
		showAgenda();
		
		// décommenter les instructions suivantes au fur et à mesure du développement
		loadRdvJour();
		loadPriseRdv();
		loadAjoutPatient();
		loadSuppressionPatient();
		loadNotesPatient();
	}
	
	@Override
	public void stop() {
		//libération des ressources
		mainControleur.close();
	}
	
	private void showAgenda(){
		((BorderPane)mainParent).setCenter(agendaParent);	
	}
	
	public void initMain(Stage primaryStage, Pane pane) {
		Scene scene = new Scene(pane);
		scene.getStylesheets().add(getClass().getResource("application.css").toExternalForm());
		primaryStage.setScene(scene);
		primaryStage.show();
	}

	public static void main(String[] args) {
		launch(args);
	}

	public Pane loadMain() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/Main.fxml"));
			p = (Pane) loader.load();
			mainControleur = (AbstractControleur) loader.getController();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}

	public Pane loadAgenda() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/Agenda.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}

	public Pane loadRdvJour() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/RdvJour.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public Pane loadPriseRdv() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/PriseRdv.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public Pane loadAjoutPatient() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/AjoutPatient.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public Pane loadSuppressionPatient() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/SuppressionPatient.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}
	
	public Pane loadNotesPatient() {
		Pane p = null;
		try {
			FXMLLoader loader = new FXMLLoader();
			loader.setLocation(Main.class.getResource("vue/Notes.fxml"));
			p = (Pane) loader.load();
		} catch (IOException e) {
			e.printStackTrace();
		}
		return p;
	}

}
