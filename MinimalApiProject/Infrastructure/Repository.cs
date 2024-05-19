using Microsoft.EntityFrameworkCore;
using MinimalApiProject.Commands;
using MinimalApiProject.Contracts;
using MinimalApiProject.Models;

namespace MinimalApiProject.Infrastructure
{
    public class Repository
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
        public async Task<OsobyContract> GetOsobaById(Guid id) 
        {
            try
            {
                var result = await _dbContext.Osoby.Where(x => x.ID == id).FirstOrDefaultAsync();
                if (result == null)
                {
                    throw new NullReferenceException("Osoba z podanym id nie istnieje. ");
                }
                return OsobyContract.FromOsoby(result);
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
            
        }
        public async Task AddOsoba(AddOsoby osoba)
        {
            await _dbContext.Osoby.AddAsync(osoba.ToOsoby());
            await _dbContext.SaveChangesAsync();
        }
    }
}
