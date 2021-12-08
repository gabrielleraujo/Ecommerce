using System;
using System.Collections.Generic;

namespace Job.CrossCutting.DTO.Purchase
{
    public class ReadPurchaseDTO
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public virtual IList<ReadPurchaseItemDTO> Produtos { get; set; }
        public virtual DateTime Data{ get; set; }
        public double Price { get; set; }
        public bool HasSummary { get; set; }
    }
}