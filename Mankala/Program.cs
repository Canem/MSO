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

            Console.WriteLine("Toets in als getal hoeveel kuiltjes iedere speler heeft.");
            int aantalKuiltjes = VraagGetal();
            Console.WriteLine("Toets in als getal hoeveel steentjes ieder kuiltje bevat.");
            int aantalSteentjes = VraagGetal();

            spel.InitialiseerSpel(aantalKuiltjes, aantalSteentjes);
        }

        protected static void InitialiseerVariant()
        {
            Console.WriteLine("\n\nSelecteer een spelvariant:" +
                "\n[M]ankala" +
                "\n[W]ari");

            string input = Console.ReadLine();
            char variantInput = input[0];

            switch (variantInput)
            {
                case 'm':
                    Console.WriteLine("Je hebt gekozen voor " + Mankala.naam);
                    spel.huidigeVariant = Spel.SpelVariant.Mankala;
                    return;
                case 'w':
                    Console.WriteLine("Je hebt gekozen voor " + Wari.naam);
                    spel.huidigeVariant = Spel.SpelVariant.Wari;
                    return;
                default:
                    Console.WriteLine("Ongeldige variant. Kies een correcte letter.");
                    InitialiseerVariant();
                    return;
            }
        }

        protected static int VraagGetal()
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                return input;
            }
            catch {
                Console.WriteLine("Ongeldig getal. Toets een correct getal in.");
                return VraagGetal();
            }
        }
    }
}
