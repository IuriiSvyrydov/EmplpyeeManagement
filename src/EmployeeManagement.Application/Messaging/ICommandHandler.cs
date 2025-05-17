using EmployeeManagement.Domain.Common.Results;

namespace EmployeeManagement.Application.Messaging;

    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task<ResultT<bool>> Handle(TCommand command, CancellationToken cancellationToken);
    }
    public interface ICommandHandler<in TCommand, TResponse>  where TCommand : ICommand<TResponse>
    {
        Task<ResultT<TResponse>> Handle(TCommand command, CancellationToken cancellationToken);
    }    

    

