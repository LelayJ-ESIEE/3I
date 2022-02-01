
package modele;

import javafx.beans.binding.DoubleBinding;
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
        DoubleBinding perim = new DoubleBinding(){
            {
                super.bind(bille.rayonProperty());
            }

            @Override
            protected double computeValue() {
               return bille.rayonProperty().get()* Math.PI * 2;
            }
        };
        perimetre.bind(perim);
    }
    
    private void calculSurface(){
        DoubleBinding surf = new DoubleBinding(){
            {
                super.bind(bille.rayonProperty());
            }

            @Override
            protected double computeValue() {
               return bille.rayonProperty().get()* bille.rayonProperty().get() *Math.PI * 4;
            }
        };
        surface.bind(surf);
    } 
    
    private void calculVolume(){
        DoubleBinding vol = new DoubleBinding(){
            {
                super.bind(bille.rayonProperty());
            }

            @Override
            protected double computeValue() {
               return bille.rayonProperty().get()* bille.rayonProperty().get() * bille.rayonProperty().get() * Math.PI * 4 / 3;
            }
        };
        volume.bind(vol);
    }   
 }