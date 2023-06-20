using Domain.Customers;
using MediatR;

namespace Application.Customers.GetAll
{
    public class GetAllCustomerQuery : IRequest<List<Customer>>
    {
    }
}
