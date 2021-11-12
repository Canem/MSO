using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class R_GevuldKuiltje : Regel
    {
        public R_GevuldKuiltje()
        {
            naam = "gevuld kuiltje.";
            this.zetResultaten.Add(Spel.ZetResultaat.DoorSpreiden);
        }

        // Check of het laatste steentje in een kuiltje terecht is gekomen dat niet leeg is.
        // Verder wordt gecheckt of dit geen thuiskuiltje is om niet te clashen met de thuiskuiltje regel.
        public override bool CheckTrigger(Bord bord, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            if (laatsteKuiltje.GetAantalSteentjes() > 1 && !laatsteKuiltje.isThuisKuiltje)
                return true;
            else
                return false;
        }
    }
}
