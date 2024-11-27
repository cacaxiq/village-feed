using System.ComponentModel.DataAnnotations.Schema;
using VillageApp.Extensions;

namespace VillageApp.Data.Entities
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string? ParentId { get; set; }
        public string Content { get; set; }
        public int LikesCount { get; set; }
        public IList<string> Medias { get; set; } = [];
        public string UserId { get; set; }
        public User User { get; set; } = null!;

        [NotMapped]
        public IList<Post> ChildrenPosts { get; set; } = [];

        public Models.Post ToModel()
        {
            return new Models.Post
            {
                Id = Id,
                Title = Title,
                Content = Content,
                ParentId = ParentId,
                UserId = UserId,
                UserName = User.Name,
                LikesCount = LikesCount,
                Medias = Medias,
                UserUniqueName = User.UniqueName,
                Timeago = CreatedAt.AsTimeAgo()
            };
        }

        public Post FromModel(Models.Post post)
        {
            Id = string.IsNullOrEmpty(post.Id) ?Id : post.Id;
            Title = post.Title;
            ParentId = post.ParentId;
            Content = post.Content;
            LikesCount = post.LikesCount;
            UserId = post.UserId;
            Medias = post.Medias;

            return this;
        }
    }
}
