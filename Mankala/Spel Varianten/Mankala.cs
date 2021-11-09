using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Mankala : SpelVariant
    {
        public static string naam = "Mankala";
        private static bool thuisKuiltjeSpreiden = true;
        public bool Finished(Bord bord, Spel.Speler huidigeSpeler) { return base.IsFinished(bord, huidigeSpeler); }

        public override bool getThuisKuiltjeRegel()
        {
            return thuisKuiltjeSpreiden;
        }
    }
}
