using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Querys.ProgrammingLanguageListCommand
{
    public class ProgrammingLanguageListQuery : IRequest<ProgrammingLanguagesListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class ProgrammingLanguagesListQueryHandler : IRequestHandler<ProgrammingLanguageListQuery, ProgrammingLanguagesListModel>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;

            public ProgrammingLanguagesListQueryHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguagesListModel> Handle(ProgrammingLanguageListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.ProgrammingLanguages> programmingLanguages = await _programmingLanguagesRepository.GetListAsync(x => x.IsActive == true, index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                ProgrammingLanguagesListModel mappedBrandListModel = _mapper.Map<ProgrammingLanguagesListModel>(programmingLanguages);
                return mappedBrandListModel;

            }
        }
    }
}
