using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Querys.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguagesQuery:IRequest<GetByIdProgrammingLanguages>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguagesQueryHandler : IRequestHandler<GetByIdProgrammingLanguagesQuery, GetByIdProgrammingLanguages>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

            public GetByIdProgrammingLanguagesQueryHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper,
                ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<GetByIdProgrammingLanguages> Handle(GetByIdProgrammingLanguagesQuery request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgrammingLanguages? language = await _programmingLanguagesRepository.GetAsync(lng => lng.Id == request.Id);
                _programmingLanguagesBusinessRules.ProgrammingLanguagesShouldExistWhenRequested(language);
                GetByIdProgrammingLanguages mappedLanguageGetByIdDto = _mapper.Map<GetByIdProgrammingLanguages>(language);

                return mappedLanguageGetByIdDto;
            }
        }
    }
}
