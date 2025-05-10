 using EmployeeManagement.Domain.Entities.LeaveTypes;
 using EmployeeManagement.Domain.Entities.LeaveTypes.ValueObjects;
 using EmployeeManagement.Persistence.Constants;
 using EmployeeManagement.Persistence.Converters;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.EntityFrameworkCore.Metadata.Builders;

 internal class LeaveTypeConfiguration: IEntityTypeConfiguration<LeaveType>
 {
     
     public void Configure(EntityTypeBuilder<LeaveType> builder)
     {
         builder.ToTable(Constants.Table.LeaveTypes);
         builder.HasKey(x => x.LeaveTypeId);
         builder.Property(x => x.LeaveTypeId).ValueGeneratedNever()
             .HasConversion<LeaveTypeIdConverter,LeaveTypeIdComparer>();
         builder.Property(x => x.Name).IsRequired()
             .HasConversion(x=>x.Value,value=>new Name(value));
         builder.Property(x=>x.Code).IsRequired()
             .HasConversion(x=>x.Value,value=>new Code(value));
         
     }
 } 