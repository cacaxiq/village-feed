namespace VillageApp.Data.Entities
{
    public class User : Entity
    {
        public required string Name { get; set; }
        public required string UniqueName { get; set; }
        public ICollection<Post> Posts { get; set; } = new List<Post>();
    }
}
