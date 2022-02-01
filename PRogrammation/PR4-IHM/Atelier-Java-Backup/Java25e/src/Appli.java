import javax.swing.Timer;

public class Appli
{
	public static void main(String[] args)
	{
		Metronome m=new Metronome("tic");
		Timer t=new Timer(60000/120,m); // ERREUR !
		t.start();
		System.out.println("timer demarre...");
		while(true);
	}
}
