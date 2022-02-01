package com.dma.modele;

import java.time.LocalDate;
import javafx.beans.property.ObjectProperty;
import javafx.beans.property.SimpleObjectProperty;
import com.dma.modele.metier.Medecin;

public class AgendaModele implements IModele {
	private ObjectProperty<Medecin> medecinProperty; // le m�decin s�lectionn�
	private ObjectProperty<LocalDate> jourProperty; // le jour s�lectionn�

	public AgendaModele() {
		medecinProperty = new SimpleObjectProperty<>(new Medecin());
		jourProperty = new SimpleObjectProperty<>(LocalDate.now());
	}

	public ObjectProperty<Medecin> medecinProperty() {
		return medecinProperty;
	}

	public ObjectProperty<LocalDate> jourProperty() {
		return jourProperty;
	}

}
