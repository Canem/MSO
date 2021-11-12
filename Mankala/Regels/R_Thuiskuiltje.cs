using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class R_Thuiskuiltje : Regel
    {
        public R_Thuiskuiltje()
        {
            naam = "thuiskuiltje.";
            this.zetResultaten.Add(Spel.ZetResultaat.VerderSpelen);
        }

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            if((huidigeSpeler == Spel.Speler.Speler1 && laatsteKuiltje.Equals(bord.s1VerzamelKuiltje)) 
                || (huidigeSpeler == Spel.Speler.Speler2 && laatsteKuiltje.Equals(bord.s2VerzamelKuiltje)))
            {
                return true;
            } else
                return false;
        }
    }
}
