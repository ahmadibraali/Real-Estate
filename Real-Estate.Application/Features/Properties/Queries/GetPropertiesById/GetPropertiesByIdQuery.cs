using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.ViewModels.Properties;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Properties.Queries.GetPropertiesById
{
    public class GetPropertiesByIdQuery : IRequest<PropertiesViewModel>
    {
        [SwaggerParameter(Description = "Id of Property")]
        public int Id { get; set; }
    }
    public class GetPropertiesByIdQueryHandler : IRequestHandler<GetPropertiesByIdQuery, PropertiesViewModel>
    {
        private readonly IPropertiesRepository _PropertiesRepository;
        private readonly IMapper _mapper;

        public GetPropertiesByIdQueryHandler(IPropertiesRepository PropertiesRepository, IMapper mapper)
        {
            _PropertiesRepository = PropertiesRepository;
            _mapper = mapper;
        }

        public async Task<PropertiesViewModel> Handle(GetPropertiesByIdQuery query, CancellationToken cancellationToken)
        {
            var properties = await _PropertiesRepository.GetAllAsync();
            var property = properties.FirstOrDefault(x => x.Id == query.Id);
            if (property is null) throw new Exception("Property Is not found .");
            var result = await _PropertiesRepository.GetAllWithIncludeAsync(new List<string> { "Improvements", "TypeOfProperty", "TypeOfSale" });
            return _mapper.Map<PropertiesViewModel>(property);
        }
    }
    
}
