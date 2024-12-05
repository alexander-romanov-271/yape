using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.CreateServices;

public class CreateProduct : ICreateService<ProductDTO>
{
    
    private readonly IMapper _mapper;

    private readonly IRepository<ProductEntity> _repository;

    public CreateProduct(IMapper mapper, [FromKeyedServices("productRepository")] IRepository<ProductEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public void Create(ProductDTO entityDto)
    {
        ProductEntity entity = _mapper.Map<ProductDTO, ProductEntity>(entityDto);

        _repository.Create(entity);
    }

}


