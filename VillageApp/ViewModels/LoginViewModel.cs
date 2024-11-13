using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VillageApp.Services;
using VillageApp.ViewModels.Base;

namespace VillageApp.ViewModels
{
    public partial class LoginViewModel(INavigationService navigationService) : ViewModelBase(navigationService)
    {
        [RelayCommand]
        public Task Login()
        {
            return navigationService.NavigateToAsync("//Main/Feed");
        }
    }
}
