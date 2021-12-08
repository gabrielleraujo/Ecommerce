using System;

namespace Job.CrossCutting.DTO.Purchase
{
    public class WritePurchaseSummaryDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int UserId { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }

        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string CategoryText { get; set; }
        public string ColorText { get; set; }
        public string SizeText { get; set; }
    }
}