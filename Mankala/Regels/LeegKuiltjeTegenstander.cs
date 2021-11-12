using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class LeegKuiltjeTegenstander : Regel
    {
        public LeegKuiltjeTegenstander()
        {
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            Kuiltje kuiltje;

            //In eigenkuiltje gekomen
            if (spelerIt == huidigeSpeler)
                return false;

            if (spelerIt == Spel.Speler.Speler1)
                kuiltje = bord.s2Kuiltjes[kuiltjeIt - 1];
            else
                kuiltje = bord.s1Kuiltjes[kuiltjeIt - 1];

            //Kuiltje van de tegenstander is leeg
            if (kuiltje.GetAantalSteentjes() == 0)
                return true;
            else
                return false;
        }
    }
}
