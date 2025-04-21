using LostBearcat.Views;
using Microsoft.Maui.Controls;
using System;

namespace LostBearcat
{
    public partial class MainNavigationPage : ContentPage
    {
        private readonly LocalDBService _dbService;
        public bool validLogIn;

        public MainNavigationPage(LocalDBService dbService)
        {
            _dbService = dbService ?? throw new ArgumentNullException(nameof(dbService));
            InitializeComponent(); // Make sure this matches your XAML
        }

        private async void OnAddNewItemClicked(object sender, EventArgs e)
        {
            if (validLogIn)
            {
                await Navigation.PushAsync(new AddItemPage(_dbService));
            }
            else
            {
                await DisplayAlert("Login Required", "Please log in to add an item.", "OK");
            }
        }

        private async void OnViewLostItemsClicked(object sender, EventArgs e)
        {
            if (validLogIn)
            {
                await Navigation.PushAsync(new ViewLostPage(_dbService));
            }
            else
            {
                await DisplayAlert("Login Required", "Please log in to view lost items.", "OK");
            }
        }

        private async void OnFilterItemsClicked(object sender, EventArgs e)
        {

            if (validLogIn)
            {
                await Navigation.PushAsync(new FilterItemsPage(_dbService));
            }
            else
            {
                await DisplayAlert("Login Required", "Please log in to filter lost items.", "OK");
            }

            
        }

        // LOGIN Methods
        private void logInAttempt(object sender, TextChangedEventArgs e)
        {
            var input = logIn.Text;

            // Check if the input is 9 characters long and starts with 'M'
            validLogIn = input.Length == 9 && input.StartsWith("M");
        }
    }
}
