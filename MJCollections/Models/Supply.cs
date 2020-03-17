using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class Supply
    {
        public int SupplyId { get; set; }
        public DateTime Date { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public virtual Product Products { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
    }
}