using Microsoft.Maui.Handlers;
using Microsoft.Maui.Platform;

namespace VillageApp.Platforms.iOS
{
    public class CustomEntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            var color = (Color)Application.Current.Resources["PrimaryColor"];
            if (view is Editor)
            {
                ((EditorHandler)handler).PlatformView.Layer.BorderColor = color.ToCGColor();
            }

            if (view is Entry)
            {
                ((EntryHandler)handler).PlatformView.Layer.BorderColor = color.ToCGColor();
            }
        }
    }
}

