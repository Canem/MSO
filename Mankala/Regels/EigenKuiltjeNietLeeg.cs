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

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler)
        {
            Kuiltje kuiltje;

            //Steentje niet in een van eigenkuiltjes gekomen
            if (spelerIt != huidigeSpeler)
                return false;

            if (spelerIt == Spel.Speler.Speler1)
                kuiltje = bord.s1Kuiltjes[kuiltjeIt - 1];
            else
                kuiltje = bord.s2Kuiltjes[kuiltjeIt - 1];

            //Als eigenkuiltje niet leeg is ga door
            if (kuiltje.GetAantalSteentjes() != 0)
                return true;
            else
                return false;
        }
    }
}
