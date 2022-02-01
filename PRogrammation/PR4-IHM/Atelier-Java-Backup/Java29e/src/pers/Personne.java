package pers;

import util.Adresse;

public class Personne
{
	private String nom, prenom;
	private int age;
	private Adresse adresse;
	
	public Personne(String nom, String prenom, int age, Adresse adresse)
	{
		this.nom = new String(nom);
		this.prenom = new String(prenom);
		this.age = age;
		this.adresse = new Adresse(adresse);
	}
	
	public Personne()
	{
		this("Doe", "John", 0, null);
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
		String str = this.nom + " " + this.getPrenom() + ", " + this.age;
		if(this.adresse != null)
				str += "\n" + this.adresse;
		return str;
	}
	
	public void affiche()
	{
		System.out.println(this.nom + " " + this.getPrenom() + ", " + this.age + "\n" + this.adresse);
	}
}
