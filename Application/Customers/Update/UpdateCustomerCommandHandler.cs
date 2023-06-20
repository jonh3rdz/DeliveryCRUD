using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using ErrorOr;
using MediatR;

namespace Application.Customers.Update
{
    internal sealed class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, ErrorOr<Unit>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<ErrorOr<Unit>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var customer = await _customerRepository.GetByIdAsync(new CustomerId(command.CustomerId));
                if (customer == null)
                {
                    return Error.NotFound("Customer not found.");
                }

                customer.Name = command.Name;
                customer.LastName = command.LastName;
                customer.Email = command.Email;
                customer.PhoneNumber = PhoneNumber.Create(command.PhoneNumber) ?? customer.PhoneNumber;
                customer.Address = Address.Create(command.Country, command.Line1, command.Line2, command.City, command.State, command.ZipCode) ?? customer.Address;

                await _customerRepository.Update(customer);
                await _unitOfWork.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
            catch (Exception ex)
            {
                return Error.Failure("UpdateCustomer.Failure", ex.Message);
            }
        }
    }
}
