using VillageApp.ViewModels;

namespace VillageApp.Views;

[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FeedPage : ContentPageBase
{
	public FeedPage(FeedViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
	}
}