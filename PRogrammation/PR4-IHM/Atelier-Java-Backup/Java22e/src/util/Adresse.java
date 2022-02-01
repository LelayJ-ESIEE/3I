package util;

public class Adresse
{
	private String voie;
	private String complement;
	private String codePostal;
	private String ville;
	
	public Adresse(final String voie, final String complement, final String codePostal, final String ville)
	{
		this.voie = voie;
		this.complement = complement;
		this.codePostal = codePostal;
		this.ville = ville;
	}
	
	public Adresse()
	{
		this("","","","");
	}
	
	@Override
	public String toString()
	{
		String str = "";
		if(!this.voie.equals(""))
			str += this.voie;
		
		if(!this.complement.equals(""))
		{
			if(!str.equals(""))
				str += ", ";
			str += this.complement;
		}
		
		if(!this.codePostal.equals(""))
		{
			if(!str.equals(""))
				str += ", ";
			str += this.codePostal;
		}
		
		if(!this.ville.equals(""))
		{
			if(!str.equals("")) {
				if(this.codePostal.equals(""))
					str += ", ";					
				else
					str += " ";
			}
			str += this.ville;
		}
		
		return str;
	}

	@Override
	public boolean equals(Object obj)
	{
		return (this.getClass().getName().equals(obj.getClass().getName()) &&
				this.voie.equals( ((Adresse) obj).voie) &&
				this.complement.equals( ((Adresse) obj).complement) &&
				this.codePostal.equals( ((Adresse) obj).codePostal) &&
				this.ville.equals( ((Adresse) obj).ville)
				);
	}
}
