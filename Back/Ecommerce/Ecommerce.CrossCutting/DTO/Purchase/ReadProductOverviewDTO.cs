namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class ReadProductOverviewDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public double UnitPrice { get; set; }
        public int Quantity { get; set; }

        public string CategoryText { get; set; }
        public string ColorText { get; set; }
        public string SizeText { get; set; }
    }
}