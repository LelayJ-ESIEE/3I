package com.dma.modele.metier;

import java.io.Serializable;
import java.util.Date;
import javax.persistence.*;

@Entity
@Table(name = "rv")
public class Rv implements Serializable {

	private static final long serialVersionUID = 1L;
	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	@Basic(optional = false)
	@Column(name = "ID")
	private Long id;

	@Basic(optional = false)
	@Column(name = "JOUR")
	@Temporal(TemporalType.DATE)
	private Date jour;

	@JoinColumn(name = "ID_CRENEAU", referencedColumnName = "ID")
	@ManyToOne(optional = false)
	private Creneau creneau;

	@JoinColumn(name = "ID_CLIENT", referencedColumnName = "ID")
	@ManyToOne(optional = false)
	private Client client;

	public Rv() {
	}

	public Rv(Long id) {
		this.id = id;
	}

	public Rv(Long id, Date jour) {
		this.id = id;
		this.jour = jour;
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public Date getJour() {
		return jour;
	}

	public void setJour(Date jour) {
		this.jour = jour;
	}

	public Client getClient() {
		return client;
	}

	public void setClient(Client client) {
		this.client = client;
	}

	public Creneau getCreneau() {
		return creneau;
	}

	public void setCreneau(Creneau creneau) {
		this.creneau = creneau;
	}

	@Override
	public int hashCode() {
		int hash = 0;
		hash += (id != null ? id.hashCode() : 0);
		return hash;
	}

	@Override
	public boolean equals(Object object) {
		// TODO: Warning - this method won't work in the case the id fields are
		// not set
		if (!(object instanceof Rv)) {
			return false;
		}
		Rv other = (Rv) object;
		if ((this.id == null && other.id != null)
				|| (this.id != null && !this.id.equals(other.id))) {
			return false;
		}
		return true;
	}

	@Override
	public String toString() {
		return String.format("Rv[%s, %s, %s]", id, creneau, client);
	}
}
