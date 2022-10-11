using Application.Features.LanguageTech.Rules;
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

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommand : IRequest<CreateProgrammingLanguagesDto>
    {
        public string Name { get; set; }
    }

    public class CreateProgrammingLanguagesCommandHandler : IRequestHandler<CreateProgrammingLanguageCommand, CreateProgrammingLanguagesDto>
    {
        private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
        private readonly IMapper _mapper;
        private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

        public CreateProgrammingLanguagesCommandHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper, ProgrammingLanguagesBusinessRules brandBusinessRules)
        {
            _programmingLanguagesRepository = programmingLanguagesRepository;
            _mapper = mapper;
            _programmingLanguagesBusinessRules = brandBusinessRules;
        }

        public async Task<CreateProgrammingLanguagesDto> Handle(CreateProgrammingLanguageCommand request, CancellationToken cancellationToken)
        {
            await _programmingLanguagesBusinessRules.ProgrammingLanguagesNameCanNotBeDuplicatedWhenInserted(request.Name);

            Domain.Entities.ProgrammingLanguages mappedProgrammingLanguages = _mapper.Map<Domain.Entities.ProgrammingLanguages>(request);
            Domain.Entities.ProgrammingLanguages createProgrammingLanguage = await _programmingLanguagesRepository.AddAsync(mappedProgrammingLanguages);
            CreateProgrammingLanguagesDto createdBrandDto = _mapper.Map<CreateProgrammingLanguagesDto>(createProgrammingLanguage); // veritabanından gelen brand verisini dto'ya çevirdik

            return createdBrandDto;
        }
    }
}
