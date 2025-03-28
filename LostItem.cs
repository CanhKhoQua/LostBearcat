using System;

namespace LostBearcat.Models
{
    public class LostItem
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string LocationFound { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
    }
}