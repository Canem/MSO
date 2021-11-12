using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Mankala : SpelVariant
    {
        private static readonly string Naam = "Mankala";
        private static readonly bool ThuisKuiltjeSpreiden = true;
        public bool Finished(Bord bord, Spel.Speler huidigeSpeler) { return base.IsFinished(bord, huidigeSpeler); }

        public override bool getThuisKuiltjeRegel()
        {
            return ThuisKuiltjeSpreiden;
        }

        public override string getNaam()
        {
            return Naam;
        }
    }
}
