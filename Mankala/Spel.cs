using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Spel
    {
        public enum Speler { Speler1, Speler2 }
        public Speler huidigeSpeler;
        private Speler volgendeSpeler;
        public SpelVariant huidigeVariant;

        protected Bord bord;
        protected int beurtNummer;

        protected List<Regel> regels;
        public enum ZetResultaat { Niets, PakStenenVoorThuiskuiltje, VerderSpelen, VolgendeSpeler, PakStenenTegenover, DoorSpreiden }


        public void InitialiseerSpel(int aantalKuiltjes, int aantalSteentjes, bool thuisSpreiden)
        {
            huidigeSpeler = Speler.Speler1;
            bord = new Bord(aantalKuiltjes, aantalSteentjes, true, thuisSpreiden);
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

            if (huidigeVariant.IsFinished(bord, huidigeSpeler))
            {
                Console.WriteLine("De Winnaar is: " + GetWinnaar());
                Console.ReadLine();
            }

            Console.WriteLine("\n" + huidigeSpeler + " is aan zet." + "\nKies een kuiltje.");
            Kuiltje laatsteKuiltje = Zet();

            // Verkrijg het kuiltjeNummer en bij welke speler het laatste kuiltje behoort.
            Speler spelerIt = Speler.Speler1;
            int kuiltjeIt = 0;

            for (int i = 1; i <= bord.s1Kuiltjes.Length; i++)
            {
                if (laatsteKuiltje.Equals(bord.s1Kuiltjes[i - 1]) || laatsteKuiltje.Equals(bord.s1VerzamelKuiltje))
                {
                    spelerIt = Speler.Speler1;
                    kuiltjeIt = i;
                }
                else if (laatsteKuiltje.Equals(bord.s2Kuiltjes[i - 1]) || laatsteKuiltje.Equals(bord.s2VerzamelKuiltje))
                {
                    spelerIt = Speler.Speler2;
                    kuiltjeIt = i;
                }
            }

            List<ZetResultaat> zetActies = CheckRegels(spelerIt, kuiltjeIt, huidigeSpeler, laatsteKuiltje);

            foreach (ZetResultaat actie in zetActies)
            {
                switch (actie)
                {
                    case ZetResultaat.PakStenenVoorThuiskuiltje:
                        bord.PaktStenenVoorThuisKuiltje(huidigeSpeler, laatsteKuiltje);
                        break;
                    case ZetResultaat.VerderSpelen:
                        volgendeSpeler = huidigeSpeler;
                        break;
                    case ZetResultaat.VolgendeSpeler:
                        volgendeSpeler = NextSpeler(huidigeSpeler);
                        break;
                    case ZetResultaat.PakStenenTegenover:
                        bord.PaktStenenVoorThuisKuiltje(huidigeSpeler, laatsteKuiltje);
                        bord.PaktStenenVoorThuisKuiltje(huidigeSpeler, bord.getTegenover(kuiltjeIt, huidigeSpeler));
                        break;
                    case ZetResultaat.DoorSpreiden:
                        Zet(false, kuiltjeIt);
                        break;
                    case ZetResultaat.Niets:
                        break;
                }
            }
            // Console.WriteLine("\nLaatste steen eindigde in " + spelerIt + ".");
            beurtNummer++;

            huidigeSpeler = volgendeSpeler;
            Beurt();
        }

        private Speler NextSpeler(Speler s)
        {
            if (s == Speler.Speler1)
                return Speler.Speler2;
            else
                return Speler.Speler1;
        }

        public Kuiltje Zet(bool vraagGetal = true, int kuiltjeNummer = 0)
        {

            if (vraagGetal)
                kuiltjeNummer = Program.VraagGetal(0, 9);

            Kuiltje laatsteKuiltje = bord.Zet(huidigeSpeler, kuiltjeNummer);

            // Als de zet fout is, doe hem overnieuw.
            if (laatsteKuiltje == null)
                return Zet();
            else
                return laatsteKuiltje;
        }

        protected List<ZetResultaat> CheckRegels(Speler spelerIt, int kuiltjeIt, Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            List<ZetResultaat> zetActies = new List<ZetResultaat>();
            foreach (Regel regel in regels)
            {
                if (regel.CheckTrigger(bord, spelerIt, kuiltjeIt, huidigeSpeler, laatsteKuiltje))
                {
                    Console.WriteLine("Laatste steen eindigde in " + regel.naam);
                    foreach (ZetResultaat zetResultaat in regel.zetResultaten)
                        zetActies.Add(zetResultaat);
                }
                    
            }

            if (zetActies.Count == 0)
                zetActies.Add(ZetResultaat.VolgendeSpeler);

            return zetActies;
        }   
        
        private Speler GetWinnaar()
        {
            int s1Punten = bord.s1VerzamelKuiltje.GetAantalSteentjes();
            int s2Punten = bord.s2VerzamelKuiltje.GetAantalSteentjes();

            if (s1Punten > s2Punten)
                return Speler.Speler1;
            else
                return Speler.Speler2;
        }
    }
}
