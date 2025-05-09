﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace LostBearcat.Models
{
    public class LostItem
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public string Description { get; set; }
        public string LocationFound { get; set; }
        public string Category { get; set; }
        public string ImagePath { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
