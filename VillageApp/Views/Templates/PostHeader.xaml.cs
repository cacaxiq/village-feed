using VillageApp.Models;

namespace VillageApp.Views.Templates;

public partial class PostHeader : Grid
{
    public static readonly BindableProperty PostProperty = BindableProperty.Create("Post", typeof(Post), typeof(Post), null, propertyChanged: OnPostChanged);

    private static void OnPostChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (bindable is PostHeader && newValue is not null)
            bindable.BindingContext = (Post)newValue;
    }

    public Post Post
    {
        get => (Post)GetValue(PostProperty);
        set => SetValue(PostProperty, value);
    }

    public PostHeader()
	{
		InitializeComponent();
	}
}