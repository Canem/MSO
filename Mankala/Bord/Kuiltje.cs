using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Kuiltje
    {
        protected int aantalSteentjes;
        public bool isThuisKuiltje;

        public Kuiltje(int aantalSteentjes, bool isThuisKuiltje = false)
        {
            this.aantalSteentjes = aantalSteentjes;
            this.isThuisKuiltje = isThuisKuiltje;
        }

        public void VoegToe(int aantal)
        {
            aantalSteentjes += aantal;
        }

        public int Leeg()
        {
            int aantalSteentjes = GetAantalSteentjes();
            this.aantalSteentjes = 0;
            return aantalSteentjes;
        }

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

        public int GetAantalSteentjes()
        {
            return aantalSteentjes;
        }

    }
}
