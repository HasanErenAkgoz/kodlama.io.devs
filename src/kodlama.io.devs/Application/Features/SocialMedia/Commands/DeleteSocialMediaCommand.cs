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
    public class DeleteSocialMediaCommand : IRequest<DeleteSocialMediaDto>
    {
        public int Id { get; set; }

        public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, DeleteSocialMediaDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public DeleteSocialMediaCommandHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper,
                SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<DeleteSocialMediaDto> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
                await _socialMediaBusinessRules.SocialMediaShouldExistWhenRequested(socialMedia);
                socialMedia.IsActive = false;
                Domain.Entities.SocialMedia deleteSocialMedia = await _socialMediaRepository.UpdateAsync(socialMedia);
                DeleteSocialMediaDto deleteSocialMediaDto = _mapper.Map<DeleteSocialMediaDto>(deleteSocialMedia);
                return deleteSocialMediaDto;
            }
        }
    }
}
