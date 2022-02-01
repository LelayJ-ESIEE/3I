package application;

import modele.Calculs;
import javafx.application.Application;
import javafx.beans.binding.DoubleBinding;
import javafx.geometry.Insets;
import javafx.geometry.Pos;
import javafx.scene.Scene;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.GridPane;
import javafx.scene.text.Font;
import javafx.scene.text.FontWeight;
import javafx.scene.text.Text;
import javafx.stage.Stage;

public class IHMBille extends Application {
	private Calculs calculs;

	@Override
	public void init() {
		calculs = new Calculs();
	}

	@Override
	public void start(Stage primaryStage) {
		GridPane gp_calcul = new GridPane();
		gp_calcul.setAlignment(Pos.TOP_CENTER);
		gp_calcul.setHgap(10);
		gp_calcul.setVgap(10);
		gp_calcul.setPadding(new Insets(5, 5, 5, 5));

		Label label_rayon = new Label("Rayon:");
		gp_calcul.add(label_rayon, 0, 1);

		TextField tf_rayon = new TextField();
		gp_calcul.add(tf_rayon, 1, 1);

		Text titre = new Text("Calculs...");
		titre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 20));
		gp_calcul.add(titre, 0, 2, 2, 1);

		// Périmètre
		Text t_perimetre = new Text("Périmètre: ");
		t_perimetre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		gp_calcul.add(t_perimetre, 0, 3);

		Text perimetre = new Text("0");
		perimetre.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		gp_calcul.add(perimetre, 1, 3);

		// Surface
		Text t_surface = new Text("Surface: ");
		t_surface.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		gp_calcul.add(t_surface, 0, 4);

		Text surface = new Text("0");
		surface.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		gp_calcul.add(surface, 1, 4);

		// Volume
		Text t_volume = new Text("Volume: ");
		t_volume.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		gp_calcul.add(t_volume, 0, 5);

		Text volume = new Text("0");
		volume.setFont(Font.font("Tahoma", FontWeight.NORMAL, 14));
		gp_calcul.add(volume, 1, 5);

		Scene scene = new Scene(gp_calcul, 300, 250);
		primaryStage.setTitle("Calculs...");
		primaryStage.setScene(scene);
		primaryStage.show();

		/****** bindings ********/
		
	    perimetre.textProperty().bind(calculs.perimetreProperty().asString());
	        
	    surface.textProperty().bind(calculs.surfaceProperty().asString());
	      
	    volume.textProperty().bind(calculs.volumeProperty().asString());

	    DoubleBinding rayon = new DoubleBinding(){
	    		{
	    			super.bind(tf_rayon.textProperty());
	    		}

	    		@Override
	    		protected double computeValue() {
	    			double z=0.0;
	    			try {
	    				if(tf_rayon.textProperty().get().length() > 0) {
	    					z= Double.parseDouble(tf_rayon.textProperty().get());
	    				}
	    			}catch(NumberFormatException e) {
	    				System.err.println("Binding: " + e);
	    			}
	    			return z;
	    		}
	    	};

	    	calculs.getBille().rayonProperty().bind(rayon);
	   
	}

	public static void main(String[] args) {
		launch(args);
	}

}
