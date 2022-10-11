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

namespace Application.Features.ProgrammingLanguages.Commands
{
    public class UpdateProgrammingLanguagesCommand : IRequest<UpdateProgrammingLanguagesDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateProgrammingLanguagesCommandHandler : IRequestHandler<UpdateProgrammingLanguagesCommand, UpdateProgrammingLanguagesDto>
        {
            private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguagesBusinessRules _programmingLanguagesBusinessRules;

            public UpdateProgrammingLanguagesCommandHandler(IProgrammingLanguagesRepository programmingLanguagesRepository, IMapper mapper, ProgrammingLanguagesBusinessRules programmingLanguagesBusinessRules)
            {
                _programmingLanguagesRepository = programmingLanguagesRepository;
                _mapper = mapper;
                _programmingLanguagesBusinessRules = programmingLanguagesBusinessRules;
            }

            public async Task<UpdateProgrammingLanguagesDto> Handle(UpdateProgrammingLanguagesCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgrammingLanguages? programmingLanguages = await _programmingLanguagesRepository.GetAsync(programming => programming.Id == request.Id);
                _programmingLanguagesBusinessRules.ProgrammingLanguagesShouldExistWhenRequested(programmingLanguages);

                programmingLanguages.Name = request.Name;
                Domain.Entities.ProgrammingLanguages updateProgrammingLanguage = await _programmingLanguagesRepository.UpdateAsync(programmingLanguages);
                UpdateProgrammingLanguagesDto updateProgrammingLanguagesDto = _mapper.Map<UpdateProgrammingLanguagesDto>(updateProgrammingLanguage);

                return updateProgrammingLanguagesDto;
            }
        }
    }
}
