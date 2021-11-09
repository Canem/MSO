using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class ThuisKeultje : Regel
    {
        public ThuisKeultje()
        {
            this.zetResultaten.Add(Spel.ZetResultaat.VerderSpelen);
        }

        public override bool CheckTrigger(Bord bord, Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler)
        {
            throw new NotImplementedException();
        }
    }
}
