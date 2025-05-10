using EmployeeManagement.Domain.Entities.Banks;
using EmployeeManagement.Persistence.Repositories.GenericRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Persistence.Repositories.Banks
{
    public class BankReadRepository : ReadRepository<Bank>, IBankReadRepository
    {
        public BankReadRepository(DbContext context) : base(context)
        {
        }
    }
}
