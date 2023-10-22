using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace Real_Estate.Application.Features.TypeOfSales.Commands.CreateTypeOfSales
{
    using Real_Estate.Domain.Entities;
   

    public class CreateTypeOfSalesCommand : IRequest<int>
    {
        //public int Id { get; set; }
        [SwaggerParameter(Description = "Sales type name")]
        [Required(ErrorMessage = "name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required.")]
        [SwaggerParameter(Description = "Sales type description")]
        public string Description { get; set; }
    }

    public class CreateTypeOfSalesCommandHandler : IRequestHandler<CreateTypeOfSalesCommand, int>
    {
        private readonly ITypeOfSalesRepository _improvementsRepository;
        private readonly IMapper _mapper;
        public CreateTypeOfSalesCommandHandler(ITypeOfSalesRepository improvementsRepository, IMapper mapper)
        {
            _improvementsRepository = improvementsRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateTypeOfSalesCommand command, CancellationToken cancellationToken)
        {
            var improvements = _mapper.Map<TypeOfSales>(command);
            improvements = await _improvementsRepository.AddAsync(improvements);
            return improvements.Id;
        }
    }
}
