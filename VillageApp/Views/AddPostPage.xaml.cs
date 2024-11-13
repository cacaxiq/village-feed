using VillageApp.ViewModels;

namespace VillageApp.Views;

public partial class AddPostPage : ContentPage
{
	public AddPostPage(AddPostViewModel viewModel)
    {
        BindingContext = viewModel;
        InitializeComponent();
	}
}