using System;
using System.Collections.Generic;

namespace Ecommerce.Data.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public int AddressId { get; set; }
        public Address Address { get; set; }

        public double Price { get; set; }
        public bool HasSummary { get; set; }
        public DateTime Date { get; set; }

        public IList<PurchaseItem> Products { get; set; }
    }
}