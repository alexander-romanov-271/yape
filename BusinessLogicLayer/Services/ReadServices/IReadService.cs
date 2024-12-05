using System;
using newyape.DataLayer.Contexts;

namespace newyape.BusinessLogicLayer.Services.ReadServices;

public interface IReadService<T> where T : class
{
    public T Read(int i);
}
