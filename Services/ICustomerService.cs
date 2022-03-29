using Dto.Response;
using Dto.Request;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface ICustomerService 
    {
        Task<ICollection<DtoCustomerResponse>> ListCustomer();
        Task<DtoCustomerResponse> GetAsync(int id);
        Task<ICollection<DtoDirectionResponse>> ListDirectionsOfCustomer(int id);
        Task<int> CreateAsync(DtoCustomerRequest customer);
        Task<int> UpdateAsync(int id, DtoCustomerRequest customer);
        Task<bool> DeleteAsync(int id);
    }
}