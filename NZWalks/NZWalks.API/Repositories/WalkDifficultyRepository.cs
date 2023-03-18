using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;

        public WalkDifficultyRepository(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }

        public async Task<WalkDifficulty> AddWalkDifficultyAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();

            await nZWalksDBContext.WalkDifficulty.AddAsync(walkDifficulty);
            await nZWalksDBContext.SaveChangesAsync();

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteWalkDifficultyAsync(Guid id)
        {
            var existingWalkDifficulty = await nZWalksDBContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
                return null;

            nZWalksDBContext.WalkDifficulty.Remove(existingWalkDifficulty);
            await nZWalksDBContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDBContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> GetWalkDifficultyAsync(Guid id)
        {
            var walkDifficulty = await nZWalksDBContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);

            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateWalkDifficultyAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await nZWalksDBContext.WalkDifficulty.FindAsync(id);

            if (existingWalkDifficulty == null)
                return null;

            existingWalkDifficulty.Code = walkDifficulty.Code;

            await nZWalksDBContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }
    }
}
