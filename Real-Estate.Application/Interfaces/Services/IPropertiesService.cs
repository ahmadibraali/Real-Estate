using Real_Estate.Application.ViewModels.Properties;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Interfaces.Services
{
    public interface IPropertiesService : IGenericService<SavePropertiesViewModel, PropertiesViewModel, Properties>
    {
        Task<PropertiesViewModel> GetByCode(string code);
        Task<PropertiesViewModel> GetByIdWithData(int id);
        Task<List<PropertiesViewModel>> GetAllWithData();
        Task<SavePropertiesViewModel> CustomAdd(SavePropertiesViewModel savePropertiesViewModel);
        Task<SaveAgentProfileViewModel> UpdateAgentProfile(SaveAgentProfileViewModel agentProfileViewModel);
        Task<SaveAgentProfileViewModel> GetAgentUserByUserNameAsync(string userName);
        Task<List<PropertiesViewModel>> GetAll();

        Task<SavePropertiesViewModel> AddWithImprovementsAsync(SavePropertiesViewModel savePropertiesViewModel);

        Task AddImprovementsAsync(SavePropertiesViewModel savePropertiesViewModel);
        Task<List<PropertiesViewModel>> GetAllWithInclude();
        Task<SavePropertiesViewModel> GetByIdWithInclude(int id);
        Task<List<PropertiesViewModel>> GetAllByAgentIdWithInclude(string agentId);

        Task UpdatePropertyWithImprovementsAsync(SavePropertiesViewModel savePropertiesViewModel, int id);
        Task<PropertyDetailsViewModel> GetPropertyDetailsAsync(int propertyId);
        Task<List<PropertiesViewModel>> GetAllWithFilters(FilterPropertiesViewModel filterPropertiesViewModel);

        Task DeleteImprovementsToProperties(int id);

    }
}
