using LostBearcat.Models;

namespace LostBearcat.Views;

public partial class LostDetailPage : ContentPage
{
    private readonly LocalDBService _dbService;
    public LostItem Item { get; set; }
	public LostDetailPage(LostItem item, LocalDBService dbService)
	{
		InitializeComponent();
        _dbService = dbService;
        Item = item;
        BindingContext = Item;
    }
    private async void OnDeleteClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert("Confirm Delete", "Are you sure you want to delete this item?", "Yes", "No");
        if (confirm)
        {
            await _dbService.Delete(Item);
            await DisplayAlert("Deleted", "The item has been deleted.", "OK");
            await Navigation.PopAsync(); // Go back to the previous page
        }
    }
}