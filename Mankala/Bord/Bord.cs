using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Bord
    {
        /*
         * NOTE: Kuiltjenummers worden met n - 1 aangegeven.
         * Dit betekent dat het eerste kuiltje in-game nummer 1 heeft, maar in de code nummer 0.
         */

        public Kuiltje[] s1Kuiltjes;
        public Kuiltje[] s2Kuiltjes;

        public Bord(int aantalKuiltjes, int aantalSteentjes)
        {
            s1Kuiltjes = new Kuiltje[aantalKuiltjes];
            s2Kuiltjes = new Kuiltje[aantalKuiltjes];

            for (int i = 0; i < s1Kuiltjes.Length; i++)
            {
                Kuiltje k1 = new Speelkuiltje(aantalSteentjes);
                Kuiltje k2 = new Speelkuiltje(aantalSteentjes);

                s1Kuiltjes[i] = k1;
                s2Kuiltjes[i] = k2;
            }
        }

        public void PrintBord(Spel.Speler huidigeSpeler)
        {
            // Print kuiltje info.
            Console.Write("Kuiltje#  -     ");
            for (int i = 0; i < s1Kuiltjes.Length; i++)
                Console.Write(" " + (i+1) + ". ");
            Console.WriteLine();

            // Print speler 2s bord.
            Console.Write("Speler 2  -  | <");
            foreach (Kuiltje k in s2Kuiltjes)
                k.printKuiltje();
            Console.Write("< |");
            if (huidigeSpeler == Spel.Speler.Speler2)
                Console.Write("  <---");
            Console.WriteLine();

            // Print speler 1s bord.
            Console.Write("Speler 1  -  | >");
            foreach (Kuiltje k in s1Kuiltjes)
                k.printKuiltje();
            Console.Write("> |");
            if (huidigeSpeler == Spel.Speler.Speler1)
                Console.Write("  <---");
            Console.WriteLine();
        }

        public bool Zet(Spel.Speler huidigeSpeler, int kuiltjeNummer)
        {
            if (IsZetValide(huidigeSpeler, kuiltjeNummer) == false)
            {
                return false;
            }

            int huidigeSteentjes;
            int kuiltjeIt = kuiltjeNummer;
            Spel.Speler spelerIt = huidigeSpeler;

            // Krijg aantal steentjes
            if (spelerIt == Spel.Speler.Speler1)
                huidigeSteentjes = s1Kuiltjes[kuiltjeIt - 1].Leeg();
            else
                huidigeSteentjes = s2Kuiltjes[kuiltjeIt - 1].Leeg();

            // Spreid steentjes
            while (huidigeSteentjes > 0)
            {
                if (spelerIt == Spel.Speler.Speler1)
                    kuiltjeIt++;
                else
                    kuiltjeIt--;

                // Als kuiltje iteratie te hoog is, wissel speler iteratie. [van rechtsonder naar rechtsboven schuiven]
                if (kuiltjeIt > s1Kuiltjes.Length)
                {
                    spelerIt = Spel.Speler.Speler2;
                    kuiltjeIt--;
                }

                // Als kuiltje iteratie te laag is wissel speler iteratie. [van linksboven naar linksonder schuiven]
                if (kuiltjeIt == 0)
                {
                    spelerIt = Spel.Speler.Speler1;
                    kuiltjeIt++;
                }

                // Voeg steentjes toe
                if (spelerIt == Spel.Speler.Speler1)
                    s1Kuiltjes[kuiltjeIt - 1].VoegToe(1);
                else
                    s2Kuiltjes[kuiltjeIt - 1].VoegToe(1);

                huidigeSteentjes--;
            }

            Console.WriteLine("Geldige zet. Het bord wordt geupdate.");

            // CheckLaatsteSteen();

            return true;
        }

        protected bool IsZetValide(Spel.Speler huidigeSpeler, int kuiltjeNummer)
        {
            // Algemene tests.
            if (kuiltjeNummer == 0 || kuiltjeNummer > s1Kuiltjes.Length)
            {
                Console.WriteLine("Kies een correct nummer dat past bij een kuiltje.");
                return false;
            }

            // Test voor speler 1.
            if (huidigeSpeler == Spel.Speler.Speler1 && s1Kuiltjes[kuiltjeNummer - 1].GetAantalSteentjes() == 0)
            {
                Console.WriteLine("Kies een kuiltje dat steentjes bevat.");
                return false;
            }

            // Test voor speler 2.
            if (huidigeSpeler == Spel.Speler.Speler2 && s2Kuiltjes[kuiltjeNummer - 1].GetAantalSteentjes() == 0)
            {
                Console.WriteLine("Kies een kuiltje dat steentjes bevat.");
                return false;
            }

            return true;
        }
    }
}
