using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public int SalesId { get; set; }
        public int Quantity { get; set; }
        public string Phone { get; set; }
        public string Color { get; set; }
        public string Others { get; set; }
        public decimal Total { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Sales Sales { get; set; }
        public System.Guid UserIdN { get; set; }

    }
}