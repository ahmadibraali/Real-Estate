using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.TypeOfSales.Commands.UpdateTypeOfSales
{
    using Real_Estate.Domain.Entities;
    using Swashbuckle.AspNetCore.Annotations;
    using System.ComponentModel.DataAnnotations;

    public class TypeOfSalesUpdateCommand : IRequest<TypeOfSalesUpdateResponse>
    {
        public int Id { get; set; }
        [SwaggerParameter(Description = "Sales type name")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is Required.")]
        [SwaggerParameter(Description = "Sales type descripcion")]
        public string Description { get; set; }
    }

    public class UpdateTypeOfSalesCommandHandler : IRequestHandler<TypeOfSalesUpdateCommand, TypeOfSalesUpdateResponse>
    {
        private readonly ITypeOfSalesRepository _typeOfSalesRepository;
        private readonly IMapper _mapper;
        public UpdateTypeOfSalesCommandHandler(ITypeOfSalesRepository improvementRepository, IMapper mapper)
        {
            _typeOfSalesRepository = improvementRepository;
            _mapper = mapper;
        }
        public async Task<TypeOfSalesUpdateResponse> Handle(TypeOfSalesUpdateCommand command, CancellationToken cancellationToken)
        {
            var improvement = await _typeOfSalesRepository.GetByIdAsync(command.Id);

            if (improvement == null) throw new Exception("type was not found.");

            improvement = _mapper.Map<TypeOfSales>(command);

            await _typeOfSalesRepository.UpdateAsync(improvement, improvement.Id);

            var improvementResponse = _mapper.Map<TypeOfSalesUpdateResponse>(improvement);

            return improvementResponse;
        }
    }
    
}
