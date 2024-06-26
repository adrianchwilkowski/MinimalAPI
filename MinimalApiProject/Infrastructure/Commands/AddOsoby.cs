﻿using MinimalApiProject.Helpers;
using MinimalApiProject.Infrastructure.Models;

namespace MinimalApiProject.Infrastructure.Commands
{
    public class AddOsoby
    {
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string DataUrodzenia { get; set; } = null!;
        public string Adres { get; set; } = null!;
        public Osoby ToOsoby()
        {
            if( String.IsNullOrEmpty(Imie) || String.IsNullOrEmpty(Nazwisko) || String.IsNullOrEmpty(Adres)) { throw new ArgumentException("Podano puste pole. ");  }
            return new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = Imie,
                Nazwisko = Nazwisko,
                Adres = Adres,
                DataUrodzenia = DataUrodzenia.ToDate()
            };
        }
    }
}
