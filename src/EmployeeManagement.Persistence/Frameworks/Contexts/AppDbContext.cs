using EmployeeManagement.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Employees;

namespace EmployeeManagement.Persistence.Frameworks.Contexts;

public sealed class AppDbContext : IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


}