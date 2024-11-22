using VillageApp.Services;

namespace VillageApp;

public partial class App : Application
{
    private readonly INavigationService navigationService;

    public App(INavigationService navigationService)
    {
        InitializeComponent();
        this.navigationService = navigationService;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell(navigationService));
    }
}