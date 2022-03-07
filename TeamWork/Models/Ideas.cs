using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace TeamWork.Models
{
    public class Ideas
    {
        [Key]
        public int IdeaID { get; set; }

        public string NameOfIdea { get; set; }

        public int CategoryOfIdeaID { get; set; }

        public DateTime DateTime { get; set; }
    }
}