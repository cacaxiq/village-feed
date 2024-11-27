using VillageApp.ViewModels.Base;

namespace VillageApp.Views
{
    public abstract class ContentPageBase : ContentPage
    {
        public ContentPageBase()
        {
            NavigationPage.SetBackButtonTitle(this, string.Empty);

            SizeChanged += (s, e) =>
            {
                Application.Current.Resources["DefaultPostHeight"] = this.Width*0.71;
            };
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is not IViewModelBase ivmb)
            {
                return;
            }

            await ivmb.InitializeAsyncCommand.ExecuteAsync(null);
        }
    }
}
