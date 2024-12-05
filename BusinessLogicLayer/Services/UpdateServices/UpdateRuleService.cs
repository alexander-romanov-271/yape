using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.UpdateServices;

public class UpdateRule : IUpdateService<RuleDTO>
{

    private readonly IMapper _mapper;

    private readonly IRepository<RuleEntity> _repositrory;

    public UpdateRule(IMapper mapper, [FromKeyedServices("ruleRepository")]IRepository<RuleEntity> repository)
    {
        _mapper = mapper;
        _repositrory = repository;
    }

    public void Update(int id, RuleDTO entotyDTO)
    {
        RuleEntity entity = _mapper.Map<RuleDTO, RuleEntity>(entotyDTO);
        _repositrory.Update(id, entity);
    }
}