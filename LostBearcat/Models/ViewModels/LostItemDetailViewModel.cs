using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;

namespace LostBearcat.Models.ViewModels
{
    partial class LostItemDetailViewModel : ObservableObject
    {
        [ObservableProperty]
        private LostItem lostItem;
    }
}
