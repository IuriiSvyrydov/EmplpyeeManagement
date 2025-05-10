using EmployeeManagement.Domain.Entities.Designations;
using EmployeeManagement.Domain.Entities.Designations.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EmployeeManagement.Persistence.Converters;

namespace EmployeeManagement.Persistence.Configurations
{
    internal class DesignationConfiguration:IEntityTypeConfiguration<Designation>
    {
        public void Configure(EntityTypeBuilder<Designation> builder)
        {
          
            builder.ToTable(Constants.Constants.Table.Designations);
            builder.HasKey(d => d.DesignationId);
            builder.Property(d => d.DesignationId).ValueGeneratedNever()
                .HasConversion<DesignationIdConverter,DesignationIdComparer>();
            builder.Property(d => d.Code).IsRequired()
                .HasMaxLength(10)
                .HasConversion(x=>x.Value,value=>new Code(value));
            builder.Property(d => d.Name).IsRequired()
                .HasMaxLength(100)
                .HasConversion(x=>x.Value,value=>new Name(value));
        }
    }
}