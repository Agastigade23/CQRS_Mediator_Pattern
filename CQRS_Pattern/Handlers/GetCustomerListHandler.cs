using CQRS_Pattern.Models;
using CQRS_Pattern.Queries;
using CQRS_Pattern.Repositories;
using MediatR;

namespace CQRS_Pattern.Handlers
{
    public class GetCustomerListHandler : IRequestHandler<GetCustomerListQuery, List<CustomerDetails>>
    {
        private readonly ICustomerRepository    _customerRepository;

        public GetCustomerListHandler(ICustomerRepository customerRepository) { _customerRepository = customerRepository; }

        public async Task<List<CustomerDetails>> Handle(GetCustomerListQuery query,CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerListAsync();
        }
    }
}
