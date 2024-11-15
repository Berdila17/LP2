using System;
using System.Collections.Generic;
using System.Linq;

namespace Notenverwaltung
{
    public class Fach
    {
        public string Name { get; set; }
        public List<int> Noten { get; set; } = new List<int>();

        public double Durchschnittsnote()
        {
            // Berechnet den Durchschnitt der Noten, falls vorhanden
            return Noten.Count > 0 ? Noten.Average() : 0.0;
        }
    }

    public class Schüler
    {
        public string Name { get; set; }
        public string Klasse { get; set; }
        public List<Fach> Fächer { get; set; } = new List<Fach>();

        public void FachHinzufügen(string fachName)
        {
            if (Fächer.Any(f => f.Name == fachName))
            {
                Console.WriteLine("Dieses Fach existiert bereits für den Schüler.");
            }
            else
            {
                Fächer.Add(new Fach { Name = fachName });
                Console.WriteLine($"Fach '{fachName}' wurde erfolgreich hinzugefügt.");
            }
        }

        public void NoteHinzufügen(string fachName, int note)
        {
            try
            {
                Fach fach = Fächer.FirstOrDefault(f => f.Name == fachName);
                if (fach != null)
                {
                    if (note >= 1 && note <= 6)
                    {
                        fach.Noten.Add(note);
                        Console.WriteLine($"Note {note} wurde zu '{fachName}' hinzugefügt.");
                    }
                    else
                    {
                        Console.WriteLine("Die Note muss zwischen 1 und 6 liegen.");
                    }
                }
                else
                {
                    Console.WriteLine("Das Fach existiert nicht. Bitte zuerst das Fach hinzufügen.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Hinzufügen der Note: " + ex.Message);
            }
        }

        public void NotenAnzeigen(string fachName)
        {
            try
            {
                Fach fach = Fächer.FirstOrDefault(f => f.Name == fachName);
                if (fach != null)
                {
                    if (fach.Noten.Count > 0)
                    {
                        Console.WriteLine($"Noten in '{fachName}': {string.Join(", ", fach.Noten)}");
                    }
                    else
                    {
                        Console.WriteLine($"Keine Noten in '{fachName}' verfügbar.");
                    }
                }
                else
                {
                    Console.WriteLine("Das Fach existiert nicht.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Anzeigen der Noten: " + ex.Message);
            }
        }

        public void DurchschnittsnoteAnzeigen(string fachName)
        {
            try
            {
                Fach fach = Fächer.FirstOrDefault(f => f.Name == fachName);
                if (fach != null)
                {
                    double durchschnitt = fach.Durchschnittsnote();
                    Console.WriteLine($"Durchschnittsnote in '{fachName}': {durchschnitt:0.00}");
                }
                else
                {
                    Console.WriteLine("Das Fach existiert nicht.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Berechnen der Durchschnittsnote: " + ex.Message);
            }
        }

        public double Gesamtdurchschnitt()
        {
            var alleNoten = Fächer.SelectMany(f => f.Noten).ToList();
            return alleNoten.Count > 0 ? alleNoten.Average() : 0.0;
        }

        public void GesamtdurchschnittAnzeigen()
        {
            try
            {
                double gesamtdurchschnitt = Gesamtdurchschnitt();
                Console.WriteLine($"Gesamtnotenschnitt für alle Fächer: {gesamtdurchschnitt:0.00}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Berechnen des Gesamtdurchschnitts: " + ex.Message);
            }
        }
    }

    class Program
    {
        static List<Schüler> schülerListe = new List<Schüler>();

        static void Main(string[] args)
        {
            bool laufend = true;
            while (laufend)
            {
                Console.WriteLine("----- Notenverwaltungssystem -----");
                Console.WriteLine("1. Schüler hinzufügen");
                Console.WriteLine("2. Fach hinzufügen");
                Console.WriteLine("3. Note hinzufügen");
                Console.WriteLine("4. Noten anzeigen");
                Console.WriteLine("5. Durchschnittsnote anzeigen");
                Console.WriteLine("6. Gesamtnotenschnitt anzeigen");
                Console.WriteLine("7. Beenden");
                Console.Write("Option auswählen: ");

                string auswahl = Console.ReadLine();

                switch (auswahl)
                {
                    case "1":
                        SchülerHinzufügen();
                        break;
                    case "2":
                        FachHinzufügen();
                        break;
                    case "3":
                        NoteHinzufügen();
                        break;
                    case "4":
                        NotenAnzeigen();
                        break;
                    case "5":
                        DurchschnittsnoteAnzeigen();
                        break;
                    case "6":
                        GesamtdurchschnittAnzeigen();
                        break;
                    case "7":
                        laufend = false;
                        Console.WriteLine("Programm beendet.");
                        break;
                    default:
                        Console.WriteLine("Ungültige Auswahl. Bitte erneut versuchen.");
                        break;
                }
            }
        }

        static void SchülerHinzufügen()
        {
            try
            {
                Console.Write("Geben Sie den Namen des Schülers ein: ");
                string name = Console.ReadLine();
                Console.Write("Geben Sie die Klasse des Schülers ein: ");
                string klasse = Console.ReadLine();

                Schüler neuerSchüler = new Schüler
                {
                    Name = name,
                    Klasse = klasse
                };

                schülerListe.Add(neuerSchüler);
                Console.WriteLine("Schüler erfolgreich hinzugefügt.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Hinzufügen des Schülers: " + ex.Message);
            }
        }

        static Schüler SchülerSuchen(string name)
        {
            return schülerListe.FirstOrDefault(s => s.Name == name);
        }

        static void FachHinzufügen()
        {
            Console.Write("Geben Sie den Namen des Schülers ein: ");
            string name = Console.ReadLine();
            Schüler schüler = SchülerSuchen(name);

            if (schüler != null)
            {
                Console.Write("Geben Sie den Namen des Faches ein: ");
                string fachName = Console.ReadLine();
                schüler.FachHinzufügen(fachName);
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

        static void NoteHinzufügen()
        {
            Console.Write("Geben Sie den Namen des Schülers ein: ");
            string name = Console.ReadLine();
            Schüler schüler = SchülerSuchen(name);

            if (schüler != null)
            {
                Console.Write("Geben Sie den Namen des Faches ein: ");
                string fachName = Console.ReadLine();
                Console.Write("Geben Sie die Note ein (1-6): ");
                if (int.TryParse(Console.ReadLine(), out int note))
                {
                    schüler.NoteHinzufügen(fachName, note);
                }
                else
                {
                    Console.WriteLine("Ungültige Eingabe. Bitte geben Sie eine Zahl zwischen 1 und 6 ein.");
                }
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

        static void NotenAnzeigen()
        {
            Console.Write("Geben Sie den Namen des Schülers ein: ");
            string name = Console.ReadLine();
            Schüler schüler = SchülerSuchen(name);

            if (schüler != null)
            {
                Console.Write("Geben Sie den Namen des Faches ein: ");
                string fachName = Console.ReadLine();
                schüler.NotenAnzeigen(fachName);
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

        static void DurchschnittsnoteAnzeigen()
        {
            Console.Write("Geben Sie den Namen des Schülers ein: ");
            string name = Console.ReadLine();
            Schüler schüler = SchülerSuchen(name);

            if (schüler != null)
            {
                Console.Write("Geben Sie den Namen des Faches ein: ");
                string fachName = Console.ReadLine();
                schüler.DurchschnittsnoteAnzeigen(fachName);
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }

        static void GesamtdurchschnittAnzeigen()
        {
            Console.Write("Geben Sie den Namen des Schülers ein: ");
            string name = Console.ReadLine();
            Schüler schüler = SchülerSuchen(name);

            if (schüler != null)
            {
                schüler.GesamtdurchschnittAnzeigen();
            }
            else
            {
                Console.WriteLine("Schüler nicht gefunden.");
            }
        }
    }
}

