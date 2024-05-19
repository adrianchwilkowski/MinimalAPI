using MinimalApiProject.Models;

namespace MinimalApiProject.Commands
{
    public class AddOsoby
    {
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public DateTime DataUrodzenia { get; set; }
        public string Adres { get; set; } = null!;
        public Osoby ToOsoby()
        {
            return new Osoby
            {
                ID = Guid.NewGuid(),
                Imie = Imie,
                Nazwisko = Nazwisko,
                Adres = Adres,
                DataUrodzenia = DataUrodzenia
            };
        }
    }
}
