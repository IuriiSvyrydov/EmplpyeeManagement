
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EmployeeManagement.Persistence.Frameworks.Contexts
{
    public class EmployeeDbContextFactory: IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-CR0ELGM;Database=EmployeeManagement;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=True; TrustServerCertificate=True;");
            return new AppDbContext(optionsBuilder.Options);
        }
        
    }
}