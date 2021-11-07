using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    abstract class Kuiltje
    {
        protected int aantalSteentjes;

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
            if (aantalSteentjes < 10)
                Console.Write("( " + aantalSteentjes + ")");
            else
                Console.Write("(" + aantalSteentjes + ")");
        }

        public int GetAantalSteentjes()
        {
            return aantalSteentjes;
        }

    }
}
