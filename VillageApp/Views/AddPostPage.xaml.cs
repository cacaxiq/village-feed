using VillageApp.ViewModels;

namespace VillageApp.Views;

public partial class AddPostPage : ContentPageBase
{
	public AddPostPage(AddPostViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
	}
}