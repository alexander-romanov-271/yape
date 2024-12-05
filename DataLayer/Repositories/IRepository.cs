namespace newyape.DataLayer.Repositories;

public interface IRepository<T> where T : class
{
    public List<T>? GetAll();
    public T? Get(int id);
    public void Update(int id, T entity);
    public void Create(T entity);
    public void Delete(T entity);

    public List<T> GetFromProcedure();

}
