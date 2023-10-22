using Real_Estate.Application.ViewModels.Improvements;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface IImprovementsService : IGenericService<SaveImprovementsViewModel, ImprovementsViewModel, Improvements>
    {
    }
}
