using EmployeeManagement.Domain.Common.Results;
using MediatR;

namespace EmployeeManagement.Application.Messaging;

public interface ICommand : IBaseCommand;

public interface ICommand<TResponse> : IRequest<ResultT<TResponse>>, IBaseCommand;

public interface IBaseCommand;
