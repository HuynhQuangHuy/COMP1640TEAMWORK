using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class Idea
    {
      
        public int Id { get; set; }

        public int ItemId { get; set; }
        public int Item { get; set; }

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public string Decription { get; set; }



    }
}