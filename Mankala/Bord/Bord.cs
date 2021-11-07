using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Bord
    {
        public Kuiltje[] s1Kuiltjes;
        public Kuiltje[] s2Kuiltjes;

        public Bord(int aantalKuiltjes, int aantalSteentjes)
        {
            s1Kuiltjes = new Kuiltje[aantalKuiltjes];
            s2Kuiltjes = new Kuiltje[aantalKuiltjes];

            for (int i = 0; i < s1Kuiltjes.Length; i++)
            {
                Kuiltje k1 = new Speelkuiltje(aantalSteentjes);
                Kuiltje k2 = new Speelkuiltje(aantalSteentjes);

                s1Kuiltjes[i] = k1;
                s2Kuiltjes[i] = k2;
            }
        }

        public void PrintBord(Spel.Speler huidigeSpeler)
        {
            // Print kuiltje info.
            Console.Write("Kuiltje#  -   ");
            for (int i = 0; i < s1Kuiltjes.Length; i++)
                Console.Write(" " + (i+1) + " ");
            Console.WriteLine();

            // Print speler 2s bord.
            Console.Write("Speler 2  -  [");
            foreach (Kuiltje k in s2Kuiltjes)
                k.printKuiltje();
            Console.Write("]");
            if (huidigeSpeler == Spel.Speler.Speler2)
                Console.Write("  <---");
            Console.WriteLine();

            // Print speler 1s bord.
            Console.Write("Speler 1  -  [");
            foreach (Kuiltje k in s1Kuiltjes)
                k.printKuiltje();
            Console.Write("]");
            if (huidigeSpeler == Spel.Speler.Speler1)
                Console.Write("  <---");
            Console.WriteLine();
        }
    }
}
