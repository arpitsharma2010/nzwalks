namespace NZWalks.API.Models.DTO
{
    public class AddWalkRequest
    {
        public string Name { get; set; }

        public double length { get; set; }

        public Guid RegionId { get; set; }

        public Guid WalkDifficultyId { get; set; }
    }
}
