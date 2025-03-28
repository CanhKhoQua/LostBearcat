using Microsoft.Maui.Controls;
using System;

namespace LostBearcat
{
    public partial class NavigationPage : ContentPage
    {
        public NavigationPage()
        {
            InitializeComponent();
        }

        private async void OnAddNewItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());
        }

        private async void OnViewLostItemsClicked(object sender, EventArgs e)
        {
            // TODO: Implement View Lost Items Page
            await DisplayAlert("Coming Soon", "View Lost Items page is not yet implemented.", "OK");
        }

        private async void OnItemInformationClicked(object sender, EventArgs e)
        {
            // TODO: Implement Item Information Page
            await DisplayAlert("Coming Soon", "Item Information page is not yet implemented.", "OK");
        }

        private async void OnFilterItemsClicked(object sender, EventArgs e)
        {
            // TODO: Implement Filter Items Page
            await DisplayAlert("Coming Soon", "Filter Items page is not yet implemented.", "OK");
        }
    }
}