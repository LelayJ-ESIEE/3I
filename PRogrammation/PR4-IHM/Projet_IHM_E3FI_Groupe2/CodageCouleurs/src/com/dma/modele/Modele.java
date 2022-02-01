package com.dma.modele;

import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleIntegerProperty;

public class Modele {
	private IntegerProperty couleur;
	
	public Modele() {		
		couleur = new SimpleIntegerProperty(0);
	}
	
	public IntegerProperty couleurProperty() {
		return couleur;
	}
	
	public void reinit() {
		couleur.setValue(0);
	}
	
	public void depart() {
	}
		
}
