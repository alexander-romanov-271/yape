using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.CreateServices;

public class CreateGuideline : ICreateService<GuidelineDTO>
{
    
    private readonly IMapper _mapper;

    private readonly IRepository<GuidelineEntity> _repository;

    public CreateGuideline(IMapper mapper, [FromKeyedServices("guidelineRepository")] IRepository<GuidelineEntity> repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public void Create(GuidelineDTO entityDto)
    {
        GuidelineEntity entity = _mapper.Map<GuidelineDTO, GuidelineEntity>(entityDto);

        _repository.Create(entity);
    }

}

