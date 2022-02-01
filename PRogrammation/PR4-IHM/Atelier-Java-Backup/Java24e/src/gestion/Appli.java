package gestion;

import pers.Employe;
import pers.Personne;
import pers.Technicien;
import util.Adresse;

public class Appli
{
	public static void main(String[] args)
	{
		Personne[] tpers = new Personne[5];
		
		Personne martin=new Personne();
		martin.setNom("MARTIN");
		martin.setPrenom("Pierre");
		martin.setAge(28);
		martin.setAdresse(new Adresse("3, rue de la Pompe","", "75013",	"Paris"));
		tpers[0] = martin;
		
		Personne durand=new	Personne("DURAND","Alain",30, new Adresse("Bd Gambetta","","78300","Poissy"));
		Adresse ad=durand.getAdresse();
		tpers[1] = durand;
		
		Employe legoff=new Employe();
		legoff.setNom("LEGOFF");
		legoff.setPrenom("Eve");
		legoff.setAge(32);
		legoff.setSalaire(4000.0);
		legoff.setAdresse(ad);
		tpers[2] = legoff;
		
		Employe duval=new Employe("DUVAL","Sophie",25,null, 3000.0);
		duval.setAdresse(new Adresse("10, rue de l'Entreprise",	"Pole galilee 1","95000","Cergy"));
		duval.augmentation(1.0f);
		tpers[3] = duval;

		Technicien dupuis= new Technicien("DUPUIS","Bernard",28,null, 3500,"maintenance");
		dupuis.setAdresse(new Adresse("20, rue de la Republique", "","75011","Paris"));
		dupuis.augmentation(1.0f);
		tpers[4] = dupuis;
		
		for (Personne personne : tpers)
		{
			personne.affiche();
			System.out.println();
		}
	}
}
