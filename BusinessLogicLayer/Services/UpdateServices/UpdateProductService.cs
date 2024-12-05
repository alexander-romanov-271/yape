using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.UpdateServices;

public class UpdateProduct: IUpdateService<ProductDTO>
{

    private readonly IMapper _mapper;

    private readonly IRepository<ProductEntity> _repositrory;

    public UpdateProduct(IMapper mapper, [FromKeyedServices("productRepository")]IRepository<ProductEntity> repository)
    {
        _mapper = mapper;
        _repositrory = repository;
    }

    public void Update(int id, ProductDTO entotyDTO)
    {
        ProductEntity entity = _mapper.Map<ProductDTO, ProductEntity>(entotyDTO);
        _repositrory.Update(id, entity);
    }
}
