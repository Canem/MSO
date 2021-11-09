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
        private static bool thuisKuiltjeSpreiden = false;

        public override bool getThuisKuiltjeRegel()
        {
            return thuisKuiltjeSpreiden;
        }

        public bool Finished(Bord bord, Spel.Speler huidigeSpeler) { return base.IsFinished(bord, huidigeSpeler); }
    }
}
