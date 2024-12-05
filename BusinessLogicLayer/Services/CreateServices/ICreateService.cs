namespace newyape.BusinessLogicLayer.Services.CreateServices;

public interface ICreateService<T> where T : class
{
    public void Create(T t);
}
