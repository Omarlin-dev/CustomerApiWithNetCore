using DataAccess.Repositorios;
using Entities;
using Dto.Request;
using System.Linq;
using Dto.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class DirectionService : IDirectionService
    {
        private readonly IDirectionRepository repository;

        public DirectionService(IDirectionRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ICollection<DtoDirectionResponse>> ListDirectionAsync()
        {
            var direction = await repository.ListDirectionAsync();

            return direction.Select(x => new DtoDirectionResponse
            {
                Id = x.Id,
                Location = x.Location,
                CustomerId = x.CustomerId,
                Country = x.Country,
                Default = x.Default
            }).ToList();

        }

        public async Task<DtoDirectionResponse> GetDirectionAsync(int id)
        {
            var direction = await repository.GetDirectionAsync(id);

            return new DtoDirectionResponse
            {
                Id = direction.Id,
                CustomerId = direction.CustomerId,
                Location = direction.Location,
                Country = direction.Country,
                Default = direction.Default
            };
        }

        public async Task<int> CreateDirectionAsync(DtoDirectionResquest resquest)
        {
            var direction = new Direction
            {
                CustomerId = resquest.CustomerId,
                Location = resquest.Location,
                Country = resquest.Country,
                Default = resquest.Default
            };

            return await repository.CreateDirectionAsync(direction);
        }

        public async Task<int> UpdateDirectionAsync(int id, DtoDirectionResquest resquest)
        {
            if (await GetDirectionAsync(id) == null)
                return 0;

            var direction = new Direction
            {
                Id = id,
                CustomerId = resquest.CustomerId,
                Location = resquest.Location,
                Country = resquest.Country,
                Default = resquest.Default
            };

            return await repository.UpdateDirectionAsync(direction);
        }

        public async Task<bool> DeleteDirectionAsycn(int id)
        {
            if (await GetDirectionAsync(id) == null)
                return false;

            await repository.DeleteDirectionAsycn(id);
            return true;
        }
    }
}
