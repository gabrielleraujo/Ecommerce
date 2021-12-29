using System;
using System.Collections.Generic;
using Ecommerce.CrossCutting.DTO.Address;
using Ecommerce.CrossCutting.DTO.User;

namespace Ecommerce.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseDTO
    {
        public int Id { get; set; }
        public ReadUserDTO User { get; set; }
        public ReadAddressDTO Address { get; set; }
        public IList<ReadPurchaseItemDTO> Products { get; set; }
        public DateTime Date{ get; set; }
        public double Price { get; set; }
        public bool HasSummary { get; set; }
    }
}