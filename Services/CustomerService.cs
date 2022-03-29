using Dto.Request;
using Dto.Response;
using Entities;
using Repositorios.DataAccess;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository repository;

        public CustomerService(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<DtoCustomerResponse>> ListCustomer()
        {
            var collection = await repository.ListCollectionCustomer();

            return collection.Select(x => new DtoCustomerResponse
            {
                Id = x.Id,
                Name = x.Name,
                LastName = x.LastName,
                BirthDate = x.BirthDate,
                Email = x.Email
            }).ToList();
        }

        public async Task<DtoCustomerResponse> GetAsync(int id)
        {
            var customer = await repository.GetAsync(id);

            if (customer == null)
                return null;

            return new DtoCustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                LastName = customer.LastName,
                BirthDate = customer.BirthDate,
                Email = customer.Email
            };
        }

        public async Task<ICollection<DtoDirectionResponse>> ListDirectionsOfCustomer(int id)
        {
            var customer = await repository.ListDirectionsOfCustomer(id);

            return customer.Select(x => new DtoDirectionResponse
            {
                Location = x.Location,
                Country = x.Country,
                Default = x.Default,
                CustomerId = x.CustomerId 
            }).ToList();
        }

        public async Task<int> CreateAsync(DtoCustomerRequest customer)
        {
            return await repository.CreateAsync(new Customer
            {
                Name = customer.Name,
                LastName = customer.LastName,
                Email = customer.Email,
                BirthDate = customer.BirthDate
            });
        }

        public async Task<int> UpdateAsync(int id, DtoCustomerRequest customer)
        {
            if (await GetAsync(id) == null)
                return 0;

            return await repository.UpdateAsync(new Customer
            {
                Id = id,
                Name = customer.Name,
                LastName = customer.LastName,
                Email = customer.Email,
                BirthDate = customer.BirthDate
            });
        }

        public async Task<bool> DeleteAsync(int id)
        {
            if (await GetAsync(id) == null)
                return false;

            await repository.DeleteAsync(id);
            return true;
        }

    }
}
