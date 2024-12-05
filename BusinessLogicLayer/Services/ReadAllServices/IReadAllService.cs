namespace newyape.BusinessLogicLayer.Services.ReadAllServices;

public interface IReadAllService<T> where T : class
{
    public IEnumerable<T> ReadAll();
    public IEnumerable<T> ReadAllFromProcedure();
}
