using Application.Features.LanguageTech.Commands.CreateLanguageTech;
using Application.Features.LanguageTech.Commands.DeleteLanguageTech;
using Application.Features.LanguageTech.Commands.UpdateLanguageTech;
using Application.Features.LanguageTech.Dtos;
using Application.Features.LanguageTech.Models;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTech.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.LanguageTech, CreateLanguageTechCommand>().ReverseMap();
            CreateMap<Domain.Entities.LanguageTech, CreateLanguageTechDto>().ReverseMap();

            CreateMap<Domain.Entities.LanguageTech, UpdateLanguageTechCommand>().ReverseMap();
            CreateMap<Domain.Entities.LanguageTech, UpdateLanguageTechDto>()
                .ForMember(x => x.Name, opt => opt.MapFrom(y => y.Name))
                .ReverseMap();

            CreateMap<Domain.Entities.LanguageTech, DeleteLanguageTechCommand>().ReverseMap();
            CreateMap<Domain.Entities.LanguageTech, DeleteLanguageTechDto>().ReverseMap();

            CreateMap<Domain.Entities.LanguageTech, GetLanguageTechByIdDto>().ReverseMap();

            CreateMap<Domain.Entities.LanguageTech, LanguageTechListDto>()
                .ForMember(x => x.LanguageName, opt => opt.MapFrom(y => y.ProgrammingLanguage.Name))
                .ReverseMap();
            CreateMap<IPaginate<Domain.Entities.LanguageTech>, LanguageTechListModel>().ReverseMap();
        }
    }
}
