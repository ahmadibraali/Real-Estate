﻿using AutoMapper;
using MediatR;
using Real_Estate.Application.Interfaces.Repositories;
using Real_Estate.Application.ViewModels.Improvements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Real_Estate.Application.Features.Improvements.Queries.GetAllImprovements
{
    public class GetAllImprovementsQuery : IRequest<IEnumerable<ImprovementsViewModel>>
    {
        public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllImprovementsQuery, IEnumerable<ImprovementsViewModel>>
        {

            private readonly IImprovementsRepository _ImprovementsRepository;
            private readonly IMapper _mapper;
            public GetAllCategoriesQueryHandler(IImprovementsRepository ImprovementsRepository, IMapper mapper)
            {
                _ImprovementsRepository = ImprovementsRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ImprovementsViewModel>> Handle(GetAllImprovementsQuery request, CancellationToken cancellationToken)
            {
                var ImprovementsViewModel = await GetAllViewModel();
                return ImprovementsViewModel;
            }

            private async Task<List<ImprovementsViewModel>> GetAllViewModel()
            {
                var ImprovementList = await _ImprovementsRepository.GetAllAsync();
                if (ImprovementList.Count() == 0) throw new Exception("No Improvments.");
                var result = _mapper.Map<List<ImprovementsViewModel>>(ImprovementList);
                return result;
            }
        }
    }
}
