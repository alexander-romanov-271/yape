using System;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using AutoMapper;

namespace newyape.BusinessLogicLayer.ConfigurationProfiles;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductEntity, ProductDTO>().ReverseMap();
    }
}
