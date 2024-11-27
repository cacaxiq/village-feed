using Microsoft.Maui.Controls.Shapes;

namespace VillageApp.Controls;

public class CustomEntry : Border
{
    public static readonly BindableProperty PlaceholderProperty =
  BindableProperty.Create("Placeholder", typeof(string), typeof(CustomEntry), string.Empty, propertyChanged: OnPlaceholderPropertyChanged);

    public static readonly BindableProperty LabelProperty =
  BindableProperty.Create("Label", typeof(string), typeof(CustomEntry), string.Empty, propertyChanged: OnLabelPropertyChanged);

    public string Placeholder
    {
        get => (string)GetValue(PlaceholderProperty);
        set => SetValue(PlaceholderProperty, value);
    }

    public string Label
    {
        get => (string)GetValue(LabelProperty);
        set => SetValue(LabelProperty, value);
    }

    private static void OnPlaceholderPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var entry = ((CustomEntry)bindable).entry;
        entry.Placeholder = (string)newValue;
    }

    private static void OnLabelPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var label = ((CustomEntry)bindable).label;
        label.Text = (string)newValue;
    }

    private readonly Label label = new()
    {
        FontSize = 12,
        TextColor = (Color)Application.Current.Resources["Tertiary"],
        IsVisible = false,
        Opacity = 0,
        HeightRequest = 18
    };
    private readonly Entry entry = new()
    {
        FontSize = 14,
        TextColor = (Color)Application.Current.Resources["Gray950"],
        PlaceholderColor = (Color)Application.Current.Resources["Gray200"],
        HeightRequest = 21
    };

    public CustomEntry()
    {
        entry.TextChanged += Entry_TextChanged;
        entry.Focused += Entry_Focused;
        entry.Unfocused += Entry_Unfocused;

        var visualStateGroup = new VisualStateGroup();
        var normalState = new VisualState { Name = "Normal" };
        normalState.Setters.Add(new Setter
        {
            Property = Border.StrokeProperty,
            Value = (Color)Application.Current.Resources["Gray200"]
        });

        var focusedState = new VisualState { Name = "Focused" };
        focusedState.Setters.Add(new Setter
        {
            Property = Border.StrokeProperty,
            Value = (Color)Application.Current.Resources["Tertiary"]
        });

        visualStateGroup.States.Add(normalState);
        visualStateGroup.States.Add(focusedState);
        VisualStateManager.SetVisualStateGroups(this, [visualStateGroup]);

        BackgroundColor = Colors.Transparent;
        HeightRequest = 69;
        Padding = new Thickness(17, 14, 17, 11);
        StrokeThickness = 1;
        StrokeShape = new RoundRectangle { CornerRadius = new CornerRadius(10) };
        Content = new VerticalStackLayout
        {
            VerticalOptions = LayoutOptions.Center,
            Children = {
                label,
                entry
            }
        };
    }

    private async void Entry_TextChanged(object? sender, TextChangedEventArgs e)
    {
        var entry = ((Entry)sender);
        var customEntry = ((CustomEntry)entry.Parent.Parent);

        await SetFocused(customEntry);

        customEntry.label.IsVisible = entry.IsFocused;
    }

    private async void Entry_Focused(object? sender, FocusEventArgs e)
    {
        if (sender is Entry entry && entry.Parent.Parent is CustomEntry border)
            await SetFocused(border);
    }

    private async void Entry_Unfocused(object? sender, FocusEventArgs e)
    {
        if (sender is Entry entry && entry.Parent.Parent is CustomEntry border)
            if (!string.IsNullOrEmpty(entry.Text))
                await SetFocused(border);
            else
                await SetNormal(border);
    }

    private static async Task SetNormal(CustomEntry border)
    {
        await border.label.FadeTo(0);
        border.label.IsVisible = false;
        VisualStateManager.GoToState(border, "Normal");
    }

    private static async Task SetFocused(CustomEntry border)
    {
        VisualStateManager.GoToState(border, "Focused");
        border.label.IsVisible = true;
        await border.label.FadeTo(1);
    }
}