using FluentValidation;
using Application.Features.LanguageTech.Commands.DeleteLanguageTech;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Commands.DeleteLanguageTech
{
    public class DeleteLanguageTechCommandValidator:AbstractValidator<DeleteLanguageTechCommand>
    {
        public DeleteLanguageTechCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
