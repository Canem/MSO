using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Bord
    {
        Kuiltje[] kuiltjes;

        public Bord(int aantalKuiltjes, int aantalSteentjes)
        {
            kuiltjes = new Kuiltje[aantalKuiltjes * 2];
            for (int i = 0; i < kuiltjes.Length; i++)
            {
                Kuiltje kuiltje = new Speelkuiltje();
                kuiltjes[i] = kuiltje;
            }
        }

        public void GeefWeer()
        {
            Console.Write("[");
            foreach (Kuiltje k in kuiltjes)
            {
                k.printKuiltje();
            }
            Console.WriteLine("]");
        }
    }
}
