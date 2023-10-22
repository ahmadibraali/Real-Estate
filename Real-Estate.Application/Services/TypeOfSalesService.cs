using AutoMapper;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.TypeOfSales;
using Real_Estate.Domain.Entities;

namespace Real_Estate.Application.Services
{
    public class TypeOfSalesService : GenericService<SaveTypeOfSalesViewModel, TypeOfSalesViewModel, TypeOfSales>, ITypeOfSalesService
    {
        private readonly IGenericRepository<TypeOfSales> _repository;
        private readonly IMapper _mapper;
        public TypeOfSalesService(IGenericRepository<TypeOfSales> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
