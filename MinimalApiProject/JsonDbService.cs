using MinimalApiProject.Models;
using Newtonsoft.Json;

namespace MinimalApiProject
{
    public class JsonDbService
    {
        private readonly string _filePath = "data.json";

        public List<Osoby> LoadData()
        {
            if (!File.Exists(_filePath))
            {
                return new List<Osoby>();
            }

            var jsonData = File.ReadAllText(_filePath);
            return JsonConvert.DeserializeObject<List<Osoby>>(jsonData) ?? new List<Osoby>();
        }

        public void SaveData(List<Osoby> users)
        {
            var jsonData = JsonConvert.SerializeObject(users, Formatting.Indented);
            File.WriteAllText(_filePath, jsonData);
        }
    }
}
