package util;

public class Compteur {
	private int cpt;
	
	public Compteur(int i) {
		this.cpt = i;
	}
	
	public Compteur() {
		this(0);
	}

	public Compteur(Compteur cnt) {
		this(cnt.lirecount());
	}

	public void init(int i) {
		this.cpt = i;
	}
	
	public void init() {
		this.init(0);
	}
	
	public void init(Compteur cnt) {
		this.init(cnt.lirecount());
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
