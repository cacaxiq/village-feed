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
            var colorAccent = Android.App.Application.Context.Resources.GetColor(Resource.Color.colorAccent, null);
            drawable.SetStroke(4, colorAccent);

            drawable.SetCornerRadius(10);

            if (view is Editor)
            {
                ((EditorHandler)handler).PlatformView.Background = drawable;
                ((EditorHandler)handler).PlatformView.SetPadding(24, 24, 24, 24);
            }

            if (view is Entry)
            {
                ((EntryHandler)handler).PlatformView.Background = drawable;
                ((EntryHandler)handler).PlatformView.SetPadding(24, 0, 24, 0);
            }
        }
    }
}
