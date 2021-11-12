using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class EigenLeegTegenNiet : Regel
    {
        public EigenLeegTegenNiet()
        {
            this.zetResultaten.Add(Spel.ZetResultaat.PakStenenTegenOverThuis);
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            Kuiltje kuiltjeEigen;
            Kuiltje kuiltjeTegen;

            //Niet in eigen kuiltje gekomen
            if (spelerIt != huidigeSpeler)
                return false;

            if(spelerIt == Spel.Speler.Speler1)
            {
                kuiltjeEigen = bord.s1Kuiltjes[kuiltjeIt - 1];
                kuiltjeTegen = bord.s2Kuiltjes[kuiltjeIt - 1];
            }
            else
            {
                kuiltjeEigen = bord.s2Kuiltjes[kuiltjeIt - 1];
                kuiltjeTegen = bord.s1Kuiltjes[kuiltjeIt - 1];
            }

            //Eigen kuiltje en tegenover is leeg
            if (kuiltjeEigen.GetAantalSteentjes() == 0 && kuiltjeTegen.GetAantalSteentjes() != 0)
                return true;
            else
                return false;
        }
    }
}
