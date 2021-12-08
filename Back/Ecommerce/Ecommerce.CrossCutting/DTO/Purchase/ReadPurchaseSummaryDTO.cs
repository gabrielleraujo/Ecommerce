using System;
using System.Collections.Generic;

namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseSummaryDTO
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public IList<ReadProductOverviewDTO> Products { get; set; }
    }
}