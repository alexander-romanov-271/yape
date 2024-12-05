using System;

namespace newyape.DataLayer.Models;

public class UserEntity
{
    public int Id { get; set; }
    
    public string LoginName { get; set; } = string.Empty;

    public string PaswrodHash { get; set; } = string.Empty;
}
