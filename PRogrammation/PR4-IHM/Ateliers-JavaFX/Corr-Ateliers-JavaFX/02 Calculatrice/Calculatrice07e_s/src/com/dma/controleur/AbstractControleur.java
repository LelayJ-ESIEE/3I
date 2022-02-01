package com.dma.controleur;

import com.dma.controleur.Mediateur.Contr;

public class AbstractControleur {
	
	private Mediateur mediateur;
	
	protected AbstractControleur(Contr contr){
		mediateur = Mediateur.getInstance(contr,this);
	}
	
	protected MainControleur getMainControleur(){
		return (MainControleur)mediateur.getControleur(Contr.MAIN);
	}
	
	protected CalculatriceStandardControleur getCalculatriceStandardControleur(){
		return (CalculatriceStandardControleur)mediateur.getControleur(Contr.STANDARD);
	}
	
	protected CalculatriceScientifiqueControleur getCalculatriceScientifiqueControleur(){
		return (CalculatriceScientifiqueControleur)mediateur.getControleur(Contr.SCIENTIFIQUE);
	}
	
	protected void afficheCalculatriceStandard(){
		getMainControleur().getMainBorderPane().setCenter(getCalculatriceStandardControleur().getAnchorPane());
	}
	
	protected void afficheCalculatriceScientifique(){	
		getMainControleur().getMainBorderPane().setCenter(getCalculatriceScientifiqueControleur().getAnchorPane());	
	}
	
}
