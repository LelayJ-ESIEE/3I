package com.dma.modele;

import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import javax.swing.Timer;
import javafx.beans.property.BooleanProperty;
import javafx.beans.property.IntegerProperty;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleIntegerProperty;
import javafx.scene.media.AudioClip;

public class MinuteurModeleXX implements ActionListener  {
	private Timer timer;
	private IntegerProperty duree;
	private BooleanProperty fin;
	private AudioClip sonnerie;
	
	public MinuteurModeleXX() {		
		timer = new Timer(1000, this);
		duree = new SimpleIntegerProperty(0);
		fin = new SimpleBooleanProperty(false);
		sonnerie = new AudioClip(this.getClass().getResource("/resources/sons/simple-office-tone.mp3").toExternalForm());
	}
	
	public IntegerProperty dureeProperty() {
		return duree;
	}
	
	public BooleanProperty finProperty() {
		return fin;
	}
	
	public void reinit() {
		duree.setValue(0);
		fin.setValue(false);
		if(timer !=null && timer.isRunning()) {
			timer.stop();
		}
		if(sonnerie.isPlaying()) {
			sonnerie.stop();
		}
	}
	
	public void depart() {
		if(!timer.isRunning()) {
			timer.start();
			fin.setValue(true);
		}
	}
	
	@Override
	public void actionPerformed(ActionEvent arg0) {
		if(duree.getValue() > 0) {			
			duree.setValue(duree.getValue() - 1);
		}else {
			timer.stop();
			sonnerie();
		}
		System.out.println("duree restante: "+duree.getValue());
	}
	
	private void sonnerie() {
		if(sonnerie != null) {
			System.out.println("sonnerie....");
			sonnerie.play();
			System.out.println("fin de sonnerie....");
		}	
	}		
}
