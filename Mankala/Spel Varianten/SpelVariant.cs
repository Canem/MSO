using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    abstract class SpelVariant
    {
        public static string naam;
        List<Regel> regels;

        public abstract bool getThuisKuiltjeRegel();

        public virtual bool IsFinished(Bord bord, Spel.Speler huidigeSpeler)
        {
            if (huidigeSpeler == Spel.Speler.Speler1)
            {
                for (int i = 0; i < bord.s2Kuiltjes.Length; i++)
                {
                    if (bord.s2Kuiltjes[i].GetAantalSteentjes() != 0)
                        return false;
                }
            }
            else
            {
                for (int i = 0; i < bord.s1Kuiltjes.Length; i++)
                {
                    if (bord.s1Kuiltjes[i].GetAantalSteentjes() != 0)
                        return false;
                }
            }

            return true;
        }
    }

}
