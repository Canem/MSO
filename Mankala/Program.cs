using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Program
    {
        public static Spel spel;

        static void Main(string[] args)
        {
            spel = new Spel();
            SpelInitialisatie();

        }


        protected static void SpelInitialisatie()
        {
            Console.WriteLine("Welkom bij Console Mankala!" +
                "\nDit is de implementatie van groep 14");

            InitialiseerVariant();
        }

        protected static void InitialiseerVariant()
        {
            Console.WriteLine("\n\nSelecteer een spelvariant:" +
                "\n[M]ankala" +
                "\n[W]ari");

            char variantInput = (char)Console.Read();

            switch (variantInput)
            {
                case 'm':
                    Console.WriteLine("Je hebt gekozen voor Mankala");
                    spel.huidigeVariant = Spel.SpelVariant.Mankala;
                    return;
                case 'w':
                    Console.WriteLine("Je hebt gekozen voor Wari");
                    spel.huidigeVariant = Spel.SpelVariant.Wari;
                    return;
                default:
                    Console.WriteLine("Ongeldige variant. Kies een correcte letter.");
                    InitialiseerVariant();
                    return;
            }
        }
    }
}
