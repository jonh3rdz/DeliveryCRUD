using Domain.Customers;
using MediatR;

namespace Application.Customers.GetById
{
    public class GetByIdCustomerQuery : IRequest<Customer?>
    {
        public CustomerId Id { get; }

        public GetByIdCustomerQuery(CustomerId id)
        {
            Id = id;
        }
    }
}
