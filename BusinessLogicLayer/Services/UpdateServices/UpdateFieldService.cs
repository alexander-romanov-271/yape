using System;
using AutoMapper;
using newyape.BusinessLogicLayer.DataTransferObjects;
using newyape.DataLayer.Models;
using newyape.DataLayer.Repositories;

namespace newyape.BusinessLogicLayer.Services.UpdateServices;

public class UpdateField : IUpdateService<FieldDTO>
{

    private readonly IMapper _mapper;

    private readonly IRepository<FieldEntity> _repositrory;

    public UpdateField(IMapper mapper, [FromKeyedServices("fieldRepository")]IRepository<FieldEntity> repository)
    {
        _mapper = mapper;
        _repositrory = repository;
    }
    public void Update(int id, FieldDTO entotyDTO)
    {
        FieldEntity entity = _mapper.Map<FieldDTO, FieldEntity>(entotyDTO);
        _repositrory.Update(id, entity);
    }
}
