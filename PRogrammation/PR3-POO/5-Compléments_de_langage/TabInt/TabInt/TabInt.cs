using System;
using System.Collections.Generic;
using System.Text;

namespace TabInt
{
    class TabInt
    {
        public int[] tab;
        public int IStart { get; private set; }
        public int Length
        {
            get { return tab.Length; }
        }
        public TabInt(int len, int start)
        {
            this.tab = new int[len];
            this.IStart = start;
        }
        public int this[int n]
        {
            get { return this.tab[n - this.IStart]; }
            set { this.tab[n - this.IStart] = value; }
        }

        public void SetAll(int start, params int[] t)
        {
            for (int i = 0; i < t.Length && i + start < this.Length; i++)
                this[i + start] = t[i];
        }
    }
}
