package com.dma.modele;

import java.time.LocalDate;

import javafx.beans.property.ObjectProperty;

import com.dma.modele.metier.Client;
import com.dma.modele.metier.CreneauMedecinJour;
import com.dma.modele.metier.Medecin;

public interface IModele {

	public ObjectProperty<Medecin> medecinProperty() ;
	
	public ObjectProperty<LocalDate> jourProperty() ;
	
	public ObjectProperty<CreneauMedecinJour> creneauMedecinJourProperty();
	
	public Client creerClient(boolean genre, String nom, String prenom);
		
}
