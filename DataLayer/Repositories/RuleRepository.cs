using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Contexts;
using newyape.DataLayer.Models;

namespace newyape.DataLayer.Repositories;

public class RuleRepository : IRepository<RuleEntity>
{
   
    private readonly ApplicationContext _db;

    public RuleRepository(ApplicationContext db)
    {
        ArgumentNullException.ThrowIfNull(db); 

        _db = db;
    }
    
    public void Create(RuleEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity); 

        _db.Rules.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(RuleEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity); 

        _db.Rules.Remove(entity);
        _db.SaveChanges();
    }

    public RuleEntity? Get(int id)
    {
        ArgumentNullException.ThrowIfNull(id); 

        return _db.Rules
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);         
    }

    public List<RuleEntity>? GetAll()
    {
        return _db.Rules.ToList();
    }

    public List<RuleEntity> GetFromProcedure()
    {
        throw new NotImplementedException();
    }

    public void Update(int id, RuleEntity entity)
    {
        RuleEntity entityToUpdate  = _db.Rules.First<RuleEntity>(f => f.Id == id);
        entityToUpdate = entity;
        _db.SaveChanges();        
    }    
}
