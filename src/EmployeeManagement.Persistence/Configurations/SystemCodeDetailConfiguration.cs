using EmployeeManagement.Domain.Entities.SystemCodeDetails;
using EmployeeManagement.Domain.Entities.SystemCodes.ValueObjects;
using EmployeeManagement.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Code = EmployeeManagement.Domain.Entities.Departments.ValueObject.Code;

namespace EmployeeManagement.Persistence.Configurations;

internal class SystemCodeDetailConfiguration : IEntityTypeConfiguration<SystemCodeDetail>
{
    public void Configure(EntityTypeBuilder<SystemCodeDetail> builder)
    {
        builder.ToTable(Constants.Constants.Table.SystemCodeDetail);
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion<SystemCodeDetailIdConverter,SystemCodeDetailIdComparer>();
        builder.Property(x => x.Code)
            .IsRequired().HasConversion(x => x.Value, value => new Code(value));
        builder.Property(x=>x.Description).IsRequired()
            .HasMaxLength(500).HasConversion(x=>x.Value,value=>new Description(value));
    }
}