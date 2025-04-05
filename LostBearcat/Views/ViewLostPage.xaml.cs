using LostBearcat.Models;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace LostBearcat.Views;

public partial class ViewLostPage : ContentPage
{
    private ObservableCollection<LostItem> LostItems;

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

        cvItems.ItemsSource = LostItems;
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
}