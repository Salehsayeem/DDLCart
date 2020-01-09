using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DropDownListCart.Models
{
    public class Item
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [ReadOnly(true)]
        public int Price { get; set; }
        [Required]
        public int Quantity { get; set; }
    }
}