
public class Perim {
	public static void main(String[] args) {
		if(args.length!=1) {
			System.out.println("il faut fournir le rayon en argument!");
		} else {
			double rayon = Double.parseDouble(args[0]);
			double perimetre = 2* Math.PI * rayon;
			double surface = Math.PI * Math.pow(rayon, 2);
			double volume = 4.0/3.0 * Math.PI * Math.pow(rayon, 3);
			
			System.out.println("Perimetre : " + perimetre);
			System.out.println("Surface : " + surface);
			System.out.println("Volume : " + volume);
		}
	}
}
