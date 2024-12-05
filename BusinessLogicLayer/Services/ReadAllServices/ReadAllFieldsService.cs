using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;
using AutoMapper;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.ReadAllServices;

public class ReadAllFieldsService : IReadAllService<FieldDTO>
{
    private readonly IMapper _mapper;
    private readonly ILogger _logger;
    private readonly IRepository<FieldEntity> _repository;

    public ReadAllFieldsService(
        IMapper mapper,
        ILogger<ReadAllFieldsService> logger,
        [FromKeyedServices("fieldRepository")] IRepository<FieldEntity> repository
    )
    {
        _mapper = mapper;
        _logger = logger;
        _repository = repository;
    }
    
    public IEnumerable<FieldDTO> ReadAll()
    {        
        List<FieldEntity>? entities = _repository.GetAll();
        
        return _mapper.Map<IEnumerable<FieldEntity>, IEnumerable<FieldDTO>>(entities); 
    }

    public IEnumerable<FieldDTO> ReadAllFromProcedure()
    {
        throw new NotImplementedException();
    }
}
