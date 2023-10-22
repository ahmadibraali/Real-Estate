using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.ViewModels.TypeOfSales;
using Swashbuckle.AspNetCore.Annotations;

namespace Real_Estate.Application.Features.TypeOfSales.Queries.GetTypeOfSalesById
{
    public class GetTypeOfSalesByIdQuery : IRequest<TypeOfSalesViewModel>
    {
        [SwaggerParameter(Description = "Sales type Id")]
        public int Id { get; set; }
    }
    public class GetTypeOfSalesByIdQueryHandler : IRequestHandler<GetTypeOfSalesByIdQuery, TypeOfSalesViewModel>
    {
        private readonly ITypeOfSalesRepository _TypeOfSalesRepository;
        private readonly IMapper _mapper;

        public GetTypeOfSalesByIdQueryHandler(ITypeOfSalesRepository TypeOfSalesRepository, IMapper mapper)
        {
            _TypeOfSalesRepository = TypeOfSalesRepository;
            _mapper = mapper;
        }

        public async Task<TypeOfSalesViewModel> Handle(GetTypeOfSalesByIdQuery query, CancellationToken cancellationToken)
        {
            var TypeOfSale = await _TypeOfSalesRepository.GetByIdAsync(query.Id);
            if (TypeOfSale is null) throw new Exception("type was not found.");
            var result = _mapper.Map<TypeOfSalesViewModel>(TypeOfSale);
            return result;
        }
    }

}
