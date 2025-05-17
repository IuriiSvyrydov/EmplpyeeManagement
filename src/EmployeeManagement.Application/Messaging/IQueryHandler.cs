using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Messaging;

    public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    {
        Task<ResultT<TResponse>> Handle(TQuery request, CancellationToken cancellationToken);
    }
    
