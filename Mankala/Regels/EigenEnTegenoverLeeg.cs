using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class EigenEnTegenoverLeeg : Regel
    {
        public EigenEnTegenoverLeeg()
        {
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler)
        {

            //Niet in eigen kuiltje gekomen
            if (spelerIt != huidigeSpeler)
                return false;


            Kuiltje kuiltje1 = bord.s2Kuiltjes[kuiltjeIt - 1];
            Kuiltje kuiltje2 = bord.s1Kuiltjes[kuiltjeIt - 1];

            //Eigen kuiltje en tegenover is leeg
            if (kuiltje1.GetAantalSteentjes() == 0 && kuiltje2.GetAantalSteentjes() == 0)
                return true;
            else
                return false;
        }

    }
}
