using Domain.Customers;
using MediatR;

namespace Application.Customers.GetById
{
    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, Customer?>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer?> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetByIdAsync(request.Id);
        }
    }
}
