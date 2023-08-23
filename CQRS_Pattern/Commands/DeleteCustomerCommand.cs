using MediatR;

namespace CQRS_Pattern.Commands
{
    public class DeleteCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
