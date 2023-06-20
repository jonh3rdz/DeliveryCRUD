using ErrorOr;
using MediatR;

namespace Application.Customers.Update
{
    public record UpdateCustomerCommand(
        Guid CustomerId,
        string Name,
        string LastName,
        string Email,
        string PhoneNumber,
        string Country,
        string Line1,
        string Line2,
        string City,
        string State,
        string ZipCode) : IRequest<ErrorOr<Unit>>;
}