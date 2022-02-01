using System;
using System.Collections.Generic;
using System.Text;

namespace Cartes
{
    class Carte
    {
        public Enseigne EnseigneCarte { get; set; }
        public Valeur ValeurCarte { get; set; }
        public Carte(Enseigne pEnseigne, Valeur pValeur)
        {
            this.EnseigneCarte = pEnseigne;
            this.ValeurCarte = pValeur;
        }
        public int Points
        {
            get
            {
                switch (this.ValeurCarte)
                {
                    case Valeur.Roi:
                    case Valeur.Dame:
                    case Valeur.Valet:
                    case Valeur.Dix:
                        return 10;
                    case Valeur.As:
                        return 1;
                    case Valeur.Deux:
                        return 2;
                    case Valeur.Trois:
                        return 3;
                    case Valeur.Quatre:
                        return 4;
                    case Valeur.Cinq:
                        return 5;
                    case Valeur.Six:
                        return 6;
                    case Valeur.Sept:
                        return 7;
                    case Valeur.Huit:
                        return 8;
                    case Valeur.Neuf:
                        return 9;
                    default:
                        return -1;
                }
            }
        }

        public override string ToString()
        {
            return "" + this.ValeurCarte + " de " + this.EnseigneCarte;
        }
    }
}
