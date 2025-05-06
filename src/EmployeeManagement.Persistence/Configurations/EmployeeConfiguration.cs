using EmployeeManagement.Domain.Entities.Employees;
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasConversion(
                id => id.Value,
                value => EmployeeId.Create(value).Value);

        builder.Property(e => e.DateOfBirth)
            .HasConversion(
                dob => dob.Value,
                value => new DateOfBirth(value));

        builder.Property(x => x.FirstName).IsRequired()
            .HasConversion(x=>x.Value,value=>new FirstName(value));
        builder.Property(x => x.LastName).IsRequired()
            .HasConversion(x=>x.Value,value=>new LastName(value));
        builder.Property(x => x.MiddleName).IsRequired()
            .HasConversion(x=>x.value,value=>new MiddleName(value));
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
    }
}