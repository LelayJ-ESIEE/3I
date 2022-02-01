public class FileCp {
	//recoit les fichiers origine et destination
	//java FileCp fichier_origine fichier_destination
	public static void main(String[] args) {
		if(args.length != 2){
			System.err.println("il faut indiquer les noms 
				de fichiers !");
		}else{
			int n=copie(args[0],args[1]);
			System.out.println("copie effectuee…");
		}
	}// fin de main
	
	private static int copie(String origine, String destination){
		BufferedInputStream ficin=null;
		BufferedOutputStream ficout=null;
		try {		
			// ouverture du fichier_origine en lecture
			FileInputStream ficinf=new FileInputStream(origine);
			ficin=new BufferedInputStream(ficinf); 
			
			// ouverture du fichier_destination en écriture
			ficout=new BufferedOutputStream(
					new FileOutputStream(destination)); 
			
			int n=0;
			// boucle de lecture-écriture:
			int octet;
				// lecture d'un octet dans le fichier_origine
			while((octet=ficin.read()) != -1){
				// écriture de cet octet dans le fichier_destination
				ficout.write(octet);
				n++;
			}
			return n;
		}catch(FileNotFoundException e ){
			System.err.println("Pb a l'ouverture: "+e.getMessage());
		}catch(IOException e){
			System.err.println("Pb lors de la copie: "
				+e.getMessage());
		}
		finally{//fermeture des fichiers
			try {
				if(ficin!=null){
					ficin.close();
				}
			} catch (IOException e) {
				//System.err.println("Pb a la fermeture: "+
//e.getMessage());
			}
			try {
				if(ficout!=null){
					ficout.close();
				}
			} catch (IOException e) {
				System.err.println("Pb a la fermeture: "+
					e.getMessage());
			}
		}
	}		
}
	