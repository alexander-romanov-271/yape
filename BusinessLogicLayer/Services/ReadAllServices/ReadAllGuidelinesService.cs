using newyape.DataLayer.Repositories;
using newyape.DataLayer.Models;
using newyape.BusinessLogicLayer.DataTransferObjects;
using AutoMapper;

namespace newyape.BusinessLogicLayer.Services.ReadAllServices;

public class ReadAllGuidelinesService : IReadAllService<GuidelineDTO>
{
    private readonly IMapper _mapper;
    private readonly IRepository<GuidelineEntity> _repository;

    public ReadAllGuidelinesService(IMapper mapper, [FromKeyedServices("guidelineRepository")] IRepository<GuidelineEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public IEnumerable<GuidelineDTO> ReadAll()
    {        
        List<GuidelineEntity> entities = _repository.GetAll();
        
        return _mapper.Map<IEnumerable<GuidelineEntity>, IEnumerable<GuidelineDTO>>(entities); 
    }

    public IEnumerable<GuidelineDTO> ReadAllFromProcedure()
    {
        throw new NotImplementedException();
    }
}
