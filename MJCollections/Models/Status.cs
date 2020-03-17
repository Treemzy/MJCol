using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MJCollections.Models
{
    public enum Status
    {
        [Display(Name = "Published")]
        Published,
        [Display(Name = "Draft")]
        Draft
    }
}