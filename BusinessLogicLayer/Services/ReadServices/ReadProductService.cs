using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Repositories;
using newyape.DataLayer.Models;


namespace newyape.BusinessLogicLayer.Services.ReadServices;

public class ProductReadService : IReadService<ProductDTO>
{
    private readonly IMapper _mapper;
    private readonly IRepository<ProductEntity> _repository;

    public ProductReadService(IMapper mapper, [FromKeyedServices("productRepository")] IRepository<ProductEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }    

    public ProductDTO Read(int id)
    {
        var entity = _repository.Get(id);

        return _mapper.Map<ProductEntity, ProductDTO>(entity);
    }
}

