using CQRS_Pattern.Models;
using MediatR;

namespace CQRS_Pattern.Queries
{
    public class GetCustomerListQuery : IRequest<List<CustomerDetails>>
    {
    }
}
