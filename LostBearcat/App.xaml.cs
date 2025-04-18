using Microsoft.Maui.Controls;

namespace LostBearcat
{
    public partial class App : Application
    {
        private readonly LocalDBService _dbService;

        public App(LocalDBService dbService)
        {
            _dbService = dbService;

            InitializeComponent();

            // Set the main page using the provided dbService
            MainPage = new NavigationPage(new MainNavigationPage(_dbService));
        }
    }
}