using LostBearcat.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LostBearcat.Views;
public partial class ViewLostPage : ContentPage
{
    private ObservableCollection<LostItem> LostItems;
    private ObservableCollection<LostItem> FilteredLostItems;

    public ViewLostPage()
    {
        InitializeComponent();

        // Sample data
        LostItems = new ObservableCollection<LostItem>
        {
            new LostItem {  ItemName = "Wallet", Description = "Black leather wallet",
                LocationFound = "Library", Category = "Accessories", ImagePath = "bearcatlogo.png", DateAdded = DateTime.Now.AddDays(-2) },
            new LostItem { ItemName = "Keys", Description = "Set of house keys",
                LocationFound = "Library", Category = "Other", ImagePath = "bearcatlogo.png", DateAdded = DateTime.Now.AddDays(-5) },
            new LostItem { ItemName = "Phone", Description = "iPhone",
                LocationFound = "Library", Category = "Electronic", ImagePath = "bearcatlogo.png", DateAdded = DateTime.Now.AddDays(-1) }
        };

        FilteredLostItems = new ObservableCollection<LostItem>(LostItems);
        cvItems.ItemsSource = FilteredLostItems;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Make sure the search bar is properly connected after the page is loaded
        if (searchBar != null)
        {
            searchBar.TextChanged -= OnSearchTextChanged; // Remove any existing handlers
            searchBar.TextChanged += OnSearchTextChanged; // Add the handler
        }
    }

    private async void cvItemTapped(object sender, SelectionChangedEventArgs e)
    {
        var lostItem = e.CurrentSelection.FirstOrDefault() as LostItem;
        if (lostItem != null)
        {
            var lostDetail = new LostDetailPage(lostItem);
            await Navigation.PushAsync(lostDetail);
            ((CollectionView)sender).SelectedItem = null;
        }
    }

    public void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {
        // Add debug to verify this is being called
        System.Diagnostics.Debug.WriteLine($"Search text changed: {e.NewTextValue}");

        string searchText = e.NewTextValue?.ToLower() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(searchText))
        {
            // If search is empty, show all items
            FilteredLostItems.Clear();
            foreach (var item in LostItems)
            {
                FilteredLostItems.Add(item);
            }
        }
        else
        {
            // Filter items based on search text
            FilteredLostItems.Clear();
            var filteredItems = LostItems.Where(item =>
                item.ItemName.ToLower().Contains(searchText) ||
                item.Description.ToLower().Contains(searchText) ||
                item.LocationFound.ToLower().Contains(searchText) ||
                item.Category.ToLower().Contains(searchText)
            );

            foreach (var item in filteredItems)
            {
                FilteredLostItems.Add(item);
            }
        }
    }
}