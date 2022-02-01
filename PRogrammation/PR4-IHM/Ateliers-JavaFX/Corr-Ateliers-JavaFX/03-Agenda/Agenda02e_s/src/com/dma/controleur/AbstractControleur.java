package com.dma.controleur;

import java.time.LocalDate;
import java.time.ZoneId;
import java.util.Date;

import javafx.scene.layout.Pane;

import com.dma.modele.IModele;
import com.dma.modele.service.IService;
import com.dma.controleur.Mediateur.Contr;

public abstract class AbstractControleur {
	
	private Mediateur mediateur;
	
	protected AbstractControleur(Contr contr){
		mediateur = Mediateur.getInstance(contr,this);
		System.out.println(contr);
	}
	
	public void close(){
		if(mediateur != null){
			mediateur.close();
		}
		mediateur=null;
	}
	
	private MainControleur getMainControleur(){
		return (MainControleur)mediateur.getControleur(Contr.MAIN);
	}
	
	public abstract void actualiser();
	
	public abstract Pane getPane();
	
	protected void afficheAgenda(){
		mediateur.getControleur(Contr.AGENDA).actualiser();
		getMainControleur().getMainBorderPane().setCenter(mediateur.getControleur(Contr.AGENDA).getPane());
	}
	
	protected void afficheRdvJour(){	
		mediateur.getControleur(Contr.RDVJOUR).actualiser();
		getMainControleur().getMainBorderPane().setCenter(mediateur.getControleur(Contr.RDVJOUR).getPane());	
	}
	
	protected void affichePriseRdv(){	
		mediateur.getControleur(Contr.PRISERDV).actualiser();
		getMainControleur().getMainBorderPane().setCenter(mediateur.getControleur(Contr.PRISERDV).getPane());	
	}
	
	protected Date toDate(LocalDate localDate){
		return Date.from(localDate.atStartOfDay(ZoneId.systemDefault()).toInstant());
	}
	
	protected IService getService(){
		return mediateur.getService();
	}
	
	protected IModele getModele(){
		return mediateur.getModele();
	}
		
}
