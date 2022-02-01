package com.dma.modele.metier;

import java.io.Serializable;

public class CreneauMedecinJour implements Serializable {
	private static final long serialVersionUID = 1L;
	private Creneau creneau;
	private Rv rv;

	public CreneauMedecinJour() {

	}

	public CreneauMedecinJour(Creneau creneau, Rv rv) {
		this.creneau = creneau;
		this.rv = rv;
	}

	@Override
	public String toString() {
		return String.format("[%s %s]", creneau, rv);
	}

	public Creneau getCreneau() {
		return creneau;
	}

	public void setCreneau(Creneau creneau) {
		this.creneau = creneau;
	}

	public Rv getRv() {
		return rv;
	}

	public void setRv(Rv rv) {
		this.rv = rv;
	}

}
