# Base de données - TP6 - Rapport

## __JDBCTest.java__

```java
import java.awt.*;
import java.awt.event.*;
import java.sql.*;

public class JDBCTest extends Panel
implements ActionListener
{
	TextField nomDriver;
	TextField urlConnection;
	TextField nomLogin;
	TextField motPasse;
	Button boutonConnection;
	TextField requeteSQL;
	List resultatRequete;
	Button boutonExecuter;
	
	Connection conn;
	
	public JDBCTest()
	{
		Panel haut;
		Panel bas;
		
		haut = new Panel();
		bas = new Panel();
		
		boutonConnection = new Button("Connection");
		boutonConnection.addActionListener(this);
		
		boutonExecuter = new Button("Execution");
		boutonExecuter.addActionListener(this);
		
		Panel p1 = new Panel();
		p1.setLayout(new GridLayout(4, 2));
		p1.add(new Label("Driver :"));
		p1.add(nomDriver = new TextField("com.mysql.jdbc.Driver", 32));
		p1.add(new Label("URL jdbc :"));
		p1.add(urlConnection = new TextField("jdbc:mysql:///parc",32));
		p1.add(new Label("login :"));
		p1.add(nomLogin = new TextField(32));
		p1.add(new Label("password :"));
		p1.add(motPasse = new TextField(32));
		
		haut.setLayout(new BorderLayout());
		haut.add(p1, BorderLayout.NORTH);
		haut.add(boutonConnection, BorderLayout.SOUTH);
		
		Panel p2 = new Panel();
		p2.setLayout(new BorderLayout());
		p2.add(new Label("requete"), BorderLayout.WEST);
		p2.add(requeteSQL = new TextField(32), BorderLayout.CENTER);
		
		Panel p3 = new Panel();
		p3.setLayout(new BorderLayout());
		p3.add(p2, BorderLayout.NORTH);
		p3.add(boutonExecuter, BorderLayout.SOUTH);
		
		bas.setLayout(new BorderLayout());
		bas.add(p3, BorderLayout.NORTH);
		bas.add(resultatRequete = new List(20));
		
		setLayout(new BorderLayout());
		add(haut, BorderLayout.NORTH);
		add(bas, BorderLayout.CENTER);
	}
	
	public void actionPerformed(ActionEvent evt)
	{
		Button source = (Button)evt.getSource();
		if(source == this.boutonConnection) {
			try
			{
				Class.forName(this.nomDriver.getText());
				this.conn = DriverManager.getConnection(
						 this.urlConnection.getText(),
						 this.nomLogin.getText(), this.motPasse.getText());
				resultatRequete.add("Connected");

			}
			catch (ClassNotFoundException e)
			{
				resultatRequete.add("erreur a l'execution : Driver");
				e.printStackTrace();
			}
			catch (SQLException e)
			{
				resultatRequete.add("erreur a l'execution : Connexion");
				e.printStackTrace();
			}
		}
		else if(source == this.boutonExecuter) {
			if(this.conn == null) {
				resultatRequete.add("erreur a l'execution : aucune connexion");
			}
			else {
				try
				{
					Statement stmt = this.conn.createStatement();
					String request = this.requeteSQL.getText();
					stmt.execute(request);
					resultatRequete.add("Requete executee");
				}
				catch (SQLException e)
				{
					resultatRequete.add("erreur a l'execution : Requete");
					e.printStackTrace();
				}
			}
		}
	}
	
	public static void main(String[] arg)
	{
		JDBCTest test;
		
		Frame f = new Frame();
		f.setSize(500, 400);
		test = new JDBCTest( );
		
		f.add(test, BorderLayout.CENTER);
		f.addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e)
			{
				System.exit(0);
			}} );
		f.setVisible(true);
	}
}
```

## __JDBCExo.java__

```java
import java.sql.*;
import java.util.ArrayList;

public class JDBCExo
{
	private static Connection con;
	
	private static ArrayList<ArrayList<String>> getSalles() throws SQLException {
		ArrayList<ArrayList<String>> list = new ArrayList<ArrayList<String>>();

		Statement stmt = con.createStatement();
		String s = "SELECT * FROM Salle";
		ResultSet rs = stmt.executeQuery(s);
		ResultSetMetaData rsmd = rs.getMetaData();
		int columnsNumber = rsmd.getColumnCount();
		list.add(new ArrayList<String>());
		for(int i = 1; i <= columnsNumber; i++) {
			list.add(new ArrayList<String>());
			
			String str = rsmd.getColumnName(i);
			if(i > 1) {
				str = "    "+str;
			}
			list.get(0).add(str);
		}
		while(rs.next()) {
			for(int i = 1; i <= columnsNumber; i++) {
				String columnValue = rs.getString(i);
				list.get(i).add(columnValue);
			}
		}			
		return list;
	}
	
	private static void deleteSalle(int index) throws SQLException {
		Statement stmt = con.createStatement();
		String s = "SELECT * FROM Salle";
		ResultSet rs = stmt.executeQuery(s);
		if(rs.absolute(index))
			rs.deleteRow();
	}
	
	public static void main(String[] args)
	{
		try {
			Class.forName("com.mysql.jdbc.Driver");
			JDBCExo.con = DriverManager.getConnection("jdbc:mysql:///parc");
			ArrayList<ArrayList<String>> list = JDBCExo.getSalles();
			
			for (ArrayList<String> arrayList : list)
			{
				for (String s : arrayList)
				{
					System.out.print(s + "    ");
				}
				System.out.println("");
			}
			
			deleteSalle(-1);
		}
		catch (ClassNotFoundException e)
		{
			System.out.println("erreur a l'execution : Driver");
			e.printStackTrace();
		}
		catch (SQLException e)
		{
			System.out.println("erreur a l'execution :");
			e.printStackTrace();
		}
	}
}
```