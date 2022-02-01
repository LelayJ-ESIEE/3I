
public class Signe {
	public static void main(String[] args) {
		if(args.length != 1) {
			System.out.println("Merci de fournir un entier en argument.");
		}
		else {
			int i = Integer.parseInt(args[0]);
			if (i < 0)
				System.out.println("Entree négative");
			else if (i>0)
				System.out.println("Entree positive");
			else
				System.out.println("Entree nulle");
		}
	}
}
