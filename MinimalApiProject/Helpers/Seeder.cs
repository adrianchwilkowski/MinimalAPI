using MinimalApiProject.Infrastructure;
using MinimalApiProject.Infrastructure.Models;
using System.Collections.Generic;

namespace MinimalApiProject.Helpers
{
    public static class Seeder
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Osoby.Any())
            {
                context.Osoby.AddRange(
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Jan",
                Nazwisko = "Kowalski",
                DataUrodzenia = new DateTime(1985, 3, 12),
                Adres = "ul. Piękna 7, 00-001 Warszawa"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Anna",
                Nazwisko = "Nowak",
                DataUrodzenia = new DateTime(1990, 6, 25),
                Adres = "ul. Wesoła 15, 50-200 Wrocław"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Piotr",
                Nazwisko = "Wiśniewski",
                DataUrodzenia = new DateTime(1982, 9, 8),
                Adres = "ul. Kwiatowa 3, 30-001 Kraków"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Magdalena",
                Nazwisko = "Duda",
                DataUrodzenia = new DateTime(1975, 11, 19),
                Adres = "ul. Lipowa 12, 80-200 Gdańsk"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Krzysztof",
                Nazwisko = "Wójcik",
                DataUrodzenia = new DateTime(1988, 7, 4),
                Adres = "ul. Słoneczna 6, 20-300 Lublin"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Ewa",
                Nazwisko = "Mazur",
                DataUrodzenia = new DateTime(1983, 4, 17),
                Adres = "ul. Błękitna 9, 40-400 Katowice"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Marcin",
                Nazwisko = "Kaczmarek",
                DataUrodzenia = new DateTime(1995, 1, 30),
                Adres = "ul. Zielona 14, 70-500 Szczecin"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Aleksandra",
                Nazwisko = "Lis",
                DataUrodzenia = new DateTime(1980, 10, 22),
                Adres = "ul. Czerwona 8, 90-600 Łódź"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Adam",
                Nazwisko = "Sikora",
                DataUrodzenia = new DateTime(1978, 12, 7),
                Adres = "ul. Żółta 11, 60-700 Poznań"
            },
            new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = "Karolina",
                Nazwisko = "Witkowska",
                DataUrodzenia = new DateTime(1987, 8, 14),
                Adres = "ul. Granitowa 5, 10-800 Olsztyn"
            });
                context.SaveChanges();
            }
        }
    }
}
