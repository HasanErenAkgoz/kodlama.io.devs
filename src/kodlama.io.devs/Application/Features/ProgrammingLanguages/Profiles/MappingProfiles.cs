using Application.Features.ProgrammingLanguages.Commands;
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.ProgrammingLanguages.Querys.GetByIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Querys.ProgrammingLanguageListCommand;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Profiles
{
    internal class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProgrammingLanguages, CreateProgrammingLanguagesDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguages, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguages, UpdateProgrammingLanguagesDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguages, UpdateProgrammingLanguagesCommand>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguages, DeleteProgrammingLanguagesDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguages, DeleteProgrammingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.ProgrammingLanguages>, ProgrammingLanguagesListModel>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguages, ProgrammingLanguagesListDto>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguages, GetByIdProgrammingLanguages>().ReverseMap();

          




        }
    }
}
