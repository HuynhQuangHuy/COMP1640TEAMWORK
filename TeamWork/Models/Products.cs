using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class Products
    {
        [Key]
        public int ProductID { get; set; }

        public string NameOfProduct { get; set; }

        public int CategoryOfProductID { get; set; }
    }
}