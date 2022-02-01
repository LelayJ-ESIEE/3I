package gestion;
import util.Compteur;

public class Appli {

	public static void main(String[] args) {
		Compteur c1=new Compteur();
		c1.increment();
		c1.affiche();
		
		int n=c1.lirecount();
		System.out.println("n: "+n);
		
		c1.init();
		c1.affiche();
		
		Compteur c2=new Compteur(3);
		c2.init(15);
		
		c2.affiche();
		c1.init(c2);
		c1.affiche();
		Compteur c3=new Compteur(c2);
		c3.affiche();
	}

}
