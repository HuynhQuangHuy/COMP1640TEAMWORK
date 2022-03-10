using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class IdeaUser
    {
       

        [Key][ Column(Order = 0)]
        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
        [Key]
        [Column(Order = 1)]

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        [DisplayName("Thumb Up")]
        public bool IsThumbUp { get; set; }

        [DisplayName("Thumb Down")]
        public bool IsThumbDown { get; set; }
    }
}
