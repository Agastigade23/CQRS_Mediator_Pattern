using CQRS_Pattern.Commands;
using CQRS_Pattern.Models;
using CQRS_Pattern.Repositories;
using MediatR;

namespace CQRS_Pattern.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerCommand, CustomerDetails>
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }

        public async Task<CustomerDetails> Handle(CreateCustomerCommand command,CancellationToken cancellationToken)
        {
            var customerDetails = new CustomerDetails()
            {
                CustomerName = command.CustomerName,
                CustomerAddress = command.CustomerAddress,
                CustomerEmail = command.CustomerEmail
            };
            return await _customerRepository.AddCustomerAsync(customerDetails);
        }
    }
}
