using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Commands.UpdateLanguageTech
{
    public class UpdateLanguageTechCommandValidator:AbstractValidator<UpdateLanguageTechCommand>
    {
        public UpdateLanguageTechCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.ProgrammingLanguageId).NotEmpty();
            RuleFor(x => x.ProgrammingLanguageId).GreaterThan(0);
        }
    }
}
