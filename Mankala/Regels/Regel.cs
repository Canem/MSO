using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    abstract class Regel
    {
        // De naam van de regel. Wanneer de regel getriggerd wordt, wordt de naam weergegeven.
        public string naam;

        // Een lijst met acties die gedaan moeten worden als aan de regel voldaan wordt.
        public List<Spel.ZetResultaat> zetResultaten = new List<Spel.ZetResultaat>();
        
        // Kijkt of aan de regel voldaan wordt. true = ja, false = nee
        public abstract bool CheckTrigger(Bord bord, Spel.Speler huidigeSpeler, Kuiltje laatsteKuiltje);
    }
}
