using Microsoft.EntityFrameworkCore;
using newyape.DataLayer.Contexts;
using newyape.DataLayer.Models;

namespace newyape.DataLayer.Repositories;

public class UserRepository
{
    private readonly ApplicationContext _db;

    public UserRepository(ApplicationContext db)
    {
        _db = db;
    }



    async public Task<UserEntity?> Get(string name)
    {
        return await _db.Users.FirstOrDefaultAsync(u => u.LoginName == name);
    }
}
