using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Kuiltje
    {
        // Het aantal steentjes dat het kuiltje momenteel bevat.
        protected int aantalSteentjes;

        // geeft aan of dit kuiltje dient als thuiskuiltje. true = ja, false = nee
        public bool isThuisKuiltje;

        public Kuiltje(int aantalSteentjes, bool isThuisKuiltje = false)
        {
            this.aantalSteentjes = aantalSteentjes;
            this.isThuisKuiltje = isThuisKuiltje;
        }

        // Voeg steentjes toe aan dit kuiltje.
        public void VoegToe(int aantal)
        {
            aantalSteentjes += aantal;
        }

        // Leeg het kuiltje en return het aantal steentjes dat het het kuiltje zijn gehaald.
        public int Leeg()
        {
            int aantalSteentjes = GetAantalSteentjes();
            this.aantalSteentjes = 0;
            return aantalSteentjes;
        }

        // Geef het kuiltje weer als string output.
        public string PrintKuiltje()
        {
            if (!isThuisKuiltje)
            {
                if (aantalSteentjes < 10)
                    return ("( " + aantalSteentjes + ")");
                else
                    return ("(" + aantalSteentjes + ")");
            }
            else
            {
                if (aantalSteentjes < 10)
                    return ("{ " + aantalSteentjes + "}");
                else
                    return ("{" + aantalSteentjes + "}");
            }
        }

        // Verkrijg het aantal steentjes dat zich momenteel in het kuiltje bevinden.
        public int GetAantalSteentjes()
        {
            return aantalSteentjes;
        }

    }
}
