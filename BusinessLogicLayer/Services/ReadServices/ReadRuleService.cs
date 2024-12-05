using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Repositories;
using newyape.DataLayer.Models;

namespace newyape.BusinessLogicLayer.Services.ReadServices;

public class RuleReadService : IReadService<RuleDTO>
{
    private readonly IMapper _mapper;

    private readonly IRepository<RuleEntity> _repository;

    public RuleReadService(IMapper mapper, [FromKeyedServices("ruleRepository")] IRepository<RuleEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }    

    public RuleDTO Read(int id)
    {
        var entity = _repository.Get(id);

        return _mapper.Map<RuleEntity, RuleDTO>(entity);
    }
}