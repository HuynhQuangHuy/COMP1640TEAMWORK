using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeamWork.Models
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }

        public int ItemId { get; set; }
        
        public Item Item { get; set; }

        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        [Required]
        [DisplayName("Idea Description")]
        public string Description { get; set; }

        public IEnumerable<Comment> Comments { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte[] File { get; set; }

        public string UrlFile { get; set; }
        public string NameOfFile { get; set; }
    }
}