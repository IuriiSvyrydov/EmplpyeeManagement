using EmployeeManagement.Domain.Common.Results;
using MediatR;



    namespace EmployeeManagement.Application.Messaging;
    
    public interface IQuery<TResponse> : IRequest<ResultT<TResponse>>;
    

  
