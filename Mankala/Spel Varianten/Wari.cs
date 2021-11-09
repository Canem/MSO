using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Wari : SpelVariant
    {
        public static string naam = "Wari";

        public bool Finished(Bord bord, Spel.Speler huidigeSpeler) { return base.IsFinished(bord, huidigeSpeler); }
    }
}
