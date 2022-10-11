using Application.Features.LanguageTech.Dtos;
using Application.Features.LanguageTech.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Commands.UpdateLanguageTech
{
    public class UpdateLanguageTechCommand : IRequest<UpdateLanguageTechDto>
    {
        public int Id { get; set; }
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class UpdateLanguageTechCommandHandler : IRequestHandler<UpdateLanguageTechCommand, UpdateLanguageTechDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechBusinessRules _languageTechBusinessRules;

            public UpdateLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper
                , LanguageTechBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<UpdateLanguageTechDto> Handle(UpdateLanguageTechCommand request, CancellationToken cancellationToken)
            {
                await _languageTechBusinessRules.LanguageTechMustExistWhenUpdatedOrDeleted(request.Id);
                await _languageTechBusinessRules.LanguageTechCannotBeDuplicatedWhenInsertedOrUpdated(request.Name);
                Domain.Entities.LanguageTech? languageTech = await _languageTechRepository.GetAsync(x => x.Id == request.Id);

                languageTech.Name = request.Name;
                languageTech.ProgrammingLanguageId = request.ProgrammingLanguageId;

                Domain.Entities.LanguageTech updateLanguageTech = await _languageTechRepository.UpdateAsync(languageTech);
                UpdateLanguageTechDto updateLanguageTechDto = _mapper.Map<UpdateLanguageTechDto>(updateLanguageTech);
                return updateLanguageTechDto;
            }
        }
    }
}
