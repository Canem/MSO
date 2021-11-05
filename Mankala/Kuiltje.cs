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
        // Speler ..

        public void VoegToe(int aantal)
        {
            aantalSteentjes += aantal;
        }

        public void NeemWeg(int aantal)
        {
            if (aantal >= aantalSteentjes)
                aantalSteentjes = 0;
            else
                aantalSteentjes -= aantal;
        }

        public int GetAantalSteentjes()
        {
            return aantalSteentjes;
        }

    }
}
