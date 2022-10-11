using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;
        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }
        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.SocialMedia> result = await _socialMediaRepository.GetListAsync(socialMedia => socialMedia.Name == name);
            if (result.Items.Any()) throw new BusinessException("Social Media name exists.");
        }

        public async Task SocialMediaShouldExistWhenRequested(Domain.Entities.SocialMedia socialMedia)
        {
            if (socialMedia == null) throw new BusinessException("Requested Social Media does not exist.");
        }
        public async Task SocialMediaCannotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<Domain.Entities.SocialMedia> entities = await _socialMediaRepository.GetListAsync(x => x.Name == name, enableTracking: false);
            foreach (Domain.Entities.SocialMedia item in entities.Items)
            {
                if (item.Name == name) throw new BusinessException($"Social Media name {name} already exist.");
            }
        }

    }
}
