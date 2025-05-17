using EmployeeManagement.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.Designations;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Entities.LeaveTypes;
using EmployeeManagement.Domain.Entities.SystemCodeDetails;
using EmployeeManagement.Domain.Entities.SystemCodes;

namespace EmployeeManagement.Persistence.Frameworks.Contexts;

public sealed class AppDbContext: IdentityDbContext<User>
{
    public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
    {
        
    }
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Designation> Designations { get; set; } = null!;
   // public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Bank> Banks { get; set; } = null!;
    public DbSet<SystemCode> SystemCodes { get; set; } = null!;
    public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; } = null!;
    public DbSet<LeaveType> LeaveTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Ignore<DepartmentId>();
        builder.Ignore<Code>();
        builder.Ignore<Name>();

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

    }


}