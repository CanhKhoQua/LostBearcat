using LostBearcat.Views;
using Microsoft.Maui.Controls;
using System;

namespace LostBearcat
{
    public partial class MainNavigationPage : ContentPage
    {
<<<<<<< HEAD
        private readonly LocalDBService _dbService;

        public MainNavigationPage(LocalDBService dbService)
=======



        public bool validLogIn;



        public MainNavigationPage()
>>>>>>> Jaecar
        {
            _dbService = dbService ?? throw new ArgumentNullException(nameof(dbService));
            InitializeComponent(); // Make sure this matches your XAML
        }

        private async void OnAddNewItemClicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            await Navigation.PushAsync(new AddItemPage(_dbService));
=======
            if (validLogIn)
            {
                await Navigation.PushAsync(new AddItemPage());
            }
>>>>>>> Jaecar
        }

        private async void OnViewLostItemsClicked(object sender, EventArgs e)
        {
<<<<<<< HEAD
            var lostItemList = new ViewLostPage(_dbService);
            await Navigation.PushAsync(lostItemList);
=======
            if (validLogIn)
            {
                var lostItemList = new ViewLostPage();
                await Navigation.PushAsync(lostItemList);
            }
>>>>>>> Jaecar
        }


        private async void OnFilterItemsClicked(object sender, EventArgs e)
        {
            // TODO: UPDATE INFO HERE TO NAVIGATE TO ITEM FILTERING PAGE, possibly more
            // 
            // await Navigation.PushAsync(__________);
            // 
            //
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