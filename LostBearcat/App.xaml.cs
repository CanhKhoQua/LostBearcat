using Microsoft.Maui.Controls;

namespace LostBearcat
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Set the main page directly
            MainPage = new NavigationPage(new MainNavigationPage());
        }
    }
}