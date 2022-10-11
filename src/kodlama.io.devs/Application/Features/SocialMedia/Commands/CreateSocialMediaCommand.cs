using Application.Features.SocialMedia.Dtos;
using Application.Features.SocialMedia.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.Commands
{
    public class CreateSocialMediaCommand : IRequest<CreateSocialMediaDto>
    {
        public string Name { get; set; }
        public string Url { get; set; }

        public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, CreateSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public CreateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper,
                SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<CreateSocialMediaDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                await _socialMediaBusinessRules.SocialMediaNameCanNotBeDuplicatedWhenInserted(request.Name);
                Domain.Entities.SocialMedia socialMedia = _mapper.Map<Domain.Entities.SocialMedia>(request);
                Domain.Entities.SocialMedia addSocialMedia = await _socialMediaRepository.AddAsync(socialMedia);
                CreateSocialMediaDto createSocialMediaDto = _mapper.Map<CreateSocialMediaDto>(addSocialMedia);
                return createSocialMediaDto;
            }
        }
    }
}
