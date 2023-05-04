using Msg.Mobile.Views;

namespace Msg.Mobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var id = Preferences.Default.Get("UserId", "none");

            if (id == "none")
            {
                App.Current.MainPage = App.Current.Handler.MauiContext.Services.GetService<Login>();
            }
        }
    }
}