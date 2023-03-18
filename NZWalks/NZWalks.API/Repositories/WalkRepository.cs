using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;

        public WalkRepository(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }

        public async Task<Walk> AddAsync(Walk walk)
        {
            walk.Id = Guid.NewGuid();

            await nZWalksDBContext.Walks.AddAsync(walk);
            await nZWalksDBContext.SaveChangesAsync();

            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var walk = await nZWalksDBContext.Walks.FindAsync(id);

            if (walk == null)
            {
                return null;
            }

            nZWalksDBContext.Walks.Remove(walk);
            await nZWalksDBContext.SaveChangesAsync();

            return walk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await 
                nZWalksDBContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            return await nZWalksDBContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk newWalk)
        {
            var existingWalk = await nZWalksDBContext.Walks.FindAsync(id);

            if (existingWalk != null)
            {
                existingWalk.length = newWalk.length;
                existingWalk.Name = newWalk.Name;
                existingWalk.WalkDifficultyId = newWalk.WalkDifficultyId;
                existingWalk.RegionId = newWalk.RegionId;

                await nZWalksDBContext.SaveChangesAsync();
                return existingWalk;
            }

            return null;
        }
    }
}
