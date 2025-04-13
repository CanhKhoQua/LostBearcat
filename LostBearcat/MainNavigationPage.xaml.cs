using LostBearcat.Views;
using Microsoft.Maui.Controls;
using System;

namespace LostBearcat
{
    public partial class MainNavigationPage : ContentPage
    {
        private readonly LocalDBService _dbService;

        public MainNavigationPage(LocalDBService dbService)
        {
            _dbService = dbService ?? throw new ArgumentNullException(nameof(dbService));
            InitializeComponent(); // Make sure this matches your XAML
        }

        private async void OnAddNewItemClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItemPage(_dbService));
        }

        private async void OnViewLostItemsClicked(object sender, EventArgs e)
        {
            var lostItemList = new ViewLostPage(_dbService);
            await Navigation.PushAsync(lostItemList);
        }

        private async void OnItemInformationClicked(object sender, EventArgs e)
        {
            // TODO: UPDATE INFO HERE TO NAVIGATE TO ITEM DETAILS PAGE, possibly more
            // 
            // await Navigation.PushAsync(__________);
            // 
            //
        }

        private async void OnFilterItemsClicked(object sender, EventArgs e)
        {
            // TODO: UPDATE INFO HERE TO NAVIGATE TO ITEM FILTERING PAGE, possibly more
            // 
            // await Navigation.PushAsync(__________);
            // 
            //
        }
    }
}