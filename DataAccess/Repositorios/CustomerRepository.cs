using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Repositorios.DataAccess
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerDbContext context;

        public CustomerRepository(CustomerDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Customer>> ListCollectionCustomer()
        {
            return await context.Set<Customer>().ToListAsync();
        }

        public async Task<Customer> GetAsync(int id)
        {
            return await context.Set<Customer>()
                .Where(d => d.Id == id)
                .SingleOrDefaultAsync();
                
        }
         
        public async Task<ICollection<Direction>> ListDirectionsOfCustomer(int id)
        {
            return await context.Set<Direction>()
                        .Where(d => d.CustomerId == id)
                        .ToListAsync();
        }

        public async Task<int> CreateAsync(Customer customer)
        {
            await context.Set<Customer>().AddAsync(customer);
            await context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task<int> UpdateAsync(Customer customer)
        {
            context.Set<Customer>().Attach(customer);
            context.Entry(customer).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return customer.Id;
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await context.Set<Customer>()
                            .SingleOrDefaultAsync(d => d.Id == id);

            if(customer != null)
            {
                context.Set<Customer>()
                    .Remove(customer);
                await context.SaveChangesAsync();
            }
        }
        
    }
}
