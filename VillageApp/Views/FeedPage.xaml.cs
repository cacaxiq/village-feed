using VillageApp.ViewModels;

namespace VillageApp.Views;

public partial class FeedPage : ContentPageBase
{
	public FeedPage(FeedViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
	}
}