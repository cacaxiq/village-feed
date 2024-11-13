using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VillageApp.Data;
using VillageApp.Models;
using VillageApp.Services;
using VillageApp.ViewModels.Base;

namespace VillageApp.ViewModels
{
    public partial class AddPostViewModel(INavigationService navigationService, AppDbContext dbContext) : ViewModelBase(navigationService)
    {
        [ObservableProperty] private Post post = new() { Id = string.Empty, Title = string.Empty, Content = string.Empty};

        [RelayCommand]
        public async Task Save()
        {
            using var transaction = dbContext.Database.BeginTransaction();
            await dbContext.Posts.AddAsync(new Data.Entities.Post { Id = Guid.CreateVersion7().ToString(), Content = post.Content, Title = post.Title });

            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            await navigationService.PopAsync();
        }
    }
}
