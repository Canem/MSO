using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Spel
    {
        public enum SpelVariant { Mankala, Wari }

        public enum Speler { Speler1, Speler2 }
        public Speler huidigeSpeler;
        public SpelVariant huidigeVariant;

        //Regel[] regels;

        public void InitialiseerSpel(int aantalKuiltjes, int aantalSteentjes)
        {
            huidigeSpeler = Speler.Speler1;
        }
        
    }
}
