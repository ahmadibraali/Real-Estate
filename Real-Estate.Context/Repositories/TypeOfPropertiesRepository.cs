using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Domain.Entities;


namespace Real_Estate.Context.Repositories
{
    public class TypeOfPropertiesRepository : GenericRepository<TypeOfProperties>, ITypeOfPropertiesRepository
    {
        private readonly AppDbContext _dbContext;

        public TypeOfPropertiesRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
