package com.dma.modele.metier;

import java.io.Serializable;
import javax.persistence.*;

@Entity
@Table(name = "medecins")
public class Medecin extends Personne implements Serializable {
  private static final long serialVersionUID = 1L;

  // constructeurs
  public Medecin() {
    super();
  }

  public Medecin(Long id) {
    super(id);
  }

  public Medecin(Long id, String titre, String nom, int version, String prenom) {
    super(id,titre,nom,version,prenom);
  }
  
  @Override
  public int hashCode() {
    int hash = 0;
    hash += (getId() != null ? getId().hashCode() : 0);
    return hash;
  }

  @Override
  public boolean equals(Object object) {
    // TODO: Warning - this method won't work in the case the id fields are not set
    if (!(object instanceof Medecin)) {
      return false;
    }
    Medecin other = (Medecin) object;
    if ((this.getId() == null && other.getId() != null) || (this.getId() != null && !this.getId().equals(other.getId()))) {
      return false;
    }
    return true;
  }

  @Override
  public String toString() {
    return String.format("%s %s %s", getTitre(), getPrenom(), getNom());
  }
  
}
