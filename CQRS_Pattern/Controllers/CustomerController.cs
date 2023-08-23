using CQRS_Pattern.Commands;
using CQRS_Pattern.Models;
using CQRS_Pattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<List<CustomerDetails>> GetCustomerListAsync()
        {
            var customerDetails = await mediator.Send(new GetCustomerListQuery());

            return customerDetails;
        }

        [HttpGet("customerId")]
        public async Task<CustomerDetails> GetCustomerByIdAsync(int customerId)
        {
            var customerDetails = await mediator.Send(new GetCustomerByIdQuery() { Id = customerId });

            return customerDetails;
        }

        [HttpPost]
        public async Task<CustomerDetails> AddCustomerAsync(CustomerDetails customerDetails)
        {
            var customerDetail = await mediator.Send(new CreateCustomerCommand(
                customerDetails.CustomerName,
                customerDetails.CustomerAddress,
                customerDetails.CustomerEmail));
            return customerDetail;
        }

        [HttpPut]
        public async Task<int> UpdateCustomerAsync(CustomerDetails customerDetails)
        {
            var isCustomerDetailUpdated = await mediator.Send(new UpdateCustomerCommand(
               customerDetails.Id,
               customerDetails.CustomerName,
               customerDetails.CustomerAddress,
               customerDetails.CustomerEmail));
            return isCustomerDetailUpdated;
        }

        [HttpDelete]
        public async Task<int> DeleteCustomerAsync(int Id)
        {
            return await mediator.Send(new DeleteCustomerCommand() { Id = Id });
        }
    }
}
