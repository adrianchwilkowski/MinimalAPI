namespace MinimalApiProject.Models
{
    public class Osoby
    {
        public Guid ID { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public DateTime DataUrodzenia { get; set; }
        public string Adres { get; set; } = null!;
    }
}
