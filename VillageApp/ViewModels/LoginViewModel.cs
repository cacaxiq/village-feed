using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VillageApp.Data;
using VillageApp.Services;
using VillageApp.ViewModels.Base;

namespace VillageApp.ViewModels
{
    public partial class LoginViewModel(INavigationService navigationService, AppDbContext dbContext) : ViewModelBase(navigationService)
    {
        [RelayCommand]
        public async Task Login()
        {
            using var transaction = dbContext.Database.BeginTransaction();

            if (!dbContext.Users.Any())
            {
                await dbContext.Users.AddAsync(new Data.Entities.User
                {
                    Id = "1",
                    Name = "Carlos",
                    UniqueName = "@carlos"
                });
            }

            await dbContext.SaveChangesAsync();
            await transaction.CommitAsync();

            await navigationService.NavigateToAsync("//Main/Feed");
        }
    }
}
