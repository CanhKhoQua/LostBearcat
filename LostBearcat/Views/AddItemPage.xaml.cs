using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using System;

namespace LostBearcat
{
    public partial class AddItemPage : ContentPage
    {
        private readonly LocalDBService _dbService;
        private int _editItemId;
        private string imagePath;
        public AddItemPage(LocalDBService dbService)
        {
            InitializeComponent();
            _dbService = dbService;
        }

        private async void OnAddImageClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync(new MediaPickerOptions
                {
                    Title = "Select Item Image"
                });

                if (result != null)
                {
                    imagePath = result.FullPath;
                    var stream = await result.OpenReadAsync();
                    SelectedImage.Source = ImageSource.FromStream(() => stream);
                }
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"An error occurred: {ex.Message}", "OK");
            }
        }

        private async void OnSubmitClicked(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(ItemNameEntry.Text))
            {
                await DisplayAlert("Validation Error", "Please enter an item name", "OK");
                return;
            }

            if (CategoryPicker.SelectedIndex == -1)
            {
                await DisplayAlert("Validation Error", "Please select a category", "OK");
                return;
            }

            // Save item logic would go here
            if (_editItemId == 0)
            {
                await _dbService.Create(new Models.LostItem
                {
                    ItemName = ItemNameEntry.Text,
                    Description = DescriptionEntry.Text,
                    LocationFound = LocationFoundEntry.Text,
                    Category = CategoryPicker.SelectedItem.ToString(),
                    ImagePath = imagePath,
                    DateAdded = DateTime.Now
                });
            }
            else
            {
                await _dbService.Update(new Models.LostItem
                {
                    ItemId = _editItemId,
                    Description = DescriptionEntry.Text,
                    LocationFound = LocationFoundEntry.Text,
                    Category = CategoryPicker.SelectedItem.ToString(),
                    ImagePath = imagePath,
                    DateAdded = DateTime.Now
                });
            }
            // For now, just show a success message
            await DisplayAlert("Success",
                $"Item '{ItemNameEntry.Text}' added successfully!",
                "OK");

            // Reset form
            ResetForm();
        }

        private void OnCancelClicked(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            ItemNameEntry.Text = string.Empty;
            DescriptionEntry.Text = string.Empty;
            LocationFoundEntry.Text = string.Empty;
            CategoryPicker.SelectedIndex = -1;
            SelectedImage.Source = null;
        }
    }
}