using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    abstract class Regel
    {
        public string naam;

        public List<Spel.ZetResultaat> zetResultaten = new List<Spel.ZetResultaat>();
        public abstract bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje);
    }
}
