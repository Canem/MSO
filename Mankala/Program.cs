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

            spel.InitialiseerSpel(aantalKuiltjes, aantalSteentjes, spel.huidigeVariant.getThuisKuiltjeRegel());
        }

        protected static void InitialiseerVariant()
        {
            Console.WriteLine("\n\nSelecteer een spelvariant:" +
                "\n[M]ankala" +
                "\n[W]ari");

            string input = Console.ReadLine();
            char variantInput = Char.ToUpper(input[0]);

            if(variantInput != 'M' && variantInput != 'W')
            {
                Console.WriteLine("Ongeldige variant. Kies een correcte letter.");
                InitialiseerVariant();
                return;
            }

            VariantStrategy variant = new VariantStrategy();
            spel = variant.CreeerSpel(variantInput);

            Console.WriteLine("Je hebt gekozen voor " + spel.huidigeVariant.getNaam());
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

        public static void VraagRematch()
        {
            Console.WriteLine("\nWil je nog een potje spelen? [j]a of [n]ee?");
            char input = (char)Console.ReadLine()[0];
            if(input == 'j')
            {
                Console.WriteLine("Het spel wordt herstart...\n\n");
                SpelInitialisatie();
            }
            else if(input == 'n')
            {
                Console.WriteLine("Tot ziens!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Toets [j]a of [n]ee in a.u.b.");
                VraagRematch();
            }
        }
    }
}
