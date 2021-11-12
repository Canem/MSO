using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class R_LeegKuiltjeTegenstander : Regel
    {
        public R_LeegKuiltjeTegenstander()
        {
            naam = "leeg kuiltje tegenstander.";
            this.zetResultaten.Add(Spel.ZetResultaat.VolgendeSpeler);
        }

        // Check of het laatste steentje in een leeg kuiltje van de tegenspeler terecht is gekomen.
        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            // In eigen kuiltje gekomen.
            if (spelerIt == huidigeSpeler)
                return false;

            //Kuiltje van de tegenstander is leeg
            if (laatsteKuiltje.GetAantalSteentjes() == 0)
                return true;
            else
                return false;
        }
    }
}
