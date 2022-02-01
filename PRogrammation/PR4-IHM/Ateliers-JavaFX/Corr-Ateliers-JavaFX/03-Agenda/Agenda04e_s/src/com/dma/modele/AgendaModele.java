package com.dma.modele;

import java.time.LocalDate;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleObjectProperty;
import com.dma.modele.metier.CreneauMedecinJour;
import com.dma.modele.metier.Medecin;

public class AgendaModele implements IModele {
	private ObjectProperty<Medecin> medecinProperty; // le médecin sélectionné
	private ObjectProperty<LocalDate> jourProperty; // le jour sélectionné
	private ObjectProperty<CreneauMedecinJour> creneauMedecinJourProperty; // le creneau sélectionné
	
	public AgendaModele() {
		medecinProperty = new SimpleObjectProperty<>(new Medecin());
		jourProperty = new SimpleObjectProperty<>(LocalDate.now());
		creneauMedecinJourProperty = new SimpleObjectProperty<>(new CreneauMedecinJour());
	}

	public ObjectProperty<Medecin> medecinProperty() {
		return medecinProperty;
	}

	public ObjectProperty<LocalDate> jourProperty() {
		return jourProperty;
	}

	public ObjectProperty<CreneauMedecinJour> creneauMedecinJourProperty() {
		return creneauMedecinJourProperty;
	}
	
}
