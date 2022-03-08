using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TeamWork.Models
{
    public class IdeaUser
    {
        
        public int Id { get; set; }

        public int IdeaId { get; set; }
        public Idea Idea { get; set; }

        public int CommentId { get; set; }
        public Comment Comment { get; set; }

        public bool IsThumbUp { get; set; }

    }
}