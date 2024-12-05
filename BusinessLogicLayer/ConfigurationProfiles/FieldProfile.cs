using System;
using AutoMapper;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;

namespace newyape.BusinessLogicLayer.ConfigurationProfiles;

public class FieldProfile : Profile
{
    public FieldProfile()
    {
        CreateMap<FieldEntity, FieldDTO>().ReverseMap();
    }
}
