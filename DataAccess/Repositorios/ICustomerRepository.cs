using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Repositorios.DataAccess
{
    public interface ICustomerRepository
    {
        Task<ICollection<Customer>> ListCollectionCustomer();
        Task<Customer> GetAsync(int id);
        Task<ICollection<Direction>> ListDirectionsOfCustomer(int id);
        Task<int> CreateAsync(Customer customer);
        Task<int> UpdateAsync(Customer customer);
        Task DeleteAsync(int id); 
    }
}