using LostBearcat.Models;

namespace LostBearcat.Views;

public partial class LostDetailPage : ContentPage
{
	public LostItem Item { get; set; }
	public LostDetailPage(LostItem item)
	{
		InitializeComponent();
        Item = item;
        BindingContext = Item;
    }
}