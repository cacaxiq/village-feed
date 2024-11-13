using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using VillageApp.Data;
using VillageApp.Models;
using VillageApp.Services;
using VillageApp.ViewModels.Base;

namespace VillageApp.ViewModels
{
    public partial class FeedViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;
        private readonly AppDbContext dbContext;

        public FeedViewModel(INavigationService navigationService, AppDbContext dbContext) : base(navigationService)
        {
            this.navigationService = navigationService;
            this.dbContext = dbContext;
        }

        public ObservableCollectionEx<Post> Posts { get; } = [];

        public override async Task InitializeAsync()
        {
            var posts = dbContext.Posts.Select(post => new Models.Post{ Id = post.Id, Title = post.Title, Content = post.Content}).ToList();
            Posts.ReloadData(posts);
        }

        [RelayCommand]
        private void Search(string text)
        {
            var posts = dbContext.Posts
                .Where(post => post.Title.Contains(text) || post.Content.Contains(text))
                .Select(post => new Models.Post { Id = post.Id, Title = post.Title, Content = post.Content })
                .ToList();

            Posts.ReloadData(posts);
        }

        [RelayCommand]
        private Task AddPost()
        {
            return navigationService.NavigateToAsync("AddPost");
        }
    }
}
