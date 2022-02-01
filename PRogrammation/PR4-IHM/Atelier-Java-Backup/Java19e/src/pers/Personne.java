package pers;

import util.Adresse;

public class Personne
{
	private String nom, prenom;
	private int age;
	private Adresse adresse;
	
	public Personne(String nom, String prenom, int age, Adresse adresse)
	{
		this.nom = nom;
		this.prenom = prenom;
		this.age = age;
		this.adresse = adresse;
	}
	
	public Personne()
	{
		this("Doe", "John", 0, new Adresse());
	}
	
	public String getNom()
	{
		return nom;
	}
	
	public String getPrenom()
	{
		return prenom;
	}
	
	public int getAge()
	{
		return age;
	}
	
	public Adresse getAdresse()
	{
		return adresse;
	}
	
	public void setNom(String nom)
	{
		this.nom = nom;
	}
	
	public void setPrenom(String prenom)
	{
		this.prenom = prenom;
	}
	
	public void setAge(int age)
	{
		this.age = age;
	}
	
	public void setAdresse(Adresse adresse)
	{
		this.adresse = adresse;
	}
	
	@Override
	public String toString()
	{
		return this.nom + " " + this.getPrenom() + ", " + this.age + ", " + this.adresse;
	}
	
	public void affiche()
	{
		System.out.println(this);
	}
}
