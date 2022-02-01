
public class Factorielle {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		if(args.length != 1)
			System.out.println("Entrer un argument entier");
		else
		{
			int i = Integer.parseInt(args[0]);
			int res = 1;
			for(;i>1;i--)
				res*=i;
			System.out.println(res);
		}
	}

}
