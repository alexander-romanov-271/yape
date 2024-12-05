using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.CreateServices;

public class CreateRule : ICreateService<RuleDTO>
{
    
    private readonly IMapper _mapper;

    private readonly IRepository<RuleEntity> _repository;

    public CreateRule(IMapper mapper, [FromKeyedServices("ruleRepository")] IRepository<RuleEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public void Create(RuleDTO entityDto)
    {
        RuleEntity entity = _mapper.Map<RuleDTO, RuleEntity>(entityDto);

        _repository.Create(entity);
    }

}

