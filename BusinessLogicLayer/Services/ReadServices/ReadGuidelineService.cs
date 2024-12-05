using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Repositories;
using newyape.DataLayer.Models;

namespace newyape.BusinessLogicLayer.Services.ReadServices;

public class GuidelineReadService : IReadService<GuidelineDTO>
{
    
    private readonly IMapper _mapper;

    private readonly IRepository<GuidelineEntity> _repository;

    public GuidelineReadService(IMapper mapper, [FromKeyedServices("guidelineRepository")] IRepository<GuidelineEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }    

    public GuidelineDTO Read(int id)
    {
        var entity = _repository.Get(id);

        return _mapper.Map<GuidelineEntity, GuidelineDTO>(entity);
    }

}
