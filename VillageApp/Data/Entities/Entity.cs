namespace VillageApp.Data.Entities
{
    public abstract class Entity
    {
        public string Id { get; set; } = Guid.CreateVersion7().ToString();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
    }
}