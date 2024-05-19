﻿using MinimalApiProject.Models;

namespace MinimalApiProject.Contracts
{
    public class OsobyContract
    {
        public Guid ID { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string DataUrodzenia { get; set; } = null!;
        public string Adres { get; set; } = null!;
        public OsobyContract FromOsoby(Osoby osoba)
        {
            return new OsobyContract
            {
                ID = osoba.ID,
                Imie = osoba.Imie,
                Nazwisko = osoba.Nazwisko,
                DataUrodzenia = osoba.DataUrodzenia.FromDate(),
                Adres = osoba.Adres
            };
        }
    }
}