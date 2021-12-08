using System;
using System.Collections.Generic;

namespace Job.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseSummaryDTO
    {
        public DateTime Date { get; set; }
        public int UserId { get; set; }
        public double TotalPrice { get; set; }
        public IList<ReadProductOverviewDTO> Products { get; set; }
    }
}