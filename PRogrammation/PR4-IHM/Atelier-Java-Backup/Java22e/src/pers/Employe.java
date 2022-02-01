package pers;

import util.Adresse;

public class Employe extends Personne
{
	protected double salaire;
	
	public Employe(String nom, String prenom, int age, Adresse adresse, double salaire)
	{
		super(nom, prenom, age, adresse);
		this.salaire = salaire;
	}

	public Employe()
	{
		super();
		this.salaire = 0.0;
	}
	
	public void setSalaire(double salaire)
	{
		this.salaire = salaire;
	}
	
	@Override
	public String toString()
	{
		// TODO Auto-generated method stub
		return super.toString() + "\n" + "Salaire : " + this.salaire;
	}
	
	public void affichemp()
	{
		System.out.println(this + "\n");
	}
	
	public void augmentation(float pc) {
		this.setSalaire(this.salaire + this.salaire*pc/100);
	}
}
