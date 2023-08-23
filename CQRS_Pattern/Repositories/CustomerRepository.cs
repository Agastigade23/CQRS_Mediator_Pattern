using CQRS_Pattern.Models;
using Microsoft.EntityFrameworkCore;
using CQRS_Pattern.Data;

namespace CQRS_Pattern.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DbContextClass _dbContext;

        public CustomerRepository(DbContextClass dbContext) { _dbContext = dbContext; }

        public async Task<CustomerDetails> AddCustomerAsync(CustomerDetails customerDetails)
        {
            var result = _dbContext.customers.Add(customerDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> DeleteCustomerAsync(int Id)
        {
            var filteredData = _dbContext.customers.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.customers.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<CustomerDetails> GetCustomerByIdAsync(int Id)
        {
            return await _dbContext.customers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<List<CustomerDetails>> GetCustomerListAsync()
        {
            return await _dbContext.customers.ToListAsync();
        }

        public async Task<int> UpdateCustomerAsync(CustomerDetails customerDetails)
        {
            _dbContext.customers.Update(customerDetails);
            return await _dbContext.SaveChangesAsync();
        }
    }
}
