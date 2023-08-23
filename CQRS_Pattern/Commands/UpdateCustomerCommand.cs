using MediatR;

namespace CQRS_Pattern.Commands
{
    public class UpdateCustomerCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }

        public UpdateCustomerCommand(int id, string? customerName, string? customerEmail, string? customerAddress)
        {
            Id = id;
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerAddress = customerAddress;
        }   
    }
}
