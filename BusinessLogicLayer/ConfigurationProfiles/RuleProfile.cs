using System;
using AutoMapper;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;

namespace newyape.BusinessLogicLayer.ConfigurationProfiles;

public class RuleProfile : Profile
{
    public RuleProfile()
    {       
        CreateMap<RuleEntity, RuleDTO>().ReverseMap();
    }
}
