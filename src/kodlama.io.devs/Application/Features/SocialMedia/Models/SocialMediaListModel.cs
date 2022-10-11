using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.SocialMedia.Dtos;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.Models
{
    public class SocialMediaListModel: BasePageableModel
    {
        public IList<SocialMediaListDto> Items { get; set; }

    }
}
