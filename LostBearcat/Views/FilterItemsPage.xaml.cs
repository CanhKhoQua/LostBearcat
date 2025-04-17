using Microsoft.Maui.Controls;
using LostBearcat.Models.ViewModels;

namespace LostBearcat
{
    public partial class FilterItemsPage : ContentPage
    {
        private readonly FilterItemsViewModel _viewModel;
        private readonly LocalDBService _dbService;

        // Modified constructor to accept _dbService
        public FilterItemsPage(LocalDBService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
            _viewModel = (FilterItemsViewModel)BindingContext;
        }

        // Filter command already handled by the ViewModel via RelayCommand
        private async void OnFilterClicked(object sender, EventArgs e)
        {
            // Triggering the filter command in the ViewModel and passing _dbService
            await _viewModel.FilterItemsAsync(_dbService);
        }

        // Reset command already handled by the ViewModel via RelayCommand
        private void OnResetClicked(object sender, EventArgs e)
        {
            // Calling the ResetFilters command in the ViewModel
            _viewModel.ResetFilters();
        }
    }
}
