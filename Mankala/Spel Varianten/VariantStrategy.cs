using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class VariantStrategy
    {
        private readonly Spel spel;
        private readonly List<Regel> regels;

        public VariantStrategy()
        {
            spel = new Spel();
            regels = new List<Regel>();
        }

        public Spel CreeerSpel(char input)
        {
            switch (input)
            {
                case 'M':
                    spel.huidigeVariant = new Mankala();
                    regels.Add(new R_GevuldKuiltje());
                    regels.Add(new R_LeegKuiltjeTegenstander());
                    regels.Add(new R_LeegEigenTegenoverLeeg());
                    regels.Add(new R_LeegEigenTegenoverGevuld());
                    regels.Add(new R_Thuiskuiltje());
                    break;
                case 'W':
                    spel.huidigeVariant = new Wari();
                    regels.Add(new R_WariRegel());
                    break;
                default:
                    break;
            }

            spel.SetRegels(regels);
            return spel;
        }
    }
}
