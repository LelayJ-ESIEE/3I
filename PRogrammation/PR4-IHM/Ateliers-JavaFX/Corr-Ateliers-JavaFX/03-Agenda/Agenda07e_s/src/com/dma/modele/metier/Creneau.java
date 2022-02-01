package com.dma.modele.metier;

import java.io.Serializable;
import javax.persistence.*;

@Entity
@Table(name = "creneaux")
public class Creneau implements Serializable {

  private static final long serialVersionUID = 1L;
  @Id
  @GeneratedValue(strategy = GenerationType.IDENTITY)
  @Basic(optional = false)
  @Column(name = "ID")
  private Long id;
  
  @Basic(optional = false)
  @Column(name = "MDEBUT")
  private int mdebut;
  
  @Basic(optional = false)
  @Column(name = "HFIN")
  private int hfin;
  
  @Basic(optional = false)
  @Column(name = "HDEBUT")
  private int hdebut;
  
  @Basic(optional = false)
  @Column(name = "MFIN")
  private int mfin;
  
  @Basic(optional = false)
  @Column(name = "VERSION")
  @Version
  private int version;
  
  @JoinColumn(name = "ID_MEDECIN", referencedColumnName = "ID")
  @ManyToOne(optional = false)
  private Medecin medecin;

  // constructeurs
  public Creneau() {
  }

  public Creneau(Long id) {
    this.id = id;
  }

  public Creneau(Long id, int mdebut, int hfin, int hdebut, int mfin, int version) {
    this.id = id;
    this.mdebut = mdebut;
    this.hfin = hfin;
    this.hdebut = hdebut;
    this.mfin = mfin;
    this.version = version;
  }
  
  public Creneau(int mdebut, int hfin, int hdebut, int mfin, int version) {
	    this.mdebut = mdebut;
	    this.hfin = hfin;
	    this.hdebut = hdebut;
	    this.mfin = mfin;
	    this.version = version;
  }

  // getters et setters
  public Long getId() {
    return id;
  }

  public void setId(Long id) {
    this.id = id;
  }

  public int getMdebut() {
    return mdebut;
  }

  public void setMdebut(int mdebut) {
    this.mdebut = mdebut;
  }

  public int getHfin() {
    return hfin;
  }

  public void setHfin(int hfin) {
    this.hfin = hfin;
  }

  public int getHdebut() {
    return hdebut;
  }

  public void setHdebut(int hdebut) {
    this.hdebut = hdebut;
  }

  public int getMfin() {
    return mfin;
  }

  public void setMfin(int mfin) {
    this.mfin = mfin;
  }

  public int getVersion() {
    return version;
  }

  public void setVersion(int version) {
    this.version = version;
  }

  public Medecin getMedecin() {
    return medecin;
  }

  public void setMedecin(Medecin medecin) {
    this.medecin = medecin;
  }

 
  @Override
  public int hashCode() {
    int hash = 0;
    hash += (id != null ? id.hashCode() : 0);
    return hash;
  }

  @Override
  public boolean equals(Object object) {
    // TODO: Warning - this method won't work in the case the id fields are not set
    if (!(object instanceof Creneau)) {
      return false;
    }
    Creneau other = (Creneau) object;
    if ((this.id == null && other.id != null) || (this.id != null && !this.id.equals(other.id))) {
      return false;
    }
    return true;
  }

  @Override
  public String toString() {
    return String.format(" %02dh%02d - %02dh%02d",hdebut, mdebut, hfin, mfin);
  }
}
