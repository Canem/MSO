using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class R_WariRegel : Regel
    {
        public R_WariRegel()
        {
            naam = "kuiltje tegenstander met 1 of 2 andere steentjes.";
            this.zetResultaten.Add(Spel.ZetResultaat.PakStenenVoorThuiskuiltje);
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        //Regel geld als steentje bij de tegenstander eindigd in vakje met 2 of 3 stenen
        public override bool CheckTrigger(Bord bord, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            // Verkrijg iteraties.
            Spel.Speler spelerIt = bord.GetSpelerIt(laatsteKuiltje);
            int kuiltjeIt = bord.GetKuiltjeIt(laatsteKuiltje);

            Kuiltje kuiltje;

            // Als een steentje op de eigen kant eindigt, geldt deze regel niet.
            if (spelerIt == huidigeSpeler)
                return false;

            // Kuiltje waar de steen eindigt
            if (spelerIt == Spel.Speler.Speler1)
                kuiltje = bord.s1Kuiltjes[kuiltjeIt - 1];
            else
                kuiltje = bord.s2Kuiltjes[kuiltjeIt - 1];

            // Als dit kuiltje de juiste aantal steentjes bevat, geef aan dat de regel is getriggerd.
            if (kuiltje.GetAantalSteentjes() == 2 || kuiltje.GetAantalSteentjes() == 3)
                return true;
            else
                return false;
        }
    }
}
