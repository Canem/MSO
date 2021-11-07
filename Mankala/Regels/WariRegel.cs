using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class WariRegel : Regel
    {
        public WariRegel()
        {
            this.zetResultaten.Add(Spel.ZetResultaat.PakStenenVoorThuiskuiltje);
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

            int[] a = { 2, 3, 4 };
        }
    }
}
