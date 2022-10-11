using Application.Features.ProgrammingLanguages.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Models
{
    public class ProgrammingLanguagesListModel: BasePageableModel
    {
        public IList<ProgrammingLanguagesListDto> Items { get; set; }

    }
}
