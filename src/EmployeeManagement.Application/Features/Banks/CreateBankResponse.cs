namespace EmployeeManagement.Application.Features.Banks
{
    public class CreateBankResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string AccountNo { get; set; }

        public CreateBankResponse() {} // Parameterless constructor

        public CreateBankResponse(Guid id, string code, string name, string accountNo)
        {
            Id = id;
            Code = code;
            Name = name;
            AccountNo = accountNo;
        }
    }
}