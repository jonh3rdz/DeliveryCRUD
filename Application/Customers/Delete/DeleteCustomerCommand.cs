using ErrorOr;
using MediatR;

namespace Application.Customers.Delete
{
    public record DeleteCustomerCommand(Guid CustomerId) : IRequest<ErrorOr<Unit>>;
}
