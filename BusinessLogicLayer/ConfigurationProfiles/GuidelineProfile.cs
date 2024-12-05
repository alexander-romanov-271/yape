using System;
using AutoMapper;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;

namespace newyape.BusinessLogicLayer.ConfigurationProfiles;

public class GuidelineProfile : Profile
{
    public GuidelineProfile()
    {
        CreateMap<GuidelineEntity, GuidelineDTO>().ReverseMap();
    }
}