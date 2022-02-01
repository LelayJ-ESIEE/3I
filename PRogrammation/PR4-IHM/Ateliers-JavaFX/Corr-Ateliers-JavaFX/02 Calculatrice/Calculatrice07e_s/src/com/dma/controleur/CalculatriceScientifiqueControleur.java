package com.dma.controleur;

import com.dma.controleur.Mediateur.Contr;
import com.dma.modele.CalculatriceModele;
import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.TextField;
import javafx.scene.layout.AnchorPane;
import javafx.util.converter.NumberStringConverter;

public class CalculatriceScientifiqueControleur extends AbstractControleur {
	private CalculatriceModele modele;
	
	@FXML private AnchorPane calculatriceScientifiqueAnchorPane;
	
	@FXML private TextField t_saisie;
	
	@FXML private Button b_clearentry;
	@FXML private Button b_clear;
	@FXML private Button b_back;
	
	@FXML private Button b_addition;
	@FXML private Button b_soustraction;
	@FXML private Button b_multiplication;
	@FXML private Button b_division;
	@FXML private Button b_pourcent;
	@FXML private Button b_racine; 
	@FXML private Button b_carre;
	@FXML private Button b_inverse;
	@FXML private Button b_oppose;
	
	@FXML private Button b_virgule;
	@FXML private Button b_egale;

	@FXML private Button b_zero; 
	@FXML private Button b_un;  
	@FXML private Button b_deux;   
	@FXML private Button b_trois;
	@FXML private Button b_quatre;   
	@FXML private Button b_cinq;   
	@FXML private Button b_six;
	@FXML private Button b_sept; 
	@FXML private Button b_huit;
	@FXML private Button b_neuf; 
 
	public CalculatriceScientifiqueControleur(){
		super(Contr.SCIENTIFIQUE);
	}
	
	public AnchorPane getAnchorPane() {
		return calculatriceScientifiqueAnchorPane;
	}
	
	@FXML private void initialize() {
		modele = new CalculatriceModele();
		
		t_saisie.textProperty().bindBidirectional(modele.courantDoubleProperty(), new NumberStringConverter("#.##########"));
		
		// Opérations diverses
		b_clearentry.setOnAction(evt -> supprDerniereSaisie()); // Raz de la dernière saisie
		b_clear.setOnAction(evt -> modele.init()); // Réinitialisation
		b_back.setOnAction(evt -> supprDernierCaractere());// Suppression du dernier caractère saisi
		
		// Quatre opérations arithmétiques
		b_addition.setOnAction(evt -> modele.addition());
		b_soustraction.setOnAction(evt -> modele.soustraction());
		b_multiplication.setOnAction(evt -> modele.multiplication());
		b_division.setOnAction(evt -> modele.division());
		
		// Opérations mathématiques
		b_pourcent.setOnAction(evt -> modele.pourcent());
		b_racine.setOnAction(evt -> modele.racine()); 
		b_carre.setOnAction(evt -> modele.carre());
		b_inverse.setOnAction(evt -> modele.inverse());
		b_oppose.setOnAction(evt -> modele.oppose());
		
		// Virgule, égal
		b_virgule.setOnAction(evt -> addCaractere(','));
		b_egale.setOnAction(evt -> modele.egale());
		
		// Chiffres
		b_zero.setOnAction(evt -> addCaractere('0')); 
		b_un.setOnAction(evt -> addCaractere('1')); ;  
		b_deux.setOnAction(evt -> addCaractere('2')); ;   
		b_trois.setOnAction(evt -> addCaractere('3')); ;
		b_quatre.setOnAction(evt -> addCaractere('4')); ;   
		b_cinq.setOnAction(evt -> addCaractere('5')); ;   
		b_six.setOnAction(evt -> addCaractere('6')); ;
		b_sept.setOnAction(evt -> addCaractere('7')); ; 
		b_huit.setOnAction(evt -> addCaractere('8')); ;
		b_neuf.setOnAction(evt -> addCaractere('9')); ; 
	}
	
	private void addCaractere(char c){
		if(modele.isNouvelleSaisie()){
			t_saisie.clear();
			modele.setNouvelleSaisie(false);
		}
		String s = t_saisie.getText();
		s = new StringBuilder(s).append(c).toString();
		t_saisie.setText(s);
	}
	
	private void supprDernierCaractere(){
		String s = t_saisie.getText().trim();
		s = new StringBuilder(s).deleteCharAt(s.length()-1).toString();
		t_saisie.setText(s); 
	}
	
	private void supprDerniereSaisie(){
		t_saisie.clear();
	}
}
