namespace NZWalks.API.Models.DTO
{
    public class UpdateWalkRequest
    {
        public string Name { get; set; }

        public double length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }
    }
}
