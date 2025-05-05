using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(Constants.Constants.Table.Departments);
        builder.HasKey(x => x.DepartmentId);
        builder.Property(x => x.DepartmentId).ValueGeneratedNever()
            .HasConversion(x=>x.Value,value=> DepartmentId.NewId());
        builder.Property(x => x.Name).IsRequired()
        .HasMaxLength(100)
        .HasConversion(x=>x.Value,value=>new Name(value));
        builder.HasMany(x => x.Employees)
        .WithOne(x => x.Department)
        .HasForeignKey(x => x.DepartmentId);
        
    }
}