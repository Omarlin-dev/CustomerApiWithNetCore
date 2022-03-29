using Dto.Request;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public interface IDirectionService
    {
        Task<int> CreateDirectionAsync(DtoDirectionResquest resquest);
        Task<bool> DeleteDirectionAsycn(int id);
        Task<DtoDirectionResponse> GetDirectionAsync(int id);
        Task<ICollection<DtoDirectionResponse>> ListDirectionAsync();
        Task<int> UpdateDirectionAsync(int id, DtoDirectionResquest resquest);
    }
}