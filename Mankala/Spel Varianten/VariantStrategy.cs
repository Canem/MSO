using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class VariantStrategy
    {
        private Spel spel;
        private List<Regel> regels;
        public VariantStrategy()
        {
            spel = new Spel();
            regels = new List<Regel>();
        }

        public Spel CreeerSpel(char v)
        {
            switch (v)
            {
                case 'M':
                    spel.huidigeVariant = new Mankala();
                    regels.Add(new EigenKuiltjeNietLeeg());
                    regels.Add(new LeegKuiltjeTegenstander());
                    regels.Add(new EigenEnTegenoverLeeg());
                    regels.Add(new EigenLeegTegenNiet());
                    break;
                case 'W':
                    spel.huidigeVariant = new Wari();
                    regels.Add(new WariRegel());
                    break;
                default:
                    break;
            }

            spel.SetRegels(regels);
            return spel;
        }

    }
}
