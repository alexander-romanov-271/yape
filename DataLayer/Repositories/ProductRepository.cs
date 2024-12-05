using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Contexts;
using newyape.DataLayer.Models;

namespace newyape.DataLayer.Repositories;

public class ProductRepository : IRepository<ProductEntity>
{
    
    private readonly ApplicationContext _db;

    public ProductRepository(ApplicationContext db)
    {
        ArgumentNullException.ThrowIfNull(db); 

        _db = db;
    }
    
    public void Create(ProductEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity); 

        _db.Products.Add(entity);
        _db.SaveChanges();
    }

    public void Delete(ProductEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity); 

        _db.Products.Remove(entity);
        _db.SaveChanges();
    }

    public ProductEntity? Get(int id)
    {
        ArgumentNullException.ThrowIfNull(id); 

        return _db.Products
            .AsNoTracking()
            .FirstOrDefault(p => p.Id == id);         
    }

    public List<ProductEntity>? GetAll()
    {
        return _db.Products.ToList();
    }

    public void Update(int id, ProductEntity entity)
    {
        ProductEntity entityToUpdate  = _db.Products.First<ProductEntity>(f => f.Id == id);
        entityToUpdate = entity;
        _db.SaveChanges();        
    }

    public List<ProductEntity> GetFromProcedure()
    {
        return _db.Products.FromSql<ProductEntity>($"CALL public.\"GetProductWithAssociatedGuidelinesAndRules\"()").ToList();
    }

}
