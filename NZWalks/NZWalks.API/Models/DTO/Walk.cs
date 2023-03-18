namespace NZWalks.API.Models.DTO
{
    public class Walk
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public double length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }

        public Region Region { get; set; }

        public WalkDifficultyDTO WalkDifficulty { get; set; }
    }
}
