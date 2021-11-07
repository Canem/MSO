using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Spel
    {
        public enum SpelVariant { Mankala, Wari }

        public enum Speler { Speler1, Speler2 }
        public Speler huidigeSpeler;
        public SpelVariant huidigeVariant;

        protected Bord bord;
        protected int beurtNummer;

        //Regel[] regels;

        public void InitialiseerSpel(int aantalKuiltjes, int aantalSteentjes)
        {
            huidigeSpeler = Speler.Speler1;
            bord = new Bord(aantalKuiltjes, aantalSteentjes);
            beurtNummer = 1;

            Console.WriteLine("\n\n\nLaat het spel beginnen!\n");
            Beurt();
        }

        protected void Beurt()
        {
            Console.WriteLine("\n\n- Beurt " + beurtNummer + " -" + "\n");

            bord.PrintBord(huidigeSpeler);

            Console.WriteLine("\n" + huidigeSpeler + " is aan zet." + "\nKies een kuiltje.");
            Zet();

            // CheckRegels()

            // if -> Beurt(), else -> verander huidige speler en Beurt()


            // plaatsverangende code:
            Console.WriteLine("\nLaatste steen eindigde in ...");
            Console.WriteLine("De beurt blijft behouden voor " + huidigeSpeler + ".");
            beurtNummer++;
            Beurt();
        }

        public void Zet()
        {
            int kuiltjeNummer = Program.VraagGetal(0, 9);
            bool checkZet = bord.Zet(huidigeSpeler, kuiltjeNummer);

            if (checkZet == false)
            {
                Zet();
            }
        }
        
    }
}
