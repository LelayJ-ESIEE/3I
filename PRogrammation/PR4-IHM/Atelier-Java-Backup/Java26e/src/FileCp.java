import java.io.*;

class FileCp {
	public static void main(String[] args) {
		if(args.length != 2) {
			System.err.println("il faut	indiquer les fichiers source et destination!");
			System.exit(1);
		}
		BufferedInputStream ficin = null;
		BufferedOutputStream ficout = null;
		try
		{
			ficin=new BufferedInputStream(new FileInputStream(args[0]));
			ficout = new BufferedOutputStream(new FileOutputStream(args[1]));
			int val;
			int n=0;
		
			while((val=ficin.read()) != -1){
				ficout.write(val);
				n++;
			}
			System.out.println("copie effectuee...");
		}
		catch (FileNotFoundException FNFe)
		{
			System.err.println("FileNotFound Exception: " + FNFe.getMessage());
		}
		catch (IOException IOe)
		{
			System.err.println("I/O Exception: " + IOe.getMessage());
		}
		finally {
			try
			{
				if(ficin != null)
					ficin.close();
			}
			catch (IOException IOe)
			{
				System.err.println("I/O Exception à la fermeture de ficin: " + IOe.getMessage());
			}
			try
			{
				if(ficin != null)
					ficout.close();
			}
			catch (IOException IOe)
			{
				System.err.println("I/O Exception à la fermeture de ficout: " + IOe.getMessage());
			}
		}
	}
}