using Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.Repositorios
{
    public class DirectionRepository : IDirectionRepository
    {
        private readonly CustomerDbContext context;

        public DirectionRepository(CustomerDbContext context)
        {
            this.context = context;
        }

        public async Task<ICollection<Direction>> ListDirectionAsync()
        {
            return await context.Set<Direction>().ToListAsync();
        }

        public async Task<Direction> GetDirectionAsync(int id)
        {
            return await context.Set<Direction>().SingleOrDefaultAsync(d => d.Id == id);
        }

        public async Task<int> CreateDirectionAsync(Direction direction)
        {
            await context.Set<Direction>().AddAsync(direction);
            await context.SaveChangesAsync();

            return direction.Id;
        }

        public async Task<int> UpdateDirectionAsync(Direction direction)
        {
            context.Set<Direction>().Update(direction);
            await context.SaveChangesAsync();

            return direction.Id;
        }

        public async Task DeleteDirectionAsycn(int id)
        {
            var direction = await GetDirectionAsync(id);
            context.Entry(direction).State = EntityState.Deleted;
            await context.SaveChangesAsync();
        }
    }
}
