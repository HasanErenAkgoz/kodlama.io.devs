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

namespace Application.Features.LanguageTech.Commands.DeleteLanguageTech
{
    public class DeleteLanguageTechCommand : IRequest<DeleteLanguageTechDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageTechCommandHandler : IRequestHandler<DeleteLanguageTechCommand, DeleteLanguageTechDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechBusinessRules _languageTechBusinessRules;
            public DeleteLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper,
                LanguageTechBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<DeleteLanguageTechDto> Handle(DeleteLanguageTechCommand request, CancellationToken cancellationToken)
            {
                await _languageTechBusinessRules.LanguageTechMustExistWhenUpdatedOrDeleted(request.Id);
                Domain.Entities.LanguageTech entityToDelete = _mapper.Map<Domain.Entities.LanguageTech>(request);
                Domain.Entities.LanguageTech deleteLanguageTech = await _languageTechRepository.DeleteAsync(entityToDelete);
                DeleteLanguageTechDto deleteLanguageTechDto = _mapper.Map<DeleteLanguageTechDto>(deleteLanguageTech);
                return deleteLanguageTechDto;
            }
        }
    }
}
