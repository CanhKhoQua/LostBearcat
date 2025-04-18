using LostBearcat.Views;
using Microsoft.Maui.Controls;
using System;

namespace LostBearcat
{
    public partial class MainNavigationPage : ContentPage
    {

        public bool validLogIn;



        public MainNavigationPage()
=======
        private readonly LocalDBService _dbService;

        public MainNavigationPage(LocalDBService dbService)
        {
            _dbService = dbService ?? throw new ArgumentNullException(nameof(dbService));
            InitializeComponent(); // Make sure this matches your XAML
        }

        private async void OnAddNewItemClicked(object sender, EventArgs e)
        {

            if (validLogIn)
            {
                await Navigation.PushAsync(new AddItemPage());
            }
            await Navigation.PushAsync(new AddItemPage(_dbService));

        }

        private async void OnViewLostItemsClicked(object sender, EventArgs e)
        {
            if (validLogIn)
            {
                var lostItemList = new ViewLostPage();
                await Navigation.PushAsync(lostItemList);
            }
            var lostItemList = new ViewLostPage(_dbService);
            await Navigation.PushAsync(lostItemList);
        }


        private async void OnFilterItemsClicked(object sender, EventArgs e)
        {
            var filterItemsPage = new FilterItemsPage(_dbService);
            await Navigation.PushAsync(filterItemsPage);
        }


        // LOGIN Methods

        private void logInAttempt(object sender, TextChangedEventArgs e)
        {
            // Get the text entered in the Entry field
            var input = logIn.Text;

            // Check if the input is 8 characters long and starts with 'M'
            if (input.Length == 8 && input.StartsWith("M"))
            {
                // Input is valid
                validLogIn = true;
            }
            else
            {
                // Input is invalid
                validLogIn = false;
            }
        }


    }


}