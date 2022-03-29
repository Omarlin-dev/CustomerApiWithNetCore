using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositorios
{
    public interface IDirectionRepository
    {
        Task<int> CreateDirectionAsync(Direction direction);
        Task DeleteDirectionAsycn(int id);
        Task<Direction> GetDirectionAsync(int id);
        Task<ICollection<Direction>> ListDirectionAsync();
        Task<int> UpdateDirectionAsync(Direction direction);
    }
}