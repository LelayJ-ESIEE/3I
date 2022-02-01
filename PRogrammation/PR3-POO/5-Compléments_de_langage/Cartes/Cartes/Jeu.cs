using System;
using System.Collections.Generic;
using System.Text;

namespace Cartes
{
    class Jeu
    {
        private Carte[] cartes;
        public Carte[] Cartes
        {
            get
            {
                return cartes;
            }
        }

        public Jeu()
        {
            this.cartes = new Carte[52];
            int i = 0;
            foreach (Enseigne e in Enum.GetValues(typeof(Enseigne)))
            {
                foreach (Valeur v in Enum.GetValues(typeof(Valeur)))
                {
                    this.cartes[i] = new Carte(e, v);
                    i += 1;
                }
            }
        }
    }
}
