using EmployeeManagement.Domain.Entities.ValueObjects;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

namespace EmployeeManagement.Domain.Entities.Users;

public sealed class User : IdentityUser
{
    public FirstName FirstName { get; set; }
    public LastName  LastName { get; set; }
}
