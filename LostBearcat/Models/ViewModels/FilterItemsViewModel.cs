using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using LostBearcat.Models;

namespace LostBearcat.Models.ViewModels
{
    public partial class FilterItemsViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<LostItem> filteredItems = new();

        [ObservableProperty]
        private string selectedCategory = "All Categories";

        [ObservableProperty]
        private string selectedLocation = "All Locations";

        [ObservableProperty]
        private string selectedTimePeriod = "All Time";

        List<string> knownLocations = new List<string>
        {
            "Lindner",
            "TUC",
            "Langsam",
            "Baldwin Hall",
            "CCM",
            "Old Chemistry"
        };

        // Command to filter items
        [RelayCommand]
        public async Task FilterItemsAsync(LocalDBService dbService)
        {
            var allItems = await dbService.GetLostItems();

            var filtered = allItems.AsQueryable();

            // Apply Category filter
            if (!string.IsNullOrEmpty(SelectedCategory) && SelectedCategory != "All Categories")
            {
                filtered = filtered.Where(item => item.Category == SelectedCategory);
            }

            // Apply Location filter
            if (!string.IsNullOrEmpty(SelectedLocation) && SelectedLocation != "All Locations")
            {
                if (SelectedLocation == "Other")
                {
                    // Show items whose LocationFound is NOT in the known list and not null
                    filtered = filtered.Where(item =>
                        item.LocationFound != null &&
                        !knownLocations.Contains(item.LocationFound));
                }
                else
                {
                    // Show only items that match the selected location
                    filtered = filtered.Where(item =>
                        item.LocationFound != null &&
                        item.LocationFound == SelectedLocation);
                }
            }

            // Apply Time Period filter
            if (!string.IsNullOrEmpty(SelectedTimePeriod) && SelectedTimePeriod != "All Time")
            {
                DateTime currentDate = DateTime.Now;

                switch (SelectedTimePeriod)
                {
                    case "Less than 7 days":
                        filtered = filtered.Where(item => (currentDate - item.DateAdded).Days < 7);
                        break;
                    case "7-14 days":
                        filtered = filtered.Where(item => (currentDate - item.DateAdded).Days >= 7 && (currentDate - item.DateAdded).Days <= 14);
                        break;
                    case "15-30 days":
                        filtered = filtered.Where(item => (currentDate - item.DateAdded).Days >= 15 && (currentDate - item.DateAdded).Days <= 30);
                        break;
                    case "More than a month":
                        filtered = filtered.Where(item => (currentDate - item.DateAdded).Days > 30);
                        break;
                }
            }

            // Update filtered items
            FilteredItems = new ObservableCollection<LostItem>(filtered.ToList());
        }

        // Command to reset filters

        [RelayCommand]
        public void ResetFilters()
        {
            SelectedCategory = "All Categories";
            SelectedLocation = "All Locations";
            SelectedTimePeriod = "All Time";

            FilteredItems.Clear();
        }
    }
}

