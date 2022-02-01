using System;
using System.Collections.Generic;
using System.Text;

namespace duree
{
    class Duree
    {
        private int dureeSeconde;
        
        public Duree(int duree)
        {
            this.DureeSeconde = duree;
        }

        public Duree() : this(0)
        { }

        public int DureeSeconde
        {
            get
            {
                return dureeSeconde;
            }

            set
            {
                if (value >= 0)
                    this.dureeSeconde = value;
            }
        }
        
        public int DureeMinute
        {
            get
            {
                if (this.DureeSeconde % 60 > 0)
                    return this.DureeSeconde/60 + 1;
                else
                    return this.DureeSeconde/60;
            }

            set
            {
                this.DureeSeconde = value * 60;
            }
        }
    }
}
