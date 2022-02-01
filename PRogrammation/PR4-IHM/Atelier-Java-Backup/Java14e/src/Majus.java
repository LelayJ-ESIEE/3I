
public class Majus
{
	public static void main(String[] args)
	{
		if(args.length != 1)
			System.out.println("Veuillez entrer une chaine de caracteres en argument");
		else
		{
			System.out.println( args[0].toUpperCase().charAt(0) + args[0].toLowerCase().substring(1) );
		}
	}
}
