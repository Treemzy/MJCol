using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class Request
    {
        public int RequestId { get; set; }
        public string Quantity { get; set; }
        public string Color { get; set; }
        public string Phone { get; set; }
        public int SalesId { get; set; }
        public virtual Sales Sales { get; set; }

    }
}