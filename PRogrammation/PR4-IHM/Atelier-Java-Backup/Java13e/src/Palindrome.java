
public class Palindrome
{

	public static void main(String[] args)
	{
		if(args.length != 1)
			System.out.println("Veuillez entrer un mot en argument");
		else
		{
			StringBuilder input = new StringBuilder(args[0]);
			input = input.reverse();
			String reversedInput = input.toString();
			System.out.println(args[0].equalsIgnoreCase(reversedInput));
		}
		
	}

}
