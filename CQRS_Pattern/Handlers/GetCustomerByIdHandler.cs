using MediatR;
using CQRS_Pattern.Repositories;
using CQRS_Pattern.Models;
using CQRS_Pattern.Queries;

namespace CQRS_Pattern.Handlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDetails>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }

        public async Task<CustomerDetails> Handle(GetCustomerByIdQuery query, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(query.Id);
        }
    }
}
