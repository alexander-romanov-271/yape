using System;

namespace newyape.BusinessLogicLayer.Services.UpdateServices;

public interface IUpdateService<T> where T : class
{
    public void Update(int id, T entity);
}
