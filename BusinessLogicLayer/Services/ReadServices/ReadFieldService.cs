using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.ReadServices;

public class ReadFieldService : IReadService<FieldDTO>
{
    private readonly IMapper _mapper;
    private readonly IRepository<FieldEntity> _repository;
    public ReadFieldService(IMapper mapper, [FromKeyedServices("fieldRepository")] IRepository<FieldEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }    
    public FieldDTO Read(int id)
    {
        var entity = _repository.Get(id);

        return _mapper.Map<FieldEntity, FieldDTO>(entity);
    }
}
