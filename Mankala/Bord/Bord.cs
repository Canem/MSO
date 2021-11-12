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

        // De kuiltjes van speler 1 en 2.
        public Kuiltje[] s1Kuiltjes;
        public Kuiltje[] s2Kuiltjes;

        // Verzamelkuiltjes voor de Wari variant.
        public Kuiltje s1VerzamelKuiltje;
        public Kuiltje s2VerzamelKuiltje;
        private readonly bool spreidThuisKuil;

        public Bord(int aantalKuiltjes, int aantalSteentjes, bool verzamelKuiltjes, bool spreidThuisKuil)
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

            this.spreidThuisKuil = spreidThuisKuil;
        }

        // Output de weergave van het bord.
        public void PrintBord(Spel.Speler huidigeSpeler)
        {
            // Print kuiltje info.
            String printString = "";
            printString += ("Kuiltje#  -            ");
            for (int i = 0; i < s1Kuiltjes.Length; i++)
                printString += (" " + (i+1) + ". ");
            Program.ui.GeefWeer(printString);

            // Print speler 2s bord.
            printString = "";
            printString += ("Speler 2  -  ");
            if (s2VerzamelKuiltje != null)
            {
                printString += s2VerzamelKuiltje.PrintKuiltje();
            }
            printString += ("  | <");
            foreach (Kuiltje k in s2Kuiltjes)
                printString += k.PrintKuiltje();
            printString += ("< |");
            
            if (huidigeSpeler == Spel.Speler.Speler2)
                printString += ("  <---");
            Program.ui.GeefWeer(printString);

            // Print speler 1s bord.
            printString = "";
            printString += ("Speler 1  -        | >");
            foreach (Kuiltje k in s1Kuiltjes)
                printString += k.PrintKuiltje();
            printString += ("> |");
            if (s1VerzamelKuiltje != null)
            {
                printString += ("  ") + s1VerzamelKuiltje.PrintKuiltje();
            }
            if (huidigeSpeler == Spel.Speler.Speler1)
                printString += ("  <---");
            Program.ui.GeefWeer(printString);
        }

        // Handelt het doen van een zet af waarin steentjes gespreid worden.
        public Kuiltje Zet(Spel.Speler huidigeSpeler, int kuiltjeNummer)
        {
            if (IsZetValide(huidigeSpeler, kuiltjeNummer) == false)
                return null;

            int kuiltjeIt = kuiltjeNummer;
            Spel.Speler spelerIt = huidigeSpeler;

            Kuiltje laatsteKuiltje = SpreidSteentjes(spelerIt, kuiltjeIt);

            Program.ui.GeefWeer("Geldige zet - Het bord wordt geupdate.");
            return laatsteKuiltje;
        }

        // Pak de steentjes op uit een kuiltje en verspreid deze over de kuiltjes tegen de klok in.
        protected Kuiltje SpreidSteentjes(Spel.Speler spelerIt, int kuiltjeIt)
        {
            Kuiltje laatsteKuiltje = null;

            // Krijg aantal steentjes
            int huidigeSteentjes;
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
                    if (!spreidThuisKuil)
                    {
                        spelerIt = Spel.Speler.Speler2;
                        kuiltjeIt--;
                    }
                    else
                    {
                        spelerIt = Spel.Speler.Speler2;
                        s1VerzamelKuiltje.VoegToe(1);
                        huidigeSteentjes--;
                        laatsteKuiltje = s1VerzamelKuiltje;
                        continue;
                    }
                }

                // Als kuiltje iteratie te laag is wissel speler iteratie. [van linksboven naar linksonder schuiven]
                if (kuiltjeIt == 0)
                {
                    if (!spreidThuisKuil)
                    {
                        spelerIt = Spel.Speler.Speler1;
                        kuiltjeIt++;
                    }
                    else
                    {
                        spelerIt = Spel.Speler.Speler1;
                        s2VerzamelKuiltje.VoegToe(1);
                        huidigeSteentjes--;
                        laatsteKuiltje = s2VerzamelKuiltje;
                        continue;
                    }
                }

                // Voeg steentjes toe
                if (spelerIt == Spel.Speler.Speler1)
                {
                    s1Kuiltjes[kuiltjeIt - 1].VoegToe(1);
                    laatsteKuiltje = s1Kuiltjes[kuiltjeIt - 1];
                }
                else
                {
                    s2Kuiltjes[kuiltjeIt - 1].VoegToe(1);
                    laatsteKuiltje = s2Kuiltjes[kuiltjeIt - 1];
                }

                huidigeSteentjes--;
            }
            return laatsteKuiltje;
        }

        // Controleert of een zet toegestaan is.
        protected bool IsZetValide(Spel.Speler huidigeSpeler, int kuiltjeNummer)
        {
            // Algemene tests.
            if (kuiltjeNummer == 0 || kuiltjeNummer > s1Kuiltjes.Length)
            {
                Program.ui.GeefWeer("Kies een correct nummer dat past bij een kuiltje.");
                return false;
            }

            // Test voor speler 1.
            if (huidigeSpeler == Spel.Speler.Speler1 && s1Kuiltjes[kuiltjeNummer - 1].GetAantalSteentjes() == 0)
            {
                Program.ui.GeefWeer("Kies een kuiltje dat steentjes bevat.");
                return false;
            }

            // Test voor speler 2.
            if (huidigeSpeler == Spel.Speler.Speler2 && s2Kuiltjes[kuiltjeNummer - 1].GetAantalSteentjes() == 0)
            {
                Program.ui.GeefWeer("Kies een kuiltje dat steentjes bevat.");
                return false;
            }

            return true;
        }

        // Verkrijg het kuiltje tegenover het huidige kuiltje.
        public Kuiltje GetTegenover(int kuiltjeIt, Spel.Speler spelerIt)
        {
            Kuiltje tegenover;
            if(spelerIt == Spel.Speler.Speler1)
                tegenover = s2Kuiltjes[kuiltjeIt - 1];
            else
                tegenover = s1Kuiltjes[kuiltjeIt - 1];

            return tegenover;
        }

        // Pak de stenen van het huidige kuiltje en stop deze in het thuiskuiltje.
        public void PaktStenenVoorThuisKuiltje(Spel.Speler huidigeSpeler, Kuiltje kuiltje)
        {
            int aantalSteentjes = kuiltje.Leeg();
            VulThuisKuiltje(huidigeSpeler, aantalSteentjes);
        }

        // Leg stenen in het thuiskuiltje.
        private void VulThuisKuiltje(Spel.Speler huidigeSpeler, int aantalSteentjes)
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

        // Blijf steentjes spreiden totdat de laatste steen in een leeg kuiltje belandt.
        public void BlijfSpreiden(Spel.Speler spelerIt, int kuiltjeIt, Spel.Speler huidigeSpeler)
        {
            PrintBord(huidigeSpeler);
            Program.ui.GeefWeer("Het spreiden gaat door. Klik op 'enter' om door te gaan.");
            Program.ui.VraagInput();
            Kuiltje laatsteKuiltje = SpreidSteentjes(spelerIt, kuiltjeIt);
            if (laatsteKuiltje.GetAantalSteentjes() >1 && !laatsteKuiltje.isThuisKuiltje)
                BlijfSpreiden(GetSpelerIt(laatsteKuiltje), GetKuiltjeIt(laatsteKuiltje), huidigeSpeler);
        }

        // Verkrijg de speler iteratie.
        public Spel.Speler GetSpelerIt(Kuiltje kuiltje)
        {
            for (int i = 1; i <= s1Kuiltjes.Length; i++)
                if (kuiltje.Equals(s1Kuiltjes[i - 1]))
                {
                    return Spel.Speler.Speler1;
                }
            return Spel.Speler.Speler2;
        }

        // Verkrijg de kuiltje iteratie.
        public int GetKuiltjeIt(Kuiltje kuiltje)
        {
            for (int i = 1; i <= s1Kuiltjes.Length; i++)
                if (kuiltje.Equals(s1Kuiltjes[i - 1]) || kuiltje.Equals(s2Kuiltjes[i - 1]))
                {
                    return i;
                }
            return 0;
        }
    }
}
