package com.dma.controleur;

import java.util.EnumMap;
import java.util.Map;

// pattern Singleton
public class Mediateur {
	public enum Contr {MAIN,STANDARD,SCIENTIFIQUE}
	
	private static Mediateur instance = null;
	private Map<Contr,AbstractControleur> controleurs = new EnumMap<Contr,AbstractControleur>(Contr.class);
	
	private Mediateur() {
	}
	
	public static Mediateur getInstance(Contr contr, AbstractControleur controleur) {
		if(instance == null){
			instance = new Mediateur();
		}
		instance.controleurs.put(contr,controleur);
		return instance;
	}
	
	public AbstractControleur getControleur(Contr contr){
		return controleurs.get(contr);		
	}

}
