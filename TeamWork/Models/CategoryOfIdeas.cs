using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class CategoryOfIdeas
    {
        [Key]
        public int CategoryOfIdeaID { get; set; }

        public string Description { get; set; }
    }
}