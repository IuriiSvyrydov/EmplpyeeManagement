using EmployeeManagement.Application.Messaging;
using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Features.Employees.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<ResultT<EmployeeResponse>>
    {
      public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Designation { get; set; }

        //relation

        public Guid DepartmentId { get; set; }
    }
}