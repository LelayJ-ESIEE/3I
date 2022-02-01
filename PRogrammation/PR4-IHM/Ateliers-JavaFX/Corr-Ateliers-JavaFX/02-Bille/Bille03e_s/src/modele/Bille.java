
package modele;

import javafx.beans.property.DoubleProperty;
import javafx.beans.property.SimpleDoubleProperty;

public class Bille {
    
    private DoubleProperty rayon;
    
    public Bille(){
       this.rayon = new SimpleDoubleProperty(0);
    }
    
    public Bille(double rayon){
       this.rayon = new SimpleDoubleProperty(rayon);
    }
    
    public Bille(String srayon) throws NumberFormatException{
       this.rayon = new SimpleDoubleProperty(Double.valueOf(srayon));   
    }

    public double getRayon() {
        return rayon.get();
    }

    public void setRayon(double rayon) {
        this.rayon.set(rayon);
    }
    
    public DoubleProperty rayonProperty(){
        return rayon;
    }
 
    @Override
    public String toString() {
        return "Bille{" + "rayon=" + rayon + '}';
    }
      
}
