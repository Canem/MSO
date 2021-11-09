using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class EigenKuiltjeNietLeeg : Regel
    {
        public EigenKuiltjeNietLeeg()
        {
            this.zetResultaten.Add(Spel.ZetResultaat.VerderSpelen);
        }

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt)
        {
            Kuiltje kuiltje;
            if (spelerIt == Spel.Speler.Speler1)
                kuiltje = bord.s1Kuiltjes[kuiltjeIt - 1];
            else
                kuiltje = bord.s2Kuiltjes[kuiltjeIt - 1];

            if (kuiltje.GetAantalSteentjes() == 2 || kuiltje.GetAantalSteentjes() == 3)
                return true;
            else
                return false;
        }
    }
}
