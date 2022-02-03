using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Product;

namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseSummaryDTO
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public IList<ReadProductDTO> Products { get; set; }
    }
}