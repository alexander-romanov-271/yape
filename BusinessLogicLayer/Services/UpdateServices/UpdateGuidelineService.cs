using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.UpdateServices;

public class UpdateGuideline: IUpdateService<GuidelineDTO>
{

    private readonly IMapper _mapper;

    private readonly IRepository<GuidelineEntity> _repositrory;

    public UpdateGuideline(IMapper mapper, [FromKeyedServices("guidelineRepository")]IRepository<GuidelineEntity> repository)
    {
        _mapper = mapper;
        _repositrory = repository;
    }

    public void Update(int id, GuidelineDTO entotyDTO)
    {
        GuidelineEntity entity = _mapper.Map<GuidelineDTO, GuidelineEntity>(entotyDTO);
        _repositrory.Update(id, entity);
    }
}