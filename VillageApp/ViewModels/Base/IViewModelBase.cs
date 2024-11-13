using CommunityToolkit.Mvvm.Input;
using VillageApp.Services;

namespace VillageApp.ViewModels.Base
{
    public interface IViewModelBase : IQueryAttributable
    {
        public INavigationService NavigationService { get; }

        public IAsyncRelayCommand InitializeAsyncCommand { get; }

        public bool IsBusy { get; }

        Task InitializeAsync();
    }
}
