using EmployeeManagement.Domain.Entities.SystemCodes;
using EmployeeManagement.UI.Models.Departments.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class SystemCodeConfiguration : IEntityTypeConfiguration<SystemCode>
{
    public void Configure(EntityTypeBuilder<SystemCode> builder)
    {
        builder.ToTable(Constants.Constants.Table.SystemCodes);

        builder.HasKey(x => x.SystemCodeId);
        
        builder.Property(x => x.SystemCodeId)
            .ValueGeneratedOnAdd()
            .HasConversion(x=>x.Value, value=>new Domain.Entities.SystemCodes.ValueObjects.SystemCodeId(value));

 
        builder.Property(x => x.Code)
            .IsRequired()
            .HasConversion(x => x.Value, value => new (value));
            
        builder.Property(x => x.Description)
            .IsRequired()
            .HasConversion(x => x.Value, value => new (value));
    }
}