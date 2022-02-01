package util;

public class Compteur {
	private int cpt;
	
	public Compteur() {
		this.cpt = 0;
	}
	
	public void increment() {
		++ this.cpt;
	}
	
	public void affiche() {
		System.out.println ("valeur : " + this.cpt);
	}
	
	public int lirecount() {
		return cpt;
	}
}
