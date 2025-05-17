using EmployeeManagement.Domain.Entities.Departments.ValueObject;
using EmployeeManagement.Domain.Entities.Designations;
using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.Domain.Entities.ValueObjects;
using EmployeeManagement.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable(Constants.Constants.Table.Employees);
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedNever()
            .HasConversion<EmployeeIdConverter,EmployeeIdComparer>();
        
        

        builder.Property(e => e.DateOfBirth)
            .HasConversion(
                dob => dob.Value,
                value => new DateOfBirth(value));

        builder.Property(x => x.FirstName).IsRequired()
            .HasConversion(x=>x.Value,value=>new FirstName(value));
        builder.Property(x => x.LastName).IsRequired()
            .HasConversion(x=>x.Value,value=>new LastName(value));
        builder.Property(x => x.MiddleName).IsRequired()
            .HasConversion(x=>x.Value,value=>new Domain.Entities.Employees.ValueObjects.MiddleName(value));
        builder.Property(x => x.DateOfBirth).IsRequired()
            .HasConversion(x=>x.Value,value=>new DateOfBirth(value));
        builder.Property(x => x.EmailAddress).IsRequired()
            .HasConversion(x=>x.Value,value=>new EmailAddress(value));
        builder.Property(x => x.PhoneNumber).IsRequired()
            .HasConversion(x=>x.Value,value=>new PhoneNumber(value));
        builder.Property(x => x.Country).IsRequired()
            .HasConversion(x=>x.Value,value=>new Country(value));
        builder.Property(x => x.Address).IsRequired()
            .HasConversion(x=>x.Value,value=>new Address(value));
        builder.Property(x => x.DepartmentId).IsRequired()
            .HasConversion(x=>x.Value,value=>new DepartmentId(value));
        builder.HasOne(x => x.Department)
            .WithMany(x => x.Employees)
            .HasForeignKey(x => x.DepartmentId);
        builder.Property(x => x.Designation).IsRequired(false);

    }
}