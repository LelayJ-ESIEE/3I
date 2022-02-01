package com.dma.modele;

import javafx.beans.property.DoubleProperty;
import javafx.beans.property.SimpleDoubleProperty;

public class CalculatriceModele {
	private DoubleProperty courant;
	private DoubleProperty resultat;
	private Operation lastOperationUnOperande;
	private Operation lastOperationDeuxOperandes;
	private boolean nouvelleSaisie;
	
	enum Operation {NONE, ADDITION, SOUSTRACTION, MULTIPLICATION, DIVISION, POURCENT, RACINE, CARRE, INVERSE, OPPOSE, EGALE}
	
	public CalculatriceModele(){
		courant = new SimpleDoubleProperty(0);
		resultat = new SimpleDoubleProperty(0);
		lastOperationDeuxOperandes = Operation.NONE;
		lastOperationUnOperande = Operation.NONE;
		nouvelleSaisie = true;
	}
	
	public void init(){
		courant.setValue(0);
		resultat.setValue(0);
		lastOperationDeuxOperandes = Operation.NONE;
		lastOperationUnOperande = Operation.NONE;
		nouvelleSaisie = true;
	}
	
	public DoubleProperty courantDoubleProperty() {
		return courant;
	}

	public boolean isNouvelleSaisie() {
		return nouvelleSaisie;
	}
	
	public void setNouvelleSaisie(boolean nouvelleSaisie) {
		this.nouvelleSaisie = nouvelleSaisie;
	}

	public void calculDeuxOperandes(){
		System.out.println("calculDeuxOperandes ("+lastOperationDeuxOperandes+")");
		switch(lastOperationDeuxOperandes){
			case NONE:
				resultat.setValue(courant.getValue());
				nouvelleSaisie = true;
				break;
			
			case ADDITION:
				resultat.setValue(resultat.getValue() + courant.getValue());
				nouvelleSaisie = true;
				break;
				
			case SOUSTRACTION:
				resultat.setValue(resultat.getValue() - courant.getValue());
				nouvelleSaisie = true;
				break;
				
			case MULTIPLICATION:
				resultat.setValue(resultat.getValue() * courant.getValue());
				nouvelleSaisie = true;
				break;
				
			case DIVISION:
				resultat.setValue(resultat.getValue() / courant.getValue());
				nouvelleSaisie = true;
				break;
								
			case EGALE:
				courant.setValue(resultat.getValue());
				nouvelleSaisie = true;
				break;			
			
			default:
				
		}
		courant.setValue(resultat.getValue());
		
		System.out.println("calculDeuxOperandes(fin du switch): courant= "+ courant.getValue()+", resultat="+resultat.getValue());
	}
	
	public void calculUnOperande(){
		System.out.println("calculUnOperande ("+lastOperationUnOperande+")");
		switch(lastOperationUnOperande){
			case NONE:
				resultat.setValue(courant.getValue());
				courant.setValue(0);
				break;
								
			case POURCENT:
				courant.setValue((courant.getValue() / 100.0) * resultat.getValue());
				break;
				
			case RACINE:
				courant.setValue(Math.sqrt(courant.getValue().doubleValue()));
				break;
				
			case CARRE:
				courant.setValue(courant.getValue() * courant.getValue());
				break;
				
			case INVERSE:
				courant.setValue(1.0 / courant.getValue());
				break;
				
			case OPPOSE:
				courant.setValue(- courant.getValue());
				break;
			
			case EGALE:
				courant.setValue(resultat.getValue());
				break;			
			
			default:
				
		}
		System.out.println("calculUnOperande(fin du switch): courant= "+ courant.getValue()+", resultat="+resultat.getValue());
	}
	
	// Opérations mathématiques binaires
	public void addition(){
		calculDeuxOperandes();
		lastOperationDeuxOperandes = Operation.ADDITION;
	}
	
	public void soustraction(){
		calculDeuxOperandes();
		lastOperationDeuxOperandes = Operation.SOUSTRACTION;
	}
	
	public void multiplication(){
		calculDeuxOperandes();
		lastOperationDeuxOperandes = Operation.MULTIPLICATION;		
	}
	
	public void division(){
		calculDeuxOperandes();
		lastOperationDeuxOperandes = Operation.DIVISION;			
	}
	
	// Opérations mathématiques unaires
	public void pourcent(){
		lastOperationUnOperande = Operation.POURCENT;
		calculUnOperande();
	}
	
	public void racine(){
		lastOperationUnOperande = Operation.RACINE;	
		calculUnOperande();		
	}
	
	public void carre(){
		lastOperationUnOperande = Operation.CARRE;
		calculUnOperande();
	}
	
	public void inverse(){	
		lastOperationUnOperande = Operation.INVERSE;
		calculUnOperande();
	}
	
	public void oppose(){
		lastOperationUnOperande = Operation.OPPOSE;
		calculUnOperande();
	}
	
	public void egale(){
		calculDeuxOperandes();
		lastOperationDeuxOperandes = Operation.EGALE;		
	}
}
