using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class R_LeegEigenTegenoverGevuld : Regel
    {
        public R_LeegEigenTegenoverGevuld()
        {
            naam = "leeg eigen kuiltje tegenover gevuld kuiltje tegenstander.";
            this.zetResultaten.Add(Spel.ZetResultaat.PakStenenTegenover);
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        // Checkt of het laaste steentje terecht komt in een eigen kuiltje dat leeg is, en het kuiltje tegenover gevuld is.
        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            // Excludeer thuiskuiltjes, kuiltjes van de tegenstander en niet-lege kuiltjes.
            if (laatsteKuiltje.isThuisKuiltje || spelerIt != huidigeSpeler || laatsteKuiltje.GetAantalSteentjes() != 0)
                return false;

            // Verkrijg tegenoverliggend kuiltje.
            Kuiltje kuiltjeTegen;
            if(huidigeSpeler == Spel.Speler.Speler1)
                kuiltjeTegen = bord.s2Kuiltjes[kuiltjeIt - 1];
            else
                kuiltjeTegen = bord.s1Kuiltjes[kuiltjeIt - 1];

            // Tegenoverliggend kuiltje is gevuld.
            if (kuiltjeTegen.GetAantalSteentjes() != 0)
                return true;
            else
                return false;
        }
    }
}
