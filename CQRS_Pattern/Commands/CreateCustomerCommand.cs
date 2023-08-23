using CQRS_Pattern.Models;
using MediatR;

namespace CQRS_Pattern.Commands
{
    public class CreateCustomerCommand :IRequest<CustomerDetails>
    {
        public string? CustomerName { get; set; }
        public string? CustomerEmail { get; set; }
        public string? CustomerAddress { get; set; }

        public CreateCustomerCommand(string? customerName, string? customerEmail, string? customerAddress)
        {
            CustomerName = customerName;
            CustomerEmail = customerEmail;
            CustomerAddress = customerAddress;
        }
    }
}
