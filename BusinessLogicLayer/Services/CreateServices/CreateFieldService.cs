using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.CreateServices;

public class CreateField : ICreateService<FieldDTO>
{

    private readonly IMapper _mapper;

    private readonly IRepository<FieldEntity> _repostitory;

    public CreateField(IMapper mapper, [FromKeyedServices("fieldRepository")] IRepository<FieldEntity> repostitory)
    {
        _mapper = mapper;
        _repostitory = repostitory;
    }

    public void Create(FieldDTO entityDto)
    {
        FieldEntity entity = _mapper.Map<FieldDTO, FieldEntity>(entityDto);

        _repostitory.Create(entity);
    }
}
