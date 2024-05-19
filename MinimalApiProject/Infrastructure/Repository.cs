namespace MinimalApiProject.Infrastructure
{
    public class Repository
    {
        private readonly ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
