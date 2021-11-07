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

            Console.WriteLine("Toets in als getal hoeveel kuiltjes iedere speler heeft. Min 1, max 9.");
            int aantalKuiltjes = VraagGetal(1, 9);
            Console.WriteLine("Toets in als getal hoeveel steentjes ieder kuiltje bevat. Min 1, max 9.");
            int aantalSteentjes = VraagGetal(1, 9);

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

        public static int VraagGetal(int lower, int upper)
        {
            try
            {
                int input = int.Parse(Console.ReadLine());
                if(input < lower || input > upper)
                {
                    Console.WriteLine("Toets een getal in binnen de marges.");
                    return VraagGetal(lower, upper);
                }
                return input;
            }
            catch {
                Console.WriteLine("Ongeldige input. Toets een correct getal in.");
                return VraagGetal(lower, upper);
            }
        }
    }
}
