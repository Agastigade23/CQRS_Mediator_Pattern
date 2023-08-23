using CQRS_Pattern.Commands;
using CQRS_Pattern.Models;
using CQRS_Pattern.Repositories;
using MediatR;

namespace CQRS_Pattern.Handlers
{
    public class UpdateCustomerHandler : IRequestHandler<UpdateCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }

        public async Task<int> Handle(UpdateCustomerCommand command,CancellationToken cancellationToken)
        {
            var customerDetails = await _customerRepository.GetCustomerByIdAsync(command.Id);
            if (customerDetails == null)
            {
                return default;
            }

            customerDetails.CustomerName = command.CustomerName;
            customerDetails.CustomerAddress = command.CustomerAddress;
            customerDetails.CustomerEmail = command.CustomerEmail;

            return await _customerRepository.UpdateCustomerAsync(customerDetails);
        }
    }
}
