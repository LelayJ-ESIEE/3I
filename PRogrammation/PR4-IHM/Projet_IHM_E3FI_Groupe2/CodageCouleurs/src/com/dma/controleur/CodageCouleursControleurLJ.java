package com.dma.controleur;

import com.dma.modele.Modele;

import javafx.fxml.FXML;
import javafx.scene.control.Button;
import javafx.scene.control.Label;
import javafx.scene.control.TextField;
import javafx.scene.layout.BorderPane;
import javafx.util.converter.NumberStringConverter;

public class CodageCouleursControleurLJ
{
	private Modele modele;
	
    @FXML
    private BorderPane boderPane;

    @FXML
    private TextField tf_dec;
    @FXML
    private TextField tf_flo;
    @FXML
    private TextField tf_hex;

    @FXML
    private Label label_error;
    @FXML
    private Button b_color;

    @FXML
    private Button b_0;
    @FXML
    private Button b_F;
    @FXML
    private Button b_E;
    @FXML
    private Button b_D;
    @FXML
    private Button b_C;
    @FXML
    private Button b_B;
    @FXML
    private Button b_A;
    @FXML
    private Button b_9;
    @FXML
    private Button b_8;
    @FXML
    private Button b_7;
    @FXML
    private Button b_6;
    @FXML
    private Button b_5;
    @FXML
    private Button b_4;
    @FXML
    private Button b_3;
    @FXML
    private Button b_2;
    @FXML
    private Button b_1;
    
    @FXML
    private Button b_backspace;
    @FXML
    private Button b_init;
    
    @FXML private void initialize()
	{
    	// Create modele
		this.modele = new Modele();
		
		// Actions
		b_0.setOnAction(evt -> text_append("0"));
		b_1.setOnAction(evt -> text_append("1"));
		b_2.setOnAction(evt -> text_append("2"));
		b_3.setOnAction(evt -> text_append("3"));
		b_4.setOnAction(evt -> text_append("4"));
		b_5.setOnAction(evt -> text_append("5"));
		b_6.setOnAction(evt -> text_append("6"));
		b_7.setOnAction(evt -> text_append("7"));
		b_8.setOnAction(evt -> text_append("8"));
		b_9.setOnAction(evt -> text_append("9"));
		b_A.setOnAction(evt -> text_append("A"));
		b_B.setOnAction(evt -> text_append("B"));
		b_C.setOnAction(evt -> text_append("C"));
		b_D.setOnAction(evt -> text_append("D"));
		b_E.setOnAction(evt -> text_append("E"));
		b_F.setOnAction(evt -> text_append("F"));
		
		b_backspace.setOnAction(evt -> supprDernierCaractere());
		
		b_init.setOnAction(evt -> init_state());
		
	}

	private void init_state()
	{
		b_color.setStyle("-fx-background-color: #000000FF;");
		modele.reinit();
		tf_dec.setText("dec:");
		tf_flo.setText("flo:");
		tf_hex.setText("hex:");
	}

	private void supprDernierCaractere()
	{
		if(tf_dec.getText().length() > 5) {
			String s = tf_dec.getText();
			s = new StringBuilder(s).deleteCharAt(s.length()-1).toString();
			tf_dec.setText(s);
		}
	}

	private void text_append(String c)
	{
		
		String s = tf_dec.getText();
		if(s.length()<16){
			if(s.length()%4 == 0) {
				c = " " + c;
			}
			s = new StringBuilder(s).append(c).toString();
			tf_dec.setText(s);
		}
	}
}
