using LostBearcat.Models;
using System.Collections.ObjectModel;

namespace LostBearcat.Views;
public partial class ViewLostPage : ContentPage
{
    //private ObservableCollection<LostItem> LostItems;
    private ObservableCollection<LostItem> FilteredLostItems;
    private readonly LocalDBService _dBService;
    private int _editItemId;

    public ViewLostPage(LocalDBService dBService)
    {
        InitializeComponent();

        /* Sample data
        LostItems = new ObservableCollection<LostItem>
        {
            new LostItem {  ItemName = "Wallet", Description = "Black leather wallet",
                LocationFound = "Library", Category = "Accessories", ImagePath = "bearcatlogo.png", DateAdded = DateTime.Now.AddDays(-2) },
            new LostItem { ItemName = "Keys", Description = "Set of house keys",
                LocationFound = "Library", Category = "Other", ImagePath = "bearcatlogo.png", DateAdded = DateTime.Now.AddDays(-5) },
            new LostItem { ItemName = "Phone", Description = "iPhone",
                LocationFound = "Library", Category = "Electronic", ImagePath = "bearcatlogo.png", DateAdded = DateTime.Now.AddDays(-1) }
        };
        */

        _dBService = dBService;
        Task.Run(async () => cvItems.ItemsSource = await _dBService.GetLostItems());
    }

    private async void cvItemTapped(object sender, SelectionChangedEventArgs e)
    {
        var lostItem = e.CurrentSelection.FirstOrDefault() as LostItem;
        if (lostItem != null)
        {
            var lostDetail = new LostDetailPage(lostItem, _dBService);
            await Navigation.PushAsync(lostDetail);
            ((CollectionView)sender).SelectedItem = null;
        }
    }
    //protected override async void OnAppearing()
    //{
    //    base.OnAppearing();

    //    var lostItems = await _dBService.GetLostItems();
    //    // Make sure the
    //    //
    //    //
    //    //
    //    // h bar is properly connected after the page is loaded
    //    if (searchBar != null)
    //    {
    //        searchBar.TextChanged -= OnSearchTextChanged; // Remove any existing handlers
    //        searchBar.TextChanged += OnSearchTextChanged; // Add the handler
    //    }
    //}

    //public void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    //{
        /*
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
 }*/
    //}
}