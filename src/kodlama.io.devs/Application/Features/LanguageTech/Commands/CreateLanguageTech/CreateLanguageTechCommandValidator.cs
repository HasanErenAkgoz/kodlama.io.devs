using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Commands.CreateLanguageTech
{
    internal class CreateLanguageTechCommandValidator:AbstractValidator<CreateLanguageTechCommand>
    {
        public CreateLanguageTechCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(2);
            RuleFor(x => x.ProgrammingLanguageId).NotEmpty();
            RuleFor(x => x.ProgrammingLanguageId).GreaterThan(0);
        }
    }
}
