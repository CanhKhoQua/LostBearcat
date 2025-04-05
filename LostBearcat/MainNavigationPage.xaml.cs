using Microsoft.Maui.Controls;
using System;

namespace LostBearcat
{
    public partial class MainNavigationPage : ContentPage
    {
        public MainNavigationPage()
        {
            InitializeComponent(); // Make sure this matches your XAML
        }

        private async void OnAddNewItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage());
        }

        private async void OnViewLostItemsClicked(object sender, EventArgs e)
        {
            // Add navigation logic for viewing lost items
        }

        private async void OnItemInformationClicked(object sender, EventArgs e)
        {
            // Add navigation logic for item information
        }

        private async void OnFilterItemsClicked(object sender, EventArgs e)
        {
            // Add navigation logic for filtering items
        }
    }
}