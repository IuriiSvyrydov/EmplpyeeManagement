using EmployeeManagement.Domain.Entities.Orders;
using EmployeeManagement.Persistence.Constants;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable(Constants.Table.Orders);
        
      //  builder.HasKey(x => x.OrderId);
        
      //  builder.Property(x => x.OrderId)
      //      .HasConversion<OrderIdConverter,OrderIdComparer>()
      //      .ValueGeneratedNever();
        builder.OwnsOne(o => o.OrderId, id =>
{
    id.Property(x => x.Value)
      .HasColumnName("OrderId")
      .IsRequired();
});
    }
}