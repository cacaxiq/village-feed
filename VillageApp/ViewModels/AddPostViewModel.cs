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
        [ObservableProperty]
        private Post post = new()
        {
            Id = Guid.CreateVersion7().ToString(),
            Title = string.Empty,
            Content = string.Empty,
            UserId = "1",
            UserName = string.Empty,
            UserUniqueName = string.Empty,
            Timeago = string.Empty,
            Medias = { }
        };

        public ObservableCollectionEx<string> Medias { get; } = [];

        [RelayCommand]
        public async Task Save()
        {
            using var transaction = dbContext.Database.BeginTransaction();
            await dbContext.Posts.AddAsync(new Data.Entities.Post().FromModel(post));

            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();
            await navigationService.PopAsync();
        }

        [RelayCommand]
        public async Task GetMedia()
        {
            if (MediaPicker.Default.IsCaptureSupported)
            {
                FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);
                    await sourceStream.CopyToAsync(localFileStream);
                    post.Medias.Add(localFilePath);
                    Medias.ReloadData(post.Medias);
                }
            }
        }
    }
}
