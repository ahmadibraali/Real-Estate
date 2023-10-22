using AutoMapper;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.Interfaces.Services;
using Real_Estate.Application.ViewModels.Improvements;
using Real_Estate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Services
{
    public class ImprovementsService: GenericService<SaveImprovementsViewModel, ImprovementsViewModel, Improvements>, IImprovementsService
    {
        private readonly IGenericRepository<Improvements> _repository;
        private readonly IMapper _mapper;
        public ImprovementsService(IGenericRepository<Improvements> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
    }
}
