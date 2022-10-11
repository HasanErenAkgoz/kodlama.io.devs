using Application.Features.SocialMedia.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.Querys.SocialMediaList
{
    public class SocialMediaListQuery : IRequest<SocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class SocialMediaListQueryHandler : IRequestHandler<SocialMediaListQuery, SocialMediaListModel>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public SocialMediaListQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaListModel> Handle(SocialMediaListQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.SocialMedia> socialMedia = await _socialMediaRepository.GetListAsync(x => x.IsActive == true,
                    index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                SocialMediaListModel mappedSocialMediaModel = _mapper.Map<SocialMediaListModel>(socialMedia);
                return mappedSocialMediaModel;
            }
        }
    }
}
