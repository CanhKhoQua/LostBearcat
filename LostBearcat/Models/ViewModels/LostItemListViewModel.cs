using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace LostBearcat.Models.ViewModels
{
    partial class LostItemListViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<LostItem> lostItems = new();
        [ObservableProperty]
        private LostItem item = new();
        [RelayCommand]
        private void Add()
        {
            lostItems.Add(item);
            item = new();
        }
    }
}
