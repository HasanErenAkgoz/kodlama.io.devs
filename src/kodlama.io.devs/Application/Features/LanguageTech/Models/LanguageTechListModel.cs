using Application.Features.LanguageTech.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Models
{
    public class LanguageTechListModel: BasePageableModel
    {
        public IList<LanguageTechListDto> Items { get; set; }

    }
}
