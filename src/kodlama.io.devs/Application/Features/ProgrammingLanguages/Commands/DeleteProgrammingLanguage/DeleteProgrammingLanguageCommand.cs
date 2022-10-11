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

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguagesDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLanguagesCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguagesDto>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;


            public DeleteProgrammingLanguagesCommandHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<DeleteProgrammingLanguagesDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {

                Domain.Entities.ProgrammingLanguages? language = await _programmingLanguagesRepository.GetAsync(lng => lng.Id == request.Id);
                _programmingLanguagesBusinessRules.ProgrammingLanguagesShouldExistWhenRequested(language);
                language.IsActive = false;
                Domain.Entities.ProgrammingLanguages deletedLanguage = await _programmingLanguagesRepository.UpdateAsync(language);
                DeleteProgrammingLanguagesDto deletedLanguageDto = _mapper.Map<DeleteProgrammingLanguagesDto>(deletedLanguage);
                return deletedLanguageDto;

            }
        }
    }
}
