using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int ProductTypeId { get; set; }
        public string Description { get; set; }
        public string Packaging { get; set; }
        public string Remarks { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual ProductType ProductTypes { get; set; }
    }
}