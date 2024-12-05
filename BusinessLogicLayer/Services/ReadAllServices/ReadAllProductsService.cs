using newyape.DataLayer.Repositories;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;
using AutoMapper;

namespace newyape.BusinessLogicLayer.Services.ReadAllServices;

public class ReadAllProductsService : IReadAllService<ProductDTO>
{
    private readonly IMapper _mapper;
    private readonly IRepository<ProductEntity> _repository;

    public ReadAllProductsService(IMapper mapper, [FromKeyedServices("productRepository")] IRepository<ProductEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public IEnumerable<ProductDTO> ReadAll()
    {        
        List<ProductEntity> entities = _repository.GetAll();
        
        return _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductDTO>>(entities); 
    } 

    public IEnumerable<ProductDTO> ReadAllFromProcedure()
    {
        List<ProductEntity> entities = _repository.GetFromProcedure();
        return _mapper.Map<IEnumerable<ProductEntity>, IEnumerable<ProductDTO>>(entities); 
    }
}
