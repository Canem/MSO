using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mankala
{
    class Spel
    {
        // Speler variabelen
        public enum Speler { Speler1, Speler2 }
        public Speler huidigeSpeler;
        protected Speler volgendeSpeler;

        // De spelvariant en de bijbehorende spelregels.
        public SpelVariant huidigeVariant;
        protected List<Regel> regels;
        
        // De potentiële uitkomsten van een zet.
        public enum ZetResultaat {
            Niets,
            PakStenenVoorThuiskuiltje,
            VerderSpelen,
            VolgendeSpeler,
            PakStenenTegenover,
            DoorSpreiden }

        // Het speelbord.
        protected Bord bord;
        
        // Een counter om het beurtnummer bij te houden.
        protected int beurtNummer;

        // Maakt een nieuw spel aan.
        public void InitialiseerSpel(int aantalKuiltjes, int aantalSteentjes, bool thuisSpreiden)
        {
            huidigeSpeler = Speler.Speler1;
            bord = new Bord(aantalKuiltjes, aantalSteentjes, true, thuisSpreiden);
            beurtNummer = 1;

            Program.ui.GeefWeer("\n\n\nLaat het spel beginnen!\n");
            Beurt();
        }

        // Doe een beurt van het spel, waarbij de speler wordt gevraagd een zet te doen en het spel geupdate wordt.
        protected void Beurt()
        {
            Program.ui.GeefWeer("\n\n- Beurt " + beurtNummer + " -" + "\n");

            bord.PrintBord(huidigeSpeler);

            if (huidigeVariant.IsFinished(bord, huidigeSpeler))
                EindigSpel();

            Program.ui.GeefWeer("\n" + huidigeSpeler + " is aan zet." + "\nKies een kuiltje.");
            Kuiltje laatsteKuiltje = Zet();

            List<ZetResultaat> zetResultaten = CheckRegels(huidigeSpeler, laatsteKuiltje);
            VoerZetResultatenUit();

            // Gaat de lijst met zet acties langs en voert deze uit.
            void VoerZetResultatenUit()
            {
                Speler spelerIt = bord.GetSpelerIt(laatsteKuiltje);
                int kuiltjeIt = bord.GetKuiltjeIt(laatsteKuiltje);

                foreach (ZetResultaat actie in zetResultaten)
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
                            bord.PaktStenenVoorThuisKuiltje(huidigeSpeler, bord.GetTegenover(kuiltjeIt, huidigeSpeler));
                            break;
                        case ZetResultaat.DoorSpreiden:
                            bord.BlijfSpreiden(spelerIt, kuiltjeIt, huidigeSpeler);
                            volgendeSpeler = NextSpeler(huidigeSpeler);
                            break;
                        case ZetResultaat.Niets:
                            break;
                    }
                }
            }
            beurtNummer++;
            huidigeSpeler = volgendeSpeler;
            Beurt();
        }

        // Verkrijg de volgende speler.
        protected Speler NextSpeler(Speler s)
        {
            if (s == Speler.Speler1)
                return Speler.Speler2;
            else
                return Speler.Speler1;
        }

        // Doe een zet door een kuiltje te kiezen en het bord te updaten.
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

        // Ga alle spelregels van de gebruikte variant langs om te kijken of er een van toepassing is.
        protected List<ZetResultaat> CheckRegels(Speler huidigeSpeler, Kuiltje laatsteKuiltje)
        {
            List<ZetResultaat> zetResultaten = new List<ZetResultaat>();
            foreach (Regel regel in regels)
            {
                if (regel.CheckTrigger(bord, huidigeSpeler, laatsteKuiltje))
                {
                    Program.ui.GeefWeer("Laatste steen eindigde in " + regel.naam);
                    foreach (ZetResultaat zetResultaat in regel.zetResultaten)
                        zetResultaten.Add(zetResultaat);
                }
            }

            if (zetResultaten.Count == 0)
                zetResultaten.Add(ZetResultaat.VolgendeSpeler);

            return zetResultaten;
        }

        // Beëindig het spel en geef de winnaar weer.
        protected void EindigSpel()
        {
            int s1Punten = bord.s1VerzamelKuiltje.GetAantalSteentjes();
            int s2Punten = bord.s2VerzamelKuiltje.GetAantalSteentjes();

            if (s1Punten > s2Punten)
                Program.ui.GeefWeer("Speler 1 is de winnaar!");
            else if (s2Punten > s1Punten)
                Program.ui.GeefWeer("Speler 2 is de winnaar!");
            else
                Program.ui.GeefWeer("Het is een gelijk spel!");

            Program.VraagRematch();
        }

        // Setter voor regels.
        public void SetRegels(List<Regel> rs)
        {
            regels = rs;
        }
    }
}
