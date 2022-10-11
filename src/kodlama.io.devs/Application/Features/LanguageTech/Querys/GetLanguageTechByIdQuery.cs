using Application.Features.LanguageTech.Dtos;
using Application.Services.Repositories;
using Domain.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.LanguageTech.Rules;

namespace Application.Features.LanguageTech.Querys
{
    public class GetLanguageTechByIdQuery : IRequest<GetLanguageTechByIdDto>
    {
        public int Id { get; set; }

        public class GetLanguageTechByIdQueryHandler : IRequestHandler<GetLanguageTechByIdQuery, GetLanguageTechByIdDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechBusinessRules _languageTechBusinessRules;

            public GetLanguageTechByIdQueryHandler(ILanguageTechRepository languageTechRepository, IMapper mapper,
                LanguageTechBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<GetLanguageTechByIdDto> Handle(GetLanguageTechByIdQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.LanguageTech? languageTech = await _languageTechRepository.GetAsync(x => x.Id == request.Id);
                _languageTechBusinessRules.LanguageTechMustExistWhenRequested(languageTech);
                GetLanguageTechByIdDto getLanguageTechByIdDto = _mapper.Map<GetLanguageTechByIdDto>(languageTech);
                return getLanguageTechByIdDto;
            }
        }
    }
}
