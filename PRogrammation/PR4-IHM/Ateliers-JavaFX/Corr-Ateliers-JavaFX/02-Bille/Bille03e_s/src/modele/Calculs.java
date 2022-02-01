
package modele;

import javafx.beans.binding.Bindings;
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
        perimetre.bind(Bindings.multiply(bille.rayonProperty(),2*Math.PI));
    }
    
    private void calculSurface(){   
        surface.bind(Bindings.multiply(bille.rayonProperty(),bille.rayonProperty()).
        		multiply(Math.PI));
    } 
    
    private void calculVolume(){
        volume.bind(Bindings.multiply(bille.rayonProperty(),bille.rayonProperty()).
        		multiply(bille.rayonProperty()).multiply(Math.PI * 4 / 3));
    }   
 }