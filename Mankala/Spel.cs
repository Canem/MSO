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

        protected List<Regel> regels;
        public enum ZetResultaat { Niets, PakStenenVoorThuiskuiltje, VerderSpelen, VolgendeSpeler }

        public void InitialiseerSpel(int aantalKuiltjes, int aantalSteentjes)
        {
            huidigeSpeler = Speler.Speler1;
            bord = new Bord(aantalKuiltjes, aantalSteentjes, true);
            beurtNummer = 1;

            Console.WriteLine("\n\n\nLaat het spel beginnen!\n");
            Beurt();
        }

        public void SetRegels(List<Regel> rs)
        {
            regels = rs;
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

            List<ZetResultaat> zetActies = CheckRegels(spelerIt, kuiltjeIt, huidigeSpeler);

            foreach (ZetResultaat actie in zetActies)
            {
                switch (actie)
                {
                    case ZetResultaat.PakStenenVoorThuiskuiltje:
                        bord.PaktStenenVoorThuisKuiltje(huidigeSpeler, laatsteKuiltje);
                        break;
                    case ZetResultaat.VerderSpelen:
                        bord.VerderSpelen(huidigeSpeler, kuiltjeIt);
                        break;
                    case ZetResultaat.VolgendeSpeler:
                        huidigeSpeler = NextSpeler(huidigeSpeler);
                        Beurt();
                        break;
                    case ZetResultaat.Niets:
                        break;
                }
            }

            Console.WriteLine("\nLaatste steen eindigde in " + spelerIt + ".");
            beurtNummer++;

            if (huidigeSpeler == spelerIt)
            {
                Console.WriteLine("De beurt blijft behouden voor " + huidigeSpeler + ".");
                Beurt();
            }
            else 
            {
                huidigeSpeler = NextSpeler(huidigeSpeler);
                Beurt();
            }
        }

        private Speler NextSpeler(Speler s)
        {
            if (s == Speler.Speler1)
                return Speler.Speler2;
            else
                return Speler.Speler1;
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

        protected List<ZetResultaat> CheckRegels(Speler spelerIt, int kuiltjeIt, Speler huidigeSpeler)
        {
            List<ZetResultaat> zetActies = new List<ZetResultaat>();
            foreach (Regel regel in regels)
            {
                if (regel.CheckTrigger(bord, spelerIt, kuiltjeIt, huidigeSpeler))
                    foreach (ZetResultaat zetResultaat in regel.zetResultaten)
                        zetActies.Add(zetResultaat);
            }

            return zetActies;
        }        
    }
}
