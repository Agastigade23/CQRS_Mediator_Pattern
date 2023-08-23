using CQRS_Pattern.Models;
using MediatR;

namespace CQRS_Pattern.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDetails>
    {
        public int Id { get; set; }
    }
}
