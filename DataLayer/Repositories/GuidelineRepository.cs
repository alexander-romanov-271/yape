using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Contexts;
using newyape.DataLayer.Models;

namespace newyape.DataLayer.Repositories;

public class GuidelineRepository : IRepository<GuidelineEntity>
{
   
    private readonly ApplicationContext _db;

    public GuidelineRepository(ApplicationContext db)
    {
        ArgumentNullException.ThrowIfNull(db); 

        _db = db;
    }
    
    public void Create(GuidelineEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _db.Guidelines.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(GuidelineEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        _db.Guidelines.Remove(entity);
        _db.SaveChanges();
    }

    public GuidelineEntity? Get(int id)
    {
        ArgumentNullException.ThrowIfNull(id); 

        return _db.Guidelines
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);         
    }

    public List<GuidelineEntity>? GetAll()
    {
        return _db.Guidelines.ToList();
    }

    public List<GuidelineEntity> GetFromProcedure()
    {
        throw new NotImplementedException();
    }

    public void Update(int id, GuidelineEntity entity)
    {
        GuidelineEntity entityToUpdate  = _db.Guidelines.First<GuidelineEntity>(f => f.Id == id);
        entityToUpdate = entity;
        _db.SaveChanges();        
    }
}
