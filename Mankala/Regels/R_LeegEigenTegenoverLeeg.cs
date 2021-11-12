using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class R_LeegEigenTegenoverLeeg : Regel
    {
        public R_LeegEigenTegenoverLeeg()
        {
            naam = "leeg eigen kuiltje tegenover leeg kuiltje tegenstander.";
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        // Checkt of het laaste steentje terecht komt in een eigen kuiltje dat leeg is, en het kuiltje tegenover leeg is.
        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            // Excludeer thuiskuiltjes, kuiltjes van de tegenstander en niet-lege kuiltjes.
            if (laatsteKuiltje.isThuisKuiltje || spelerIt != huidigeSpeler || laatsteKuiltje.GetAantalSteentjes() != 0)
                return false;

            // Verkrijg tegenoverliggend kuiltje.
            Kuiltje kuiltjeTegen;
            if (huidigeSpeler == Spel.Speler.Speler1)
                kuiltjeTegen = bord.s2Kuiltjes[kuiltjeIt - 1];
            else
                kuiltjeTegen = bord.s1Kuiltjes[kuiltjeIt - 1];

            // Tegenoverliggend kuiltje is leeg.
            if (kuiltjeTegen.GetAantalSteentjes() == 0)
                return true;
            else
                return false;
        }

    }
}
