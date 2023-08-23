using CQRS_Pattern.Commands;
using CQRS_Pattern.Repositories;
using MediatR;

namespace CQRS_Pattern.Handlers
{
    public class DeleteCustomerHandler:IRequestHandler<DeleteCustomerCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;

        public DeleteCustomerHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }

        public async Task<int> Handle(DeleteCustomerCommand command,CancellationToken cancellationToken)
        {
            var customerDetails = await _customerRepository.GetCustomerByIdAsync(command.Id);
            if (customerDetails == null)
            {
                return default;
            }

            return await _customerRepository.DeleteCustomerAsync(customerDetails.Id);
        }
    }
}
