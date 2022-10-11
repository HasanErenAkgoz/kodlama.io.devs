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
    public class UpdateSocialMediaCommand : IRequest<UpdateSocialMediaDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, UpdateSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public UpdateSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper
                , SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<UpdateSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
                await _socialMediaBusinessRules.SocialMediaShouldExistWhenRequested(socialMedia);

                socialMedia.Name = request.Name;
                socialMedia.Url = request.Url;

                Domain.Entities.SocialMedia updateSocialMedia = await _socialMediaRepository.UpdateAsync(socialMedia);
                UpdateSocialMediaDto updateSocialMediaDto = _mapper.Map<UpdateSocialMediaDto>(updateSocialMedia);
                return updateSocialMediaDto;
            }
        }
    }
}
