
package modele;

import javafx.beans.property.DoubleProperty;
import javafx.beans.property.SimpleDoubleProperty;

public class Calculs {
    private Bille bille;
    private DoubleProperty perimetre;
    private DoubleProperty surface;
    private DoubleProperty volume;
    
    public Calculs(){
    	this(new Bille());
    }
    
    public Calculs(Bille bille){
    	perimetre=new SimpleDoubleProperty(0);
        surface=new SimpleDoubleProperty(0);
        volume=new SimpleDoubleProperty(0);
      	setBille(bille);
    }
    public void setBille(Bille bille){
        this.bille=bille; 
        calculPerimetre();
        calculSurface();
        calculVolume();
    }
         
    public Bille getBille(){
        return bille;
    }
    
    public DoubleProperty perimetreProperty(){
        return perimetre;
    }
    
    public DoubleProperty surfaceProperty(){
        return surface;
    }
    
    public DoubleProperty volumeProperty(){
        return volume;
    }
    
    private void calculPerimetre(){
    	// A COMPLETER par un calcul avec binding de bas niveau sur rayon
    }
    
    
    private void calculSurface(){
    	// A COMPLETER par un calcul avec binding de bas niveau sur rayon
    } 
    
    private void calculVolume(){
    	// A COMPLETER par un calcul avec binding de bas niveau sur rayon
    }   
 }