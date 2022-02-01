package pers;

import util.Adresse;

public class Technicien extends Employe
{
	private String specialite;

	public Technicien(String nom, String prenom, int age, Adresse adresse, double salaire, String specialite)
	{
		super(nom, prenom, age, adresse, salaire);
		this.specialite = new String(specialite);
	}

	public Technicien()
	{
		super();
		this.specialite = "";
	}
	
	public String getSpecialite()
	{
		return specialite;
	}
	
	public void setSpecialite(String specialite)
	{
		this.specialite = specialite;
	}

	@Override
	public String toString()
	{
		return super.toString() + "\nTechnicien " + this.specialite;
	}
	
	@Override
	public void affiche()
	{
		super.affiche();
		System.out.println("Technicien "+this.specialite);
		
	}
	
	@Override
	public void augmentation(float pc)
	{
		super.augmentation(pc);
		this.setSalaire(this.salaire + 50);
	}
	
}
