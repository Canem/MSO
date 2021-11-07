using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    abstract class Kuiltje
    {
        public int aantalSteentjes;
        // Speler ..

        public void VoegToe(int aantal)
        {
            aantalSteentjes += aantal;
        }

        // Is mogelijk onnodig.
        public void NeemWeg(int aantal)
        {
            if (aantal >= aantalSteentjes)
                aantalSteentjes = 0;
            else
                aantalSteentjes -= aantal;
        }

        public int Leeg()
        {
            int aantalSteentjes = GetAantalSteentjes();
            this.aantalSteentjes = 0;
            return aantalSteentjes;
        }

        public void printKuiltje()
        {
            Console.Write("(" + aantalSteentjes + ")");
        }

        public int GetAantalSteentjes()
        {
            return aantalSteentjes;
        }

    }
}
