namespace VillageApp.Views.Templates;

public partial class PostImagesTemplate : ContentView
{
	public PostImagesTemplate()
	{
		InitializeComponent();
	}

    protected override void OnApplyTemplate()
    {
        Console.WriteLine(postview.WidthRequest);
        base.OnApplyTemplate();
    }
}