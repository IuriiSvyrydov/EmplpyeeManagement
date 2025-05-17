using EmployeeManagement.Domain.Entities.Departments;
using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
{
    public void Configure(EntityTypeBuilder<Department> builder)
    {
        builder.ToTable(Constants.Constants.Table.Departments);
    
        builder.Property(d => d.DepartmentId)
            .HasConversion(
                id => id.Value,
                value => new DepartmentId(value))
            .ValueGeneratedNever()
            .IsRequired();
        
        builder.HasKey(d => d.DepartmentId);
    
        builder.Property(d => d.Code)
            .IsRequired()
            .HasConversion(
                x => x.Value,
                value => new Code(value));
            
        builder.Property(d => d.Name)
            .IsRequired()
            .HasConversion(
                x => x.Value,
                value => new Name(value));
}
}