using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string Type { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
    }
}