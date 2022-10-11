using Application.Features.ProgrammingLanguages.Dtos;
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

namespace Application.Features.SocialMedia.Querys.GetSocialMediaById
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdDto>
    {
        public int Id { get; set; }

        public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public GetSocialMediaByIdQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper,
                SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<GetSocialMediaByIdDto> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
            {

                Domain.Entities.SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(x => x.Id == request.Id);
                _socialMediaBusinessRules.SocialMediaShouldExistWhenRequested(socialMedia);
                GetSocialMediaByIdDto mappedSocialMediaGetByIdDto = _mapper.Map<GetSocialMediaByIdDto>(socialMedia);
                return mappedSocialMediaGetByIdDto;
            }
        }
    }
}
