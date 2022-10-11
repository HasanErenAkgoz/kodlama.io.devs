using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguagesBusinessRules
    {
        private readonly IProgrammingLanguagesRepository _programmingLanguagesRepository;
        public ProgrammingLanguagesBusinessRules(IProgrammingLanguagesRepository programmingLanguagesRepository)
        {
            _programmingLanguagesRepository = programmingLanguagesRepository;
        }
        public async Task ProgrammingLanguagesNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.ProgrammingLanguages> result = await _programmingLanguagesRepository.GetListAsync(programming => programming.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming name exists.");
        }

        public async Task ProgrammingLanguagesShouldExistWhenRequested(Domain.Entities.ProgrammingLanguages programmingLanguages)
        {
            if (programmingLanguages == null) throw new BusinessException("Requested Programming Languages does not exist.");
        }
    }
}
