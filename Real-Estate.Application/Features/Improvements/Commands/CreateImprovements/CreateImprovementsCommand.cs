using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;


namespace Real_Estate.Application.Features.Improvements.Commands.CreateImprovements
{
    using Real_Estate.Domain.Entities;
    using Swashbuckle.AspNetCore.Annotations;

    public class CreateImprovementsCommand : IRequest<int>
    {
        //public int Id { get; set; }
        [SwaggerParameter(Description = "Name of the improvement")]
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [SwaggerParameter(Description = "Description of the improvement")]
        [Required(ErrorMessage = "Descripcion is required.")]
        public string Description { get; set; }
    }

    public class CreateImprovementsCommandHandler : IRequestHandler<CreateImprovementsCommand, int>
    {
        private readonly IImprovementsRepository _improvementsRepository;
        private readonly IMapper _mapper;
        public CreateImprovementsCommandHandler(IImprovementsRepository improvementsRepository, IMapper mapper)
        {
            _improvementsRepository = improvementsRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateImprovementsCommand command, CancellationToken cancellationToken)
        {
            var improvements = _mapper.Map<Improvements>(command);
            improvements = await _improvementsRepository.AddAsync(improvements);
            return improvements.Id;
        }
    }

}
