using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopBridgeMVC.Models
{
    public class ProductMVCModel
    {
        public int ProductID { get; set; }
        [Required(ErrorMessage ="Name is required.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required(ErrorMessage = "Category is required.")]
        public string Category { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public Nullable<decimal> Price { get; set; }
    }
}