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

        // Verzamelkuiltjes voor de Wari variant.
        public Kuiltje s1VerzamelKuiltje;
        public Kuiltje s2VerzamelKuiltje;

        public Bord(int aantalKuiltjes, int aantalSteentjes, bool verzamelKuiltjes)
        {
            // Maak een lijst gevuld met kuiltjes aan voor beide spelers.
            s1Kuiltjes = new Kuiltje[aantalKuiltjes];
            s2Kuiltjes = new Kuiltje[aantalKuiltjes];
            for (int i = 0; i < s1Kuiltjes.Length; i++)
            {
                Kuiltje k1 = new Kuiltje(aantalSteentjes);
                Kuiltje k2 = new Kuiltje(aantalSteentjes);

                s1Kuiltjes[i] = k1;
                s2Kuiltjes[i] = k2;
            }

            // Maak verzamelkuiltjes aan als de regels dit aangeven.
            if (verzamelKuiltjes)
            {
                s1VerzamelKuiltje = new Kuiltje(0, true);
                s2VerzamelKuiltje = new Kuiltje(0, true);
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
                k.PrintKuiltje();
            Console.Write("< |");
            if (s2VerzamelKuiltje != null)
            {
                Console.Write("  ");
                s2VerzamelKuiltje.PrintKuiltje();
            }
            if (huidigeSpeler == Spel.Speler.Speler2)
                Console.Write("  <---");
            Console.WriteLine();

            // Print speler 1s bord.
            Console.Write("Speler 1  -  | >");
            foreach (Kuiltje k in s1Kuiltjes)
                k.PrintKuiltje();
            Console.Write("> |");
            if (s1VerzamelKuiltje != null)
            {
                Console.Write("  ");
                s1VerzamelKuiltje.PrintKuiltje();
            }
            if (huidigeSpeler == Spel.Speler.Speler1)
                Console.Write("  <---");
            Console.WriteLine();
        }

        public Kuiltje Zet(Spel.Speler huidigeSpeler, int kuiltjeNummer)
        {
            if (IsZetValide(huidigeSpeler, kuiltjeNummer) == false)
            {
                return null;
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

            // Return het laatste kuiltje.
            if (spelerIt == Spel.Speler.Speler1)
                return s1Kuiltjes[kuiltjeIt - 1];
            else
                return s2Kuiltjes[kuiltjeIt - 1];
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

        public void PaktStenenVoorThuisKuiltje(Spel.Speler huidigeSpeler, Kuiltje kuiltje)
        {
            int aantalSteentjes = kuiltje.Leeg();
            VulThuisKuiltje(huidigeSpeler, aantalSteentjes);
        }

        public void VulThuisKuiltje(Spel.Speler huidigeSpeler, int aantalSteentjes)
        {
            if(huidigeSpeler == Spel.Speler.Speler1)
            {
                if (s1VerzamelKuiltje != null)
                    s1VerzamelKuiltje.VoegToe(aantalSteentjes);
                else
                    s1Kuiltjes[s1Kuiltjes.Length - 1].VoegToe(aantalSteentjes);
            }
            else
            {
                if (s2VerzamelKuiltje != null)
                    s2VerzamelKuiltje.VoegToe(aantalSteentjes);
                else
                    s2Kuiltjes[0].VoegToe(aantalSteentjes);
            }
                
        }
    }
}
