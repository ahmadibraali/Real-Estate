using Real_Estate.Application.ViewModels.TypeOfProperties;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface ITypeOfPropertiesService : IGenericService<SaveTypeOfPropertiesViewModel, TypeOfPropertiesViewModel, TypeOfProperties>
    {
    }
}
