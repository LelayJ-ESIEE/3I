package util;

public class Compteur {
	private static int nbcounter = 0;
	
	private int cpt;
	
	public Compteur(int i) {
		this.cpt = i;
		Compteur.nbcounter++;
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
	
	public Compteur increment() {
		++this.cpt;
		return this;
	}
	
	public void affiche() {
		System.out.println ("valeur : " + this.cpt);
	}
	
	public int lirecount() {
		return cpt;
	}
	
	public static int lirenbcounter()
	{
		return Compteur.nbcounter;
	}
	
	public Compteur add(Compteur cnt)
	{
		this.cpt += cnt.lirecount();
		return this;
	}
}
