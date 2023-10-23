using Real_Estate.Application.Interfaces.Repositories;

using Real_Estate.Domain.Entities;


namespace Real_Estate.Context.Repositories
{
    public class ImprovementsRepository : GenericRepository<Improvements>, IImprovementsRepository
    {
        private readonly AppDbContext _dbContext;

        public ImprovementsRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
