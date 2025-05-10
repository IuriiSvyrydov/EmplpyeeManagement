using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using EmployeeManagement.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class BankConfiguration : IEntityTypeConfiguration<Bank>
{
    public void Configure(EntityTypeBuilder<Bank> builder)
    {
        builder.ToTable(Constants.Constants.Table.Banks);
        builder.HasKey(x => x.BankId);
        builder.Property(x => x.BankId).ValueGeneratedNever()
            .HasConversion<BankIdConverter,BankIdComparer>();
        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, value => new Name(value));
        builder.Property(x => x.Code)
            .HasConversion(x => x.Value, value => new Code(value));
        builder.Property(x=>x.AccountNo)
            .HasConversion(x=>x.Value,value=>new AccountNo(value));
    }
}