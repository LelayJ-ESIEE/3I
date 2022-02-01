import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class Metronome implements ActionListener
{
	private String message;
	
	public Metronome()
	{
		this("bip");
	}
	
	public Metronome(String mes)
	{
		message=mes;
	}
	
	public void setMessage(String mes)
	{
		message = mes;
	}
	
	public String getMessage()
	{
		return message;
	}

	@Override
	public void actionPerformed(ActionEvent e)
	{
		System.out.println(this.message);
	}
}