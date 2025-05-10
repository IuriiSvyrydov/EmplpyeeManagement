using EmployeeManagement.Domain.Entities.Designations;
using EmployeeManagement.Domain.Entities.Designations.ValueObjects;
using EmployeeManagement.Persistence.Converters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EmployeeManagement.Persistence.Configurations;

internal class DesignationsConfiguration : IEntityTypeConfiguration<Designation>
{
    public void Configure(EntityTypeBuilder<Designation> builder)
    {
        builder.ToTable(Constants.Constants.Table.Designations);
        builder.HasKey(d => d.DesignationId);
        builder.Property(d => d.DesignationId).ValueGeneratedNever()
            .HasConversion<DesignationIdConverter,DesignationIdComparer>();
        builder.Property(d => d.Code).IsRequired()
            .HasConversion(x => x.Value, value => new Code(value));
        builder.Property(d => d.Name).IsRequired()
            .HasConversion(x => x.Value, value => new Name(value));
        

    }
}