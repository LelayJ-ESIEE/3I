package com.dma.controleur;

import java.util.EnumMap;
import java.util.Map;

import com.dma.modele.AgendaModele;
import com.dma.modele.IModele;
import com.dma.modele.metier.Client;
import com.dma.modele.metier.Creneau;
import com.dma.modele.metier.Medecin;
import com.dma.modele.service.IService;
import com.dma.modele.service.Service;

// pattern Singleton
public class Mediateur {

	public enum Contr {MAIN,AGENDA,RDVJOUR,PRISERDV}
	
	private IService service;
	private IModele modele;
	
	private static Mediateur instance = null;
	private Map<Contr,AbstractControleur> controleurs = new EnumMap<Contr,AbstractControleur>(Contr.class);
	
	private Mediateur() {
		service = new Service();
		modele = new AgendaModele();
		initBase();
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

	public IService getService() {
		return service;
	}
	
	public IModele getModele(){
		return modele;
	}
	
	public void close(){
		if(service != null){
			service.close();
		}
		service = null;
	}
	
	private void initBase(){
		Medecin m1 = new Medecin();
		m1.setTitre("Mme");
		m1.setPrenom("Marie");
		m1.setNom("PELISSIER");
		m1.setVersion(1);
		m1=service.ajoutMedecin(m1);
		
		Medecin m2 = new Medecin();
		m2.setTitre("Mr");
		m2.setPrenom("Jacques");
		m2.setNom("BROMARD");
		m2.setVersion(1);
		m2=service.ajoutMedecin(m2);
		
		Medecin m3 = new Medecin();
		m3.setTitre("Mr");
		m3.setPrenom("Philippe");
		m3.setNom("JANDOT");
		m3.setVersion(1);
		m3=service.ajoutMedecin(m3);
		
		Medecin m4 = new Medecin();
		m4.setTitre("Melle");
		m4.setPrenom("Justine");
		m4.setNom("JACQUEMOT");
		m4.setVersion(1);
		m4=service.ajoutMedecin(m4);
		
		Client cl1 = new Client();
		cl1.setTitre("Mme");
		cl1.setPrenom("Christine");
		cl1.setNom("GERMAIN");
		cl1.setVersion(1);
		cl1=service.ajoutClient(cl1);
		
		Client cl2 = new Client();
		cl2.setTitre("Mr");
		cl2.setPrenom("Jules");
		cl2.setNom("MARTIN");
		cl2.setVersion(1);
		cl2=service.ajoutClient(cl2);
		
		Client cl3 = new Client();
		cl3.setTitre("Mr");
		cl3.setPrenom("Jean-Louis");
		cl3.setNom("JACQUARD");
		cl3.setVersion(1);
		cl3=service.ajoutClient(cl3);
		
		Client cl4 = new Client();
		cl4.setTitre("Melle");
		cl4.setPrenom("Brigitte");
		cl4.setNom("BISTROU");
		cl4.setVersion(1);
		cl4=service.ajoutClient(cl4);
		
		Creneau cr1 = new Creneau(0, 8, 8, 20, 1);
		Creneau cr2 = new Creneau(20, 8, 8, 40, 1);
		Creneau cr3 = new Creneau(40, 9, 8, 0, 1);
		Creneau cr4 = new Creneau(0, 9, 9, 20, 1);
		Creneau cr5 = new Creneau(20, 9, 9, 40, 1);
		Creneau cr6 = new Creneau(40, 10, 9, 0, 1);
		Creneau cr7 = new Creneau(0, 10, 10, 20, 1);
		Creneau cr8 = new Creneau(20, 10, 10, 40, 1);
		Creneau cr9 = new Creneau(40, 11, 10, 0, 1);
		Creneau cr10= new Creneau(0, 11, 11, 20, 1);
		Creneau cr11= new Creneau(20, 11, 11, 40, 1);
		Creneau cr12= new Creneau(40, 12, 11, 0, 1);
		Creneau cr13= new Creneau(0, 14, 14, 20, 1);
		Creneau cr14= new Creneau(20, 14, 14, 40, 1);
		Creneau cr15= new Creneau(40, 15, 14, 0, 1);
		Creneau cr16= new Creneau(0, 15, 15, 20, 1);
		Creneau cr17= new Creneau(20, 15, 15, 40, 1);
		Creneau cr18= new Creneau(40, 16, 15, 0, 1);
		Creneau cr19= new Creneau(0, 16, 16, 20, 1);
		Creneau cr20= new Creneau(20, 16, 16, 40, 1);
		Creneau cr21= new Creneau(40, 17, 16, 0, 1);
		Creneau cr22= new Creneau(0, 17, 17, 20, 1);
		Creneau cr23= new Creneau(20, 17, 17, 40, 1);
		Creneau cr24= new Creneau(40, 18, 17, 0, 1);

		cr1.setMedecin(m1);
		cr1=service.ajoutCreneau(cr1);
		
		cr2.setMedecin(m1);
		cr2=service.ajoutCreneau(cr2);
		
		cr3.setMedecin(m1);
		cr3=service.ajoutCreneau(cr3);
		
		cr4.setMedecin(m1);
		cr4=service.ajoutCreneau(cr4);
		
		cr5.setMedecin(m1);
		cr5=service.ajoutCreneau(cr5);
		
		cr6.setMedecin(m1);
		cr6=service.ajoutCreneau(cr6);
		
		cr7.setMedecin(m1);
		cr7=service.ajoutCreneau(cr7);
		
		cr8.setMedecin(m1);
		cr8=service.ajoutCreneau(cr8);
		
		cr9.setMedecin(m1);
		cr9=service.ajoutCreneau(cr9);
		
		cr10.setMedecin(m1);
		cr10=service.ajoutCreneau(cr10);
		
		cr11.setMedecin(m1);
		cr11=service.ajoutCreneau(cr11);
		
		cr12.setMedecin(m1);
		cr12=service.ajoutCreneau(cr12);
		
		cr13.setMedecin(m1);
		cr13=service.ajoutCreneau(cr13);
		
		cr14.setMedecin(m1);
		cr14=service.ajoutCreneau(cr14);
		
		cr15.setMedecin(m1);
		cr15=service.ajoutCreneau(cr15);
		
		cr16.setMedecin(m1);
		cr16=service.ajoutCreneau(cr16);
		
		cr17.setMedecin(m1);
		cr17=service.ajoutCreneau(cr17);
		
		cr18.setMedecin(m1);
		cr18=service.ajoutCreneau(cr18);
		
		cr19.setMedecin(m1);
		cr19=service.ajoutCreneau(cr19);
		
		cr20.setMedecin(m1);
		cr20=service.ajoutCreneau(cr20);
		
		cr21.setMedecin(m1);
		cr21=service.ajoutCreneau(cr21);
		
		cr22.setMedecin(m1);
		cr22=service.ajoutCreneau(cr22);
		
		cr23.setMedecin(m1);
		cr23=service.ajoutCreneau(cr23);
		
		cr24.setMedecin(m1);
		cr24=service.ajoutCreneau(cr24);
		
		Creneau cr30= new Creneau(0, 8, 8, 20, 1);
		Creneau cr31= new Creneau(20, 8, 8, 40, 1);
		Creneau cr32= new Creneau(40, 9, 8, 0, 1);
		Creneau cr33= new Creneau(0, 9, 9, 20, 1);
		Creneau cr34= new Creneau(20, 9, 9, 40, 1);
		Creneau cr35= new Creneau(40, 10, 9, 0, 1);
		Creneau cr36= new Creneau(0, 10, 10, 20, 1);
		Creneau cr37= new Creneau(20, 10, 10, 40, 1);
		Creneau cr38= new Creneau(40, 11, 10, 0, 1);
		Creneau cr39= new Creneau(0, 11, 11, 20, 1);
		Creneau cr40= new Creneau(20, 11, 11, 40, 1);
		Creneau cr41= new Creneau(40, 12, 11, 0, 1);
		
		cr30.setMedecin(m2);
		cr30=service.ajoutCreneau(cr30);
		
		cr31.setMedecin(m2);
		cr31=service.ajoutCreneau(cr31);
		
		cr32.setMedecin(m2);
		cr32=service.ajoutCreneau(cr32);
		
		cr33.setMedecin(m2);
		cr33=service.ajoutCreneau(cr33);
		
		cr34.setMedecin(m2);
		cr34=service.ajoutCreneau(cr34);
		
		cr35.setMedecin(m2);
		cr35=service.ajoutCreneau(cr35);
		
		cr36.setMedecin(m2);
		cr36=service.ajoutCreneau(cr36);
		
		cr37.setMedecin(m2);
		cr37=service.ajoutCreneau(cr37);
		
		cr38.setMedecin(m2);
		cr38=service.ajoutCreneau(cr38);
		
		cr39.setMedecin(m2);
		cr39=service.ajoutCreneau(cr39);
		
		cr40.setMedecin(m2);
		cr40=service.ajoutCreneau(cr40);
		
		cr41.setMedecin(m2);
		cr41=service.ajoutCreneau(cr41);
		
		Creneau cr50= new Creneau(0, 8, 8, 20, 1);
		Creneau cr51= new Creneau(20, 8, 8, 40, 1);
		Creneau cr52= new Creneau(40, 9, 8, 0, 1);
		Creneau cr53= new Creneau(0, 9, 9, 20, 1);
		Creneau cr54= new Creneau(20, 9, 9, 40, 1);
		Creneau cr55= new Creneau(40, 10, 9, 0, 1);
		Creneau cr56= new Creneau(0, 10, 10, 20, 1);
		Creneau cr57= new Creneau(20, 10, 10, 40, 1);
		Creneau cr58= new Creneau(40, 11, 10, 0, 1);
		Creneau cr59= new Creneau(0, 11, 11, 20, 1);
		
		cr50.setMedecin(m3);
		cr50=service.ajoutCreneau(cr50);
		
		cr51.setMedecin(m3);
		cr51=service.ajoutCreneau(cr51);
		
		cr52.setMedecin(m3);
		cr52=service.ajoutCreneau(cr52);
		
		cr53.setMedecin(m3);
		cr53=service.ajoutCreneau(cr53);
		
		cr54.setMedecin(m3);
		cr54=service.ajoutCreneau(cr54);
		
		cr55.setMedecin(m3);
		cr55=service.ajoutCreneau(cr55);
		
		cr56.setMedecin(m3);
		cr56=service.ajoutCreneau(cr56);
		
		cr57.setMedecin(m3);
		cr57=service.ajoutCreneau(cr57);
		
		cr58.setMedecin(m3);
		cr58=service.ajoutCreneau(cr58);
		
		cr59.setMedecin(m3);
		cr59=service.ajoutCreneau(cr59);
				
	}
		
}
