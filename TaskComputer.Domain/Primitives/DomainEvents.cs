using MediatR;
namespace TaskComputer.Domain.Primitives
{
    public record DomainEvents(Guid id):INotification;
}
