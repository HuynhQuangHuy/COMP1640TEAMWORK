using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeamWork.Models
{
    public class IdeaUser
    {
        [Key]
        public int Id { get; set; }

        public int IdeaId { get; set; }
        public Idea Idea { get; set; }
       
        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        [DisplayName("Thumb Up")]
        public bool IsThumbUp { get; set; }

        [DisplayName("Thumb Down")]
        public bool IsThumbDown { get; set; }
    }
}
