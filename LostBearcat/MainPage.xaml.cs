using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace LostBearcat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
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

            await DisplayAlert("Success",
                $"Item '{ItemNameEntry.Text}' added successfully!",
                "OK");

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