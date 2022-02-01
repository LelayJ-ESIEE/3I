
package modele;

import javafx.beans.property.BooleanProperty;
import javafx.beans.property.SimpleBooleanProperty;
import javafx.beans.property.SimpleStringProperty;
import javafx.beans.property.StringProperty;

public class User {
    private StringProperty pseudo;
    private StringProperty motDePasse;
    private BooleanProperty sexe;
    private StringProperty nom;
    private StringProperty prenom;
    private StringProperty naissance;
   
    public User(){
       this("","",false,"","","01/01/1980");    
    }
       
    public User(String pseudo,String motDePasse,boolean sexe,String nom,String prenom,String naissance){
        this.pseudo=new SimpleStringProperty(pseudo);
        this.motDePasse=new SimpleStringProperty(motDePasse);
        this.sexe=new SimpleBooleanProperty(sexe);
        this.nom=new SimpleStringProperty(nom);
        this.prenom=new SimpleStringProperty(prenom);
        this.naissance=new SimpleStringProperty(naissance);  
    }
    
    //===================================================
    
    public String getPseudo() {
        return pseudo.get();
    }

    public void setPseudo(String pseudo) {
        this.pseudo.set(pseudo);
    }

    public StringProperty pseudoProperty() {
        return pseudo;
    }
    
    //===================================================    
    
    public String getMotDePasse() {
        return motDePasse.get();
    }

    public void setMotDePasse(String motDePasse) {
        this.motDePasse.set(motDePasse);
    }

    public StringProperty motDePasseProperty() {
        return motDePasse;
    }
    
    //===================================================
    
    public boolean isSexe() {
        return sexe.get();
    }

    public void setSexe(boolean sexe) {
        this.sexe.set(sexe);
    }

    public BooleanProperty sexeProperty() {
        return sexe;
    }
    
    //===================================================
    
    public String getNom() {
        return nom.get();
    }

    public void setNom(String nom) {
        this.nom.set(nom);
    }
    
    public StringProperty nomProperty() {
        return nom;
    }
    
    //===================================================
    
    public String getPrenom() {
        return prenom.get();
    }

    public void setPrenom(String prenom) {
        this.prenom.set(prenom);
    }

    public StringProperty prenomProperty() {
        return prenom;
    }
    
    //===================================================
    
    public String getNaissance() {
        return naissance.get();
    }

    public void setNaissance(String naissance) {
        this.naissance.set(naissance);
    }

    public StringProperty naissanceProperty() {
        return naissance;
    }
    
    //===================================================
    
    @Override public String toString(){
        return pseudo.get() + " " + motDePasse.get()+ " " + sexe.get() + " " + nom.get() + " " + prenom.get()+ " " + naissance.get();
    }
    
    public boolean valide(){
        if(pseudo != null && pseudo.get().length() < 4){
            return false;
        }
        if(motDePasse != null && motDePasse.get().length() < 6){
            return false;
        }
        if(nom != null && nom.get().length() < 4){
            return false;
        }
        if(prenom != null && prenom.get().length() < 4){
            return false;
        }
        if(! naissance.get().trim().matches("\\d{2}/\\d{2}/\\d{4}")){
            return false;
        }
        return true;
    } 
}
