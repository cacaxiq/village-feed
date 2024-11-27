using Android.Graphics.Drawables;
using Microsoft.Maui.Handlers;

namespace VillageApp.Platforms
{
    public class CustomEntryMapper
    {
        public static void Map(IElementHandler handler, IElement view)
        {
            GradientDrawable drawable = new() { };
            drawable.SetShape(ShapeType.Rectangle);
            drawable.SetColor(Android.Graphics.Color.Transparent);
            drawable.SetStroke(0, Android.Graphics.Color.Transparent);

            drawable.SetCornerRadius(10);

            if (view is Editor)
            {
                ((EditorHandler)handler).PlatformView.Background = drawable;
                ((EditorHandler)handler).PlatformView.SetPadding(0,0,0,0);
            }

            if (view is Entry)
            {
                ((EntryHandler)handler).PlatformView.Background = drawable;
                ((EntryHandler)handler).PlatformView.SetPadding(0, 0, 0, 0);
            }
        }
    }
}
