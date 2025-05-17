using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Domain.Entities.Banks.ValueObject;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Banks
{
    public class BankReadRepository : ReadRepository<Bank,BankId>, IBankReadRepository
    {
        public BankReadRepository(AppDbContext context) : base(context)
        {
        }

       
    }
}
