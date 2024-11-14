namespace VillageApp.Models
{
    public record Post
    {
        public required string Id { get; set; }
        public required string Title { get; set; }
        public required string Content { get; set; }
        public int LikesCount { get; set; }
        public IList<string> Medias { get; set; } = [];
        public string? ParentId { get; set; }
        public IList<Post> ChildrenPosts { get; set; } = [];
        public required string UserId{ get; set; }
        public required string UserUniqueName { get; set; }
        public required string UserName { get; set; }
        public required string Timeago { get; set; }
    }
}
