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

namespace Application.Features.LanguageTech.Commands.CreateLanguageTech
{
    public class CreateLanguageTechCommand : IRequest<CreateLanguageTechDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public string Name { get; set; }

        public class CreateLanguageTechCommandHandler : IRequestHandler<CreateLanguageTechCommand, CreateLanguageTechDto>
        {
            private readonly ILanguageTechRepository _languageTechRepository;
            private readonly IMapper _mapper;
            private readonly LanguageTechBusinessRules _languageTechBusinessRules;

            public CreateLanguageTechCommandHandler(ILanguageTechRepository languageTechRepository, IMapper mapper,
                LanguageTechBusinessRules languageTechBusinessRules)
            {
                _languageTechRepository = languageTechRepository;
                _mapper = mapper;
                _languageTechBusinessRules = languageTechBusinessRules;
            }

            public async Task<CreateLanguageTechDto> Handle(CreateLanguageTechCommand request, CancellationToken cancellationToken)
            {
                await _languageTechBusinessRules.LanguageTechCannotBeDuplicatedWhenInsertedOrUpdated(request.Name);

                Domain.Entities.LanguageTech languageTech = _mapper.Map<Domain.Entities.LanguageTech>(request); 
                Domain.Entities.LanguageTech createLanguageTech = await _languageTechRepository.AddAsync(languageTech);
                CreateLanguageTechDto createLanguageTechDto = _mapper.Map<CreateLanguageTechDto>(createLanguageTech);
                return createLanguageTechDto;

                // 1=> request'den gelen veriyi map ediyoruz.
                // 2=> Entity mize veriyi ekliyoruz.
                // 3=> Entity mizden gelen veriyi map adiyoruz.
                // 4=> 3. Adımda map ettiğimiz veriyi return ediyoruz.
                



                throw new NotImplementedException();
            }
        }
    }
}
