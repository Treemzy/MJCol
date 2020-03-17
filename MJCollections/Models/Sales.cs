using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public class Sales
    {
        public int SalesId { get; set; }
        public string SaleTitle { get; set; }

        [Display(Name = "Date"), DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Quantity"), Required(ErrorMessage = "The quantity field cannot be empty")]
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        //public int StockBalanceId { get; set; }
        public decimal UnitPrice { get; set; }
        public string  Phone { get; set; }
        public string Comment { get; set; }
        public string Pictures { get; set; }
        public virtual Product Products { get; set; }
        //public virtual StockBalance StockBalances { get; set; }

        [Display(Name = "Status")]
        public Status Status { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
        [Required]
        public System.Guid UserIdN { get; set; }
    }
}