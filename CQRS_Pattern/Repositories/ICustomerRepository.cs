using CQRS_Pattern.Models;

namespace CQRS_Pattern.Repositories
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerDetails>> GetCustomerListAsync();
        public Task<CustomerDetails> GetCustomerByIdAsync(int Id);
        public Task<CustomerDetails> AddCustomerAsync(CustomerDetails customerDetails);
        public Task<int> UpdateCustomerAsync(CustomerDetails customerDetails);
        public Task<int> DeleteCustomerAsync(int Id);
    }
}
