using Application.Features.LanguageTech.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Querys
{
    public class GetListLanguageTechQuery : IRequest<LanguageTechListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListLanguageTechQueryHandler : IRequestHandler<GetListLanguageTechQuery, LanguageTechListModel>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;

            public GetListLanguageTechQueryHandler(ILanguageTechRepository languageTechRepository, IMapper mapper)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
            }
            public async Task<LanguageTechListModel> Handle(GetListLanguageTechQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.LanguageTech> paginate = await _languageTechRepository.GetListAsync(
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize,
                    include: x => x.Include(y => y.ProgrammingLanguage));
                LanguageTechListModel languageTechListModel = _mapper.Map<LanguageTechListModel>(paginate);
                return languageTechListModel;


            }
        }
    }
}
