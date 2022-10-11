using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Rules
{
    public class LanguageTechBusinessRules
    {
        private readonly ILanguageTechRepository _languageTechRepository;

        public LanguageTechBusinessRules(ILanguageTechRepository languageTechRepository)
        {
            _languageTechRepository = languageTechRepository;
        }

        public async Task LanguageTechCannotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<Domain.Entities.LanguageTech> entities = await _languageTechRepository.GetListAsync(x => x.Name == name, enableTracking: false);
            foreach (Domain.Entities.LanguageTech item in entities.Items)
            {
                if (item.Name == name) throw new BusinessException($"Programming language name {name} already exist.");
            }
        }
        public async Task LanguageTechMustExistWhenUpdatedOrDeleted(int id)
        {
            IPaginate<Domain.Entities.LanguageTech> entities = await _languageTechRepository.GetListAsync(x => x.Id == id, enableTracking: false);
            if (!entities.Items.Any()) throw new BusinessException($"Tech with {id} id  doesn't exists.");
        }
        public void LanguageTechMustExistWhenRequested(Domain.Entities.LanguageTech? languageTech)
        {
            if (languageTech is null) throw new BusinessException("Requested tech  doesn't exist");
        }
    }
}
