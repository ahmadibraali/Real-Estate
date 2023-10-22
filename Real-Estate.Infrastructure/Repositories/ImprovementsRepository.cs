using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Context;
using Real_Estate.Domain.Entities;
using Real_Estate.Infrastructure.Repository;

namespace Real_Estate.Infrastructure.Repositories
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
