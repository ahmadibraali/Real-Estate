using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.TypeOfProperties.Commands.CreateTypeOfProperties
{
    using Real_Estate.Domain.Entities;
    using Swashbuckle.AspNetCore.Annotations;

    public class CreateTypeOfPropertiesCommand : IRequest<int>
    {
        //public int Id { get; set; }
        [SwaggerParameter(Description = "Property Name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [SwaggerParameter(Description = "Property Description")]
        [Required(ErrorMessage = "Description is required.")]
        public string Description { get; set; }
    }
     
    public class CreateTypeOfPropertiesCommandHandler : IRequestHandler<CreateTypeOfPropertiesCommand, int>
    {
        private readonly ITypeOfPropertiesRepository _typeOfPropertiesRepository;
        private readonly IMapper _mapper;
        public CreateTypeOfPropertiesCommandHandler(ITypeOfPropertiesRepository typeOfPropertiesRepository, IMapper mapper)
        {
            _typeOfPropertiesRepository = typeOfPropertiesRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateTypeOfPropertiesCommand command, CancellationToken cancellationToken)
        {
            var property = _mapper.Map<TypeOfProperties>(command);
            property = await _typeOfPropertiesRepository.AddAsync(property);
            return property.Id;
        }
    }
}
