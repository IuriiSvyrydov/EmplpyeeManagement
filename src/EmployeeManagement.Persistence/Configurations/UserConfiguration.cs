
using EmployeeManagement.Domain.Entities.Employees.ValueObjects;
using EmployeeManagement.Domain.Entities.Users;
using EmployeeManagement.Domain.Entities.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName).IsRequired()
            .HasConversion(x => x.Value, value => new FirstName(value));
        builder.Property(x => x.LastName)
            .IsRequired()
            .HasConversion(x=>x.Value,value=>new LastName(value));
    }
}
