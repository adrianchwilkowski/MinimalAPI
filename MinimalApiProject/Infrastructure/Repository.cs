using Microsoft.EntityFrameworkCore;
using MinimalApiProject.Infrastructure.Commands;
using MinimalApiProject.Infrastructure.Contracts;

namespace MinimalApiProject.Infrastructure
{
    public interface IRepository
    {
        Task<List<OsobyContract>> GetOsobyList();
        Task<OsobyContract> GetOsobaById(string id);
        Task<Guid> AddOsoba(AddOsoby osoba);

    }
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<OsobyContract>> GetOsobyList()
        {
            var result = await _dbContext.Osoby.ToListAsync();
            return result.Select(OsobyContract.FromOsoby).ToList();
        }
        public async Task<OsobyContract> GetOsobaById(string id) 
        {
            try
            {
                Guid guid;
                if(!Guid.TryParse(id, out guid))
                {
                    throw new ArgumentException("Podano zły format Id. ");
                }
                var result = await _dbContext.Osoby.Where(x => x.ID == guid).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new NullReferenceException("Osoba z podanym id nie istnieje. ");
                }
                return OsobyContract.FromOsoby(result);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
            
        }
        public async Task<Guid> AddOsoba(AddOsoby osoba)
        {
            var osobaToDomain = osoba.ToOsoby();
            await _dbContext.Osoby.AddAsync(osobaToDomain);
            await _dbContext.SaveChangesAsync();
            return osobaToDomain.ID;
        }
    }
}
