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
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        //Regel geld als steentje bij de tegenstander eindigd in vakje met 2 of 3 stenen
        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            Kuiltje kuiltje;
            //Als endigd in op eigen kant geld de regel niet
            if (spelerIt == huidigeSpeler)
                return false;

            //Kuiltje waar de steen eindigd
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
