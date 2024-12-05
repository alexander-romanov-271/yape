using System;
using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Contexts;
using newyape.DataLayer.Models;

namespace newyape.DataLayer.Repositories;

public class FieldRepository : IRepository<FieldEntity>
{    
    public ApplicationContext _db;

    public FieldRepository(ApplicationContext db)
    {
        ArgumentNullException.ThrowIfNull(db);

        _db = db;
    }
    
    public void Create(FieldEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity); 

        _db.Fields.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(FieldEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity); 

        _db.Fields.Remove(entity);
        _db.SaveChanges();
    }

    public FieldEntity? Get(int id)
    {
        ArgumentNullException.ThrowIfNull(id); 

        return _db.Fields
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);         
    }

    public List<FieldEntity>? GetAll()
    {
        return _db.Fields.ToList();
    }

    public List<FieldEntity> GetFromProcedure()
    {
        throw new NotImplementedException();
    }

    public void Update(int id, FieldEntity entity)
    {
        FieldEntity entityToUpdate  = _db.Fields.First<FieldEntity>(f => f.Id == id);
        entityToUpdate.Description = "Jopa a ne credit";
        _db.SaveChanges();        
    }
}
