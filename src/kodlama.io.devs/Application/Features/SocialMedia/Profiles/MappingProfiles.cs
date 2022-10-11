using Application.Features.SocialMedia.Commands;
using Application.Features.SocialMedia.Dtos;
using Application.Features.SocialMedia.Models;
using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedia.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.SocialMedia, CreateSocialMediaDto>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, CreateSocialMediaCommand>().ReverseMap();

            CreateMap<Domain.Entities.SocialMedia, UpdateSocialMediaDto>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, UpdateSocialMediaCommand>().ReverseMap();

            CreateMap<Domain.Entities.SocialMedia, DeleteSocialMediaDto>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, DeleteSocialMediaCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.SocialMedia>, SocialMediaListModel>().ReverseMap();
            CreateMap<Domain.Entities.SocialMedia, SocialMediaListDto>().ReverseMap();

            CreateMap<Domain.Entities.SocialMedia, GetSocialMediaByIdDto>().ReverseMap();
        }
    }
}
