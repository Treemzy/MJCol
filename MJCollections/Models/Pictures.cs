using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class Pictures
    {
        public int PicturesId { get; set; }
        [Display(Name = "Product Image")]
        public string ProductImage { get; set; }
        public int ProductId { get; set; }
        public virtual Product Products { get; set; }
    }
}