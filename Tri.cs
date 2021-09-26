using System;
using System.Collections.Generic;
using System.Text;

namespace TPB2S1Revision
{
    class Tri
    {
        public int[] tab {get;set;}

        public Tri(int[] tab)
        {
            this.tab = tab;
        }

        public int[] TriSelection()
        {
            int[] t = new int[tab.Length];
            System.Array.Copy(tab, t, tab.Length);

            int i, min, j, x;
            for (i = 0; i < t.Length - 1; i++)
            {
                min = i;
                for (j = i + 1; j < t.Length; j++)
                    if (t[j] < t[min])
                        min = j;
                if (min != i)
                {
                    x = t[i];
                    t[i] = t[min];
                    t[min] = x;
                }
            }

            return t;
        }

        public int[] TriBulle()
        {
            int[] t = new int[tab.Length];
            System.Array.Copy(tab, t, tab.Length);

            for (int i = 0; i < tab.Length - 1; ++i)
            {
                for (int j = i + 1; j < tab.Length; ++j)
                {
                    if (tab[j] < tab[i])
                    {
                        Permuter(ref tab[i], ref tab[j]);
                    }      
                }
            }
            return t;
        }

        void Permuter(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
