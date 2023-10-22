using AutoMapper;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.PropertiesImprovements;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Services
{
    public class PropertiesImprovementsService : GenericService<SavePropertiesImprovementsViewModel, PropertiesImprovementsViewModel, PropertiesImprovements>, IPropertiesImprovementsService
    {
        private readonly IGenericRepository<PropertiesImprovements> _repository;
        private readonly IMapper _mapper;
        public PropertiesImprovementsService(IGenericRepository<PropertiesImprovements> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
