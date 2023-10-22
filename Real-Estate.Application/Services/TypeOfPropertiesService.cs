using AutoMapper;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.TypeOfProperties;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Services
{
    public class TypeOfPropertiesService : GenericService<SaveTypeOfPropertiesViewModel, TypeOfPropertiesViewModel, TypeOfProperties>, ITypeOfPropertiesService
    {
        private readonly IGenericRepository<TypeOfProperties> _repository;
        private readonly IMapper _mapper;
        public TypeOfPropertiesService(IGenericRepository<TypeOfProperties> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
