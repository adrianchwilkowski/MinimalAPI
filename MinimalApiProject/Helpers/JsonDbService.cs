using MinimalApiProject.Infrastructure;
using MinimalApiProject.Infrastructure.Models;
using Newtonsoft.Json;

namespace MinimalApiProject.Helpers
{
    public class JsonDbService
    {
        private readonly string _filePath;
        private readonly ApplicationDbContext _context;
        public JsonDbService(ApplicationDbContext context, string filePath) { 
            _context = context;
            _filePath = filePath;
        }

        public List<Osoby> LoadData()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Osoby>();
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Osoby>>(jsonData) ?? new List<Osoby>();
        }

        public void SaveData()
        {
            var users = _context.Osoby.ToList();
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
