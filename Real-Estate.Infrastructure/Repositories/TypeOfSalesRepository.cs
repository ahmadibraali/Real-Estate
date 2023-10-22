using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Context;
using Real_Estate.Domain.Entities;
using Real_Estate.Infrastructure.Repository;

namespace Real_Estate.Infrastructure.Repositories
{
    public class TypeOfSalesRepository : GenericRepository<TypeOfSales>, ITypeOfSalesRepository
    {
        private readonly AppDbContext _dbContext;

        public TypeOfSalesRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
