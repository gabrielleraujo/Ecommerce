﻿using System;

namespace Ecommerce.Data.Entities
{
    public class PurchaseSummary
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public string CategoryText { get; set; }
        public string ColorText { get; set; }
        public string SizeText { get; set; }

        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}