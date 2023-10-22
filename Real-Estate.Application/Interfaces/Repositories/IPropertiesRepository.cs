using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Interfaces.Repositories
{
    public interface IPropertiesRepository : IGenericRepository<Properties>
    {
        Task AddImprovementsToProperties(Properties property);
        Task UpdateImprovementsToProperties(Properties property);
        Task DeleteImprovementsToProperties(int id);

    }
}
