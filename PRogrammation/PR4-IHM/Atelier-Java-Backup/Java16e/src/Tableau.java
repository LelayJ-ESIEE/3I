import util.Compteur;

public class Tableau
{
	public static void main(String[] args)
	{
		int[] tab = new int[20];
		Compteur[] tc = new Compteur[20];
		for(int i = 0; i < tab.length; i++) {
			tab[i] = (int) Math.pow(2, i);
			tc[i] = new Compteur((int) Math.pow(2, i));
		}
		
		System.out.println("tab :");
		for (int i : tab)
		{
			System.out.println(i);
		}
		
		System.out.println("\ntc :");
		for (Compteur compteur : tc)
		{
			System.out.println(compteur);
		}
		
		
	}
}
