﻿namespace DataLayer.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    
    public virtual ICollection<Account>? Accounts { get; set; }

}