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
        public enum ZetResultaat {  }

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
            Kuiltje laatsteKuiltje = Zet();

            // Verkrijg het kuiltjeNummer en bij welke speler het laatste kuiltje behoort.
            Speler spelerIt = Speler.Speler1;
            int kuiltjeIt = 0;

            for (int i = 1; i <= bord.s1Kuiltjes.Length; i++)
            {
                if (laatsteKuiltje.Equals(bord.s1Kuiltjes[i - 1]))
                {
                    spelerIt = Speler.Speler1;
                    kuiltjeIt = i;
                }
                else if (laatsteKuiltje.Equals(bord.s2Kuiltjes[i - 1]))
                {
                    spelerIt = Speler.Speler2;
                    kuiltjeIt = i;
                }
            }

            //Console.WriteLine("SpelerIt: " + spelerIt + " | kuiltjeIt: " + kuiltjeIt);

            CheckRegels(spelerIt, kuiltjeIt);

            // CheckRegels()

            // if -> Beurt(), else -> verander huidige speler en Beurt()


            // plaatsverangende code:
            Console.WriteLine("\nLaatste steen eindigde in ...");
            Console.WriteLine("De beurt blijft behouden voor " + huidigeSpeler + ".");
            beurtNummer++;
            Beurt();
        }

        public Kuiltje Zet()
        {
            int kuiltjeNummer = Program.VraagGetal(0, 9);
            Kuiltje laatsteKuiltje = bord.Zet(huidigeSpeler, kuiltjeNummer);

            // Als de zet fout is, doe hem overnieuw.
            if (laatsteKuiltje == null)
                return Zet();
            else
                return laatsteKuiltje;
        }

        protected void CheckRegels(Speler spelerIt, int kuiltjeIt)
        {

        }
        
    }
}
