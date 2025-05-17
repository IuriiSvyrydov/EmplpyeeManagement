using EmployeeManagement.Domain.Common;
using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Persistence.Frameworks.Contexts;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.Persistence.Repositories.Banks;

public sealed class BankWriteRepository : WriteRepository<Bank>, IBankWriteRepository
{
    public BankWriteRepository(AppDbContext context,IUnitOfWork unitOfWork) : base(context,unitOfWork)
    {
    }
}
