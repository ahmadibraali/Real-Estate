using Real_Estate.Application.ViewModels.PropertiesImprovements;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface IPropertiesImprovementsService : IGenericService<SavePropertiesImprovementsViewModel, PropertiesImprovementsViewModel, PropertiesImprovements>
    {
    }
}
