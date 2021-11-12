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
        public static UI ui;

        static void Main(string[] args)
        {
            ui = new UI_Console();
            SpelInitialisatie();
        }

        protected static void SpelInitialisatie()
        {
            ui.GeefWeer("Welkom bij Console Mankala!" +
                "\nDit is de implementatie van groep 14");

            InitialiseerVariant();

            ui.GeefWeer("Toets in als getal hoeveel kuiltjes iedere speler heeft. Min 1, max 9.");
            int aantalKuiltjes = VraagGetal(1, 9);
            ui.GeefWeer("Toets in als getal hoeveel steentjes ieder kuiltje bevat. Min 1, max 9.");
            int aantalSteentjes = VraagGetal(1, 9);

            spel.InitialiseerSpel(aantalKuiltjes, aantalSteentjes, spel.huidigeVariant.getThuisKuiltjeRegel());
        }

        protected static void InitialiseerVariant()
        {
            ui.GeefWeer("\n\nSelecteer een spelvariant:" +
                "\n[M]ankala" +
                "\n[W]ari");

            string input = ui.VraagInput();
            char variantInput = Char.ToUpper(input[0]);

            if(variantInput != 'M' && variantInput != 'W')
            {
                ui.GeefWeer("Ongeldige variant. Kies een correcte letter.");
                InitialiseerVariant();
                return;
            }

            VariantStrategy variant = new VariantStrategy();
            spel = variant.CreeerSpel(variantInput);

            ui.GeefWeer("Je hebt gekozen voor " + spel.huidigeVariant.getNaam());
        }

        public static int VraagGetal(int lower, int upper)
        {
            try
            {
                int input = int.Parse(ui.VraagInput());
                if(input < lower || input > upper)
                {
                    ui.GeefWeer("Toets een getal in binnen de marges.");
                    return VraagGetal(lower, upper);
                }
                return input;
            }
            catch {
                ui.GeefWeer("Ongeldige input. Toets een correct getal in.");
                return VraagGetal(lower, upper);
            }
        }

        public static void VraagRematch()
        {
            ui.GeefWeer("\nWil je nog een potje spelen? [j]a of [n]ee?");
            char input = (char)ui.VraagInput()[0];
            if(input == 'j')
            {
                ui.GeefWeer("Het spel wordt herstart...\n\n");
                SpelInitialisatie();
            }
            else if(input == 'n')
            {
                ui.GeefWeer("Tot ziens!");
                ui.VraagInput();
            }
            else
            {
                ui.GeefWeer("Toets [j]a of [n]ee in a.u.b.");
                VraagRematch();
            }
        }
    }
}
