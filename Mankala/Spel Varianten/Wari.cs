using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Wari : SpelVariant
    {
        public static string Naam = "Wari";
        private static readonly bool ThuisKuiltjeSpreiden = false;

        public override bool getThuisKuiltjeRegel()
        {
            return ThuisKuiltjeSpreiden;
        }

        public override string getNaam()
        {
            return Naam;
        }

        public bool Finished(Bord bord, Spel.Speler huidigeSpeler) { return base.IsFinished(bord, huidigeSpeler); }
    }
}
