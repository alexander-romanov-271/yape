using newyape.DataLayer.Repositories;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;
using AutoMapper;

namespace newyape.BusinessLogicLayer.Services.ReadAllServices;

public class ReadAllRulesService : IReadAllService<RuleDTO>
{
    private readonly IMapper _mapper;    private readonly IRepository<RuleEntity> _repository;

    public ReadAllRulesService(IMapper mapper, [FromKeyedServices("ruleRepository")] IRepository<RuleEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public IEnumerable<RuleDTO> ReadAll()
    {        
        List<RuleEntity> entities = _repository.GetAll();
        
        return _mapper.Map<IEnumerable<RuleEntity>, IEnumerable<RuleDTO>>(entities); 
    }

    public IEnumerable<RuleDTO> ReadAllFromProcedure()
    {
        throw new NotImplementedException();
    }
}
