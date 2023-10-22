using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Context;
using Real_Estate.Domain.Entities;
using Real_Estate.Infrastructure.Repository;

namespace Real_Estate.Infrastructure.Repositories
{
    internal class PropertiesImprovementsRepository : GenericRepository<PropertiesImprovements>, IPropertiesImprovementsRepository
    {
        private readonly AppDbContext _dbContext;

        public PropertiesImprovementsRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }

}
